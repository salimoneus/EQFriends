using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace EQFriends
{
    public partial class Form1 : Form
    {
        private const string DefaultFriendMatch = @"^Friend\d{1,2}=";
        private const string DefaultIgnoredMatch = @"^Ignored\d{1,2}=";
        private const string NullEntry = @"*NULL*";
        private const string ErrorFile = @"EQFriends.err";
        private const string BackupRootFolder = @"EQFriends_Backups";
        private const string TitleBase = @"EQFriends";
        private const string SelectFolder = "<Select Everquest Folder>";
        private List<string> CopiedItems = new List<string>();

        private string m_folderName = String.Empty;
        private Dictionary<string, List<string>> m_friendsDb = new Dictionary<string, List<string>>();
        private bool m_requiresUpdate = false;
        private bool m_processSelectionChanged = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            checkBoxBackup.Checked = true;
            radioButtonFriends.Checked = true;
            UpdateDetailsTotal();
        }

        private bool FolderSelection(ref string folderName)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.ShowNewFolderButton = false;

            if (openFolderDialog.ShowDialog(this) == DialogResult.OK)
            {
                folderName = openFolderDialog.SelectedPath;
                return true;
            }

            return false;
        }

        private void ProcessFolder(string defaultServer = "")
        {
            buttonSelectFolder.Text = m_folderName;

            List<string> allFiles = GetServers();

            comboBoxServer.Items.Clear();
            comboBoxServer.Items.AddRange(allFiles.ToArray());

            if (comboBoxServer.Items.Count == 0)
            {
                return;
            }

            if (defaultServer != "")
            {
                comboBoxServer.SelectedItem = defaultServer;

                if (comboBoxServer.SelectedItem == null)
                {
                    comboBoxServer.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxServer.SelectedIndex = 0;
            }

            ProcessServer();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (!FolderSelection(ref m_folderName))
            {
                return;
            }

            ProcessFolder();
        }

        private void HandleError(ref Exception ex, bool displayError = false)
        {
            System.IO.File.AppendAllText(ErrorFile, ex.ToString());
            if (displayError == true)
            {
                MessageBox.Show(this, "An error has occurred.  Please check the logfile " + ErrorFile + " for details", "EQFriends");
            }
        }

        private void ClearDetailsList()
        {
            listBoxDetails.Items.Clear();
            listBoxDetails.BackColor = Color.White;
            m_requiresUpdate = false;
        }

        private void ProcessServer()
        {
            listBoxSelected.Items.Clear();
            ClearDetailsList();
            UpdateDetailsTotal();

            if ((m_folderName == null) || (m_folderName == String.Empty) || (comboBoxServer.Text == String.Empty))
            {
                return;
            }

            string fileMatchPattern = @"*_" + comboBoxServer.Text + @".ini";
            string fileRegexPattern = @"^(?!UI_).+_" + Regex.Escape(comboBoxServer.Text) + @"\.ini$";

            Cursor oldcursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var myFiles = from file in System.IO.Directory.GetFiles(m_folderName, fileMatchPattern, System.IO.SearchOption.TopDirectoryOnly)
                              where Regex.IsMatch(System.IO.Path.GetFileName(file), fileRegexPattern, RegexOptions.IgnoreCase)
                              select System.IO.Path.GetFileName(file);

                listBoxSelected.Items.AddRange(myFiles.ToArray());

                foreach (string fileName in myFiles)
                {
                    m_friendsDb[fileName] = GetFriends(System.IO.Path.Combine(m_folderName, fileName));
                }

            }
            catch (Exception ex)
            {
                HandleError(ref ex);
            }

            this.Cursor = oldcursor;
            SelectAllFiles();
        }

        private List<string> GetServers()
        {
            List<string> serverList = new List<string>();

            Cursor oldcursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var myFiles = from file in System.IO.Directory.GetFiles(m_folderName, @"*.ini", System.IO.SearchOption.TopDirectoryOnly)
                              where Regex.IsMatch(System.IO.Path.GetFileName(file), @"^(?!UI_).+_.+\.ini$", RegexOptions.IgnoreCase)
                              select Regex.Match(System.IO.Path.GetFileName(file), @"^(?!UI_).+_(.+)\.ini$", RegexOptions.IgnoreCase).Groups[1].Value;

                serverList = myFiles.Distinct().ToList();
            }
            catch (Exception ex)
            {
                HandleError(ref ex);
            }

            this.Cursor = oldcursor;
            return serverList;
        }

        private List<string> GetFriends(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string regex;

            if (radioButtonFriends.Checked)
            {
                regex = DefaultFriendMatch;
            }
            else
            {
                regex = DefaultIgnoredMatch;
            }

            var myFriends = from line in lines
                            where Regex.IsMatch(line, regex, RegexOptions.IgnoreCase)
                            where !line.Contains(NullEntry)
                            select line.Split('=')[1].ToLower().Trim();

            return myFriends.Distinct().ToList();
        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            listBoxSelected.ClearSelected();
        }

        private void SelectAllFiles()
        {
            m_processSelectionChanged = false;
            for (int i = 0; i < listBoxSelected.Items.Count; ++i)
            {
                listBoxSelected.SetSelected(i, true);
            }
            m_processSelectionChanged = true;
            listBoxSelected_SelectedIndexChanged(null, null);
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            SelectAllFiles();
        }

        private void UpdateDetailsTotal()
        {
            Color statusColor = Color.White;
            Color detailsColor = Color.White;
            String titleText = TitleBase;
            String combinedFriendsText = "";
            String filesParsedText = "";
            String statusText = "";
            
            if (listBoxDetails.Items.Count > 0)
            {
                titleText += " (" + listBoxDetails.Items.Count + ")";
                combinedFriendsText = listBoxDetails.Items.Count.ToString();
                filesParsedText = listBoxSelected.SelectedIndices.Count.ToString();

                if (listBoxDetails.Items.Count > 100)
                {
                    detailsColor = ControlPaint.Light(Color.IndianRed);
                    statusColor = ControlPaint.Light(Color.IndianRed);
                    statusText = "Deletions required";
                }
                else if (m_requiresUpdate)
                {
                    detailsColor = ControlPaint.Light(Color.Yellow);
                    statusColor = ControlPaint.Light(Color.Yellow);
                    statusText = "Update recommended";
                }
                else
                {
                    detailsColor = Color.White;
                    statusColor = Color.White;
                    statusText = "No updated needed";
                }
            }

            panelStatus.BackColor = statusColor;
            listBoxDetails.BackColor = detailsColor;
            labelTotalCombinedFriends.Text = combinedFriendsText;
            labelCharacterFilesParsed.Text = filesParsedText;
            labelStatus.Text = statusText;
            this.Text = titleText;
        }

        private void listBoxSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_processSelectionChanged == false)
            {
                return;
            }

            ClearDetailsList();
            List<string> friendList = new List<string>();

            foreach (int selection in listBoxSelected.SelectedIndices)
            {
                List<string> selectedList = m_friendsDb[listBoxSelected.Items[selection].ToString()].ToList();

                if (friendList.Count > 0)
                {
                    var firstNotSecond = friendList.Except(selectedList).ToList();
                    var secondNotFirst = selectedList.Except(friendList).ToList();

                    if ((firstNotSecond.Count > 0) || (secondNotFirst.Count > 0))
                    {
                        listBoxDetails.BackColor = ControlPaint.Light(Color.Yellow);
                        m_requiresUpdate = true;
                    }
                }

                friendList.AddRange(selectedList);
                friendList = friendList.Distinct().ToList();
            }

            friendList.Sort();
            listBoxDetails.Items.AddRange(friendList.ToArray());
            UpdateDetailsTotal();
        }

        private void listBoxDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && (listBoxDetails.SelectedItems != null))
            {
                List<string> selectedItems = listBoxDetails.SelectedItems.Cast<string>().ToList();

                for (int selectedIndex = 0; selectedIndex < selectedItems.Count; ++selectedIndex)
                {
                    listBoxDetails.Items.Remove(selectedItems[selectedIndex]);
                }
                UpdateDetailsTotal();
            }
        }

        private void radioButtonFriends_CheckedChanged(object sender, EventArgs e)
        {
            ProcessServer();
        }

        private void radioButtonIgnored_CheckedChanged(object sender, EventArgs e)
        {
            ProcessServer();
        }

        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessServer();
        }

        private string GetConfigPath()
        {
            string path = "EQFriends\\userSettings.xml";
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), path);
        }

        private void SetConfigData(EQFriendsDataSet dataSet)
        {
            checkBoxBackup.Checked = dataSet.DoBackup;
            m_folderName = dataSet.EQFolder;
            tabControl.SelectedIndex = dataSet.SelectedTabIndex;
            ProcessFolder(dataSet.EQServer);
        }

        EQFriendsDataSet GetConfigData()
        {
            EQFriendsDataSet dataSet = new EQFriendsDataSet();

            dataSet.DoBackup = checkBoxBackup.Checked;
            dataSet.EQFolder = m_folderName;
            dataSet.SelectedTabIndex = tabControl.SelectedIndex;

            if (comboBoxServer.SelectedItem == null)
            {
                dataSet.EQServer = String.Empty;
            }
            else
            {
                dataSet.EQServer = comboBoxServer.SelectedItem.ToString();
            }
            return dataSet;
        }

        private void ReadConfigData()
        {
            string fileName = GetConfigPath();

            try
            {
                FileStream ReadFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlSerializer SerializerObj = new XmlSerializer(typeof(EQFriendsDataSet));
                EQFriendsDataSet loadedData = (EQFriendsDataSet)SerializerObj.Deserialize(ReadFileStream);

                SetConfigData(loadedData);

                ReadFileStream.Close();
            }
            catch (Exception ex)
            {
                HandleError(ref ex, false);
            }
        }

        private void WriteConfigData()
        {
            string fileName = GetConfigPath();

            try
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileName));
                TextWriter WriteFileStream = new StreamWriter(fileName, false);
                XmlSerializer SerializerObj = new XmlSerializer(typeof(EQFriendsDataSet));

                EQFriendsDataSet set = GetConfigData();
                SerializerObj.Serialize(WriteFileStream, set);

                WriteFileStream.Close();
            }
            catch (Exception ex)
            {
                HandleError(ref ex, false);
            }
        }

        private void DoUpdate()
        {
            List<string> itemList = new List<string>();
            string newLabel = (radioButtonFriends.Checked ? @"Friend" : @"Ignored");

            // create list
            for (int outerIndex = 0, detailIndex = 0; outerIndex < 100; ++outerIndex)
            {
                if (listBoxDetails.Items.Count >= (100 - outerIndex))
                {
                    itemList.Add(newLabel + outerIndex + @"=" + listBoxDetails.Items[detailIndex++].ToString());
                }
                else
                {
                    itemList.Add(newLabel + outerIndex + @"=" + NullEntry);
                }
            }

            string backupRootPath = System.IO.Path.Combine(m_folderName, BackupRootFolder);
            string dateString = string.Format("{0:MM-dd-yyyy}.{1}", DateTime.Now, Environment.TickCount);
            string backupDatedPath = System.IO.Path.Combine(backupRootPath, dateString);

            foreach (int fileIndex in listBoxSelected.SelectedIndices)
            {
                string fileName = listBoxSelected.Items[fileIndex].ToString();
                string fullFilePathName = System.IO.Path.Combine(m_folderName, fileName);
                string[] lines = System.IO.File.ReadAllLines(fullFilePathName);
                List<string> newFile = new List<string>();
                bool bTriggered = false;

                foreach (string line in lines)
                {
                    if (line.StartsWith(newLabel))
                    {
                        bTriggered = true;
                    }
                    else
                    {
                        if (bTriggered == true)
                        {
                            newFile.AddRange(itemList);
                            bTriggered = false;
                        }

                        newFile.Add(line);
                    }
                }

                if (checkBoxBackup.Checked)
                {
                    System.IO.Directory.CreateDirectory(backupDatedPath);
                    string backupFullFilePath = System.IO.Path.Combine(backupDatedPath, fileName);
                    System.IO.File.Copy(fullFilePathName, backupFullFilePath);
                }

                System.IO.File.WriteAllLines(fullFilePathName, newFile);
            }

            ProcessServer();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if ((listBoxSelected.Items.Count == 0) || (listBoxDetails.Items.Count == 0))
            {
                return;
            }

            if (listBoxDetails.Items.Count > 100)
            {
                MessageBox.Show(this, "Cannot save more than 100 entries, please delete some and retry", "EQFriends");
                return;
            }

            try
            {
                DoUpdate();
            }
            catch (Exception ex)
            {
                HandleError(ref ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
            ReadConfigData();

            if (m_folderName == String.Empty)
            {
                buttonSelectFolder.Text = SelectFolder;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteConfigData();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopiedItems = listBoxDetails.Items.Cast<String>().ToList();
        }

        private void buttonPasteReplace_Click(object sender, EventArgs e)
        {
            if (CopiedItems.Count > 0)
            {
                List<string> workingList = listBoxDetails.Items.Cast<String>().ToList();
                workingList.AddRange(CopiedItems.ToArray());
                workingList.Sort();

                ClearDetailsList();
                listBoxDetails.Items.AddRange(workingList.Distinct().ToArray());
                
                UpdateDetailsTotal();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl.SelectedTab.Text == "Basic") && (listBoxDetails.SelectedIndices.Count < listBoxDetails.Items.Count))
            {
                SelectAllFiles();
            }
        }
    }
}
