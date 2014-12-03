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

        private string m_folderName = String.Empty;
        private Dictionary<string, List<string>> m_friendsDb = new Dictionary<string, List<string>>();

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

        private void HandleError(ref Exception ex)
        {
            System.IO.File.AppendAllText(ErrorFile, ex.ToString());
            MessageBox.Show(this, "An error has occurred.  Please check the logfile " + ErrorFile + " for details", "EQFriends");
        }

        private void ProcessServer(bool bSelectAllFiles = true)
        {
            listBoxSelected.Items.Clear();
            listBoxDetails.Items.Clear();
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

            if (bSelectAllFiles)
            {
                SelectAllFiles();
            }
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

            return myFriends.ToList();
        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            listBoxSelected.ClearSelected();
        }

        private void SelectAllFiles()
        {
            for (int i = 0; i < listBoxSelected.Items.Count; ++i)
            {
                listBoxSelected.SetSelected(i, true);
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            SelectAllFiles();
        }

        private void UpdateDetailsTotal()
        {
            labelTotal.Text = "Total: " + listBoxDetails.Items.Count;
            if (listBoxDetails.Items.Count > 100)
            {
                labelTotal.BackColor = Color.Maroon;
                labelTotal.ForeColor = Color.White;
            }
            else
            {
                labelTotal.BackColor = SystemColors.Control;
                labelTotal.ForeColor = Color.Black;
            }
        }

        private void listBoxSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDetails.Items.Clear();
            
            List<string> friendList = new List<string>();

            foreach (int selection in listBoxSelected.SelectedIndices)
            {
                friendList.AddRange(m_friendsDb[listBoxSelected.Items[selection].ToString()].ToList());
            }

            friendList.Sort();
            listBoxDetails.Items.AddRange(friendList.Distinct().ToArray());
            UpdateDetailsTotal();
        }

        private void listBoxDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxDetails.SelectedIndex >= 0)
                {
                    listBoxDetails.Items.RemoveAt(listBoxDetails.SelectedIndex);
                    UpdateDetailsTotal();
                }
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
            
            ProcessFolder(dataSet.EQServer);
        }

        EQFriendsDataSet GetConfigData()
        {
            EQFriendsDataSet dataSet = new EQFriendsDataSet();

            dataSet.DoBackup = checkBoxBackup.Checked;
            dataSet.EQFolder = m_folderName;
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
                HandleError(ref ex);
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
                HandleError(ref ex);
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

            ProcessServer(false);
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteConfigData();
        }
    }
}
