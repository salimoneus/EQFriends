﻿namespace EQFriends
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.radioButtonFriends = new System.Windows.Forms.RadioButton();
            this.radioButtonIgnored = new System.Windows.Forms.RadioButton();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.listBoxDetails = new System.Windows.Forms.ListBox();
            this.buttonNone = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxBackup = new System.Windows.Forms.CheckBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonPasteReplace = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCharacterFilesParsed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTotalCombinedFriends = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectFolder.Location = new System.Drawing.Point(79, 21);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(255, 28);
            this.buttonSelectFolder.TabIndex = 0;
            this.buttonSelectFolder.Text = "<Select Everquest Folder>";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // radioButtonFriends
            // 
            this.radioButtonFriends.AutoSize = true;
            this.radioButtonFriends.Checked = true;
            this.radioButtonFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonFriends.Location = new System.Drawing.Point(193, 9);
            this.radioButtonFriends.Name = "radioButtonFriends";
            this.radioButtonFriends.Size = new System.Drawing.Size(58, 17);
            this.radioButtonFriends.TabIndex = 1;
            this.radioButtonFriends.TabStop = true;
            this.radioButtonFriends.Text = "Friends";
            this.radioButtonFriends.UseVisualStyleBackColor = true;
            this.radioButtonFriends.CheckedChanged += new System.EventHandler(this.radioButtonFriends_CheckedChanged);
            // 
            // radioButtonIgnored
            // 
            this.radioButtonIgnored.AutoSize = true;
            this.radioButtonIgnored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonIgnored.Location = new System.Drawing.Point(258, 9);
            this.radioButtonIgnored.Name = "radioButtonIgnored";
            this.radioButtonIgnored.Size = new System.Drawing.Size(60, 17);
            this.radioButtonIgnored.TabIndex = 2;
            this.radioButtonIgnored.Text = "Ignored";
            this.radioButtonIgnored.UseVisualStyleBackColor = true;
            this.radioButtonIgnored.CheckedChanged += new System.EventHandler(this.radioButtonIgnored_CheckedChanged);
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(15, 28);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelected.Size = new System.Drawing.Size(151, 145);
            this.listBoxSelected.TabIndex = 4;
            this.listBoxSelected.SelectedIndexChanged += new System.EventHandler(this.listBoxSelected_SelectedIndexChanged);
            // 
            // listBoxDetails
            // 
            this.listBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxDetails.FormattingEnabled = true;
            this.listBoxDetails.Location = new System.Drawing.Point(189, 28);
            this.listBoxDetails.Name = "listBoxDetails";
            this.listBoxDetails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxDetails.Size = new System.Drawing.Size(141, 145);
            this.listBoxDetails.TabIndex = 5;
            this.listBoxDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxDetails_KeyDown);
            // 
            // buttonNone
            // 
            this.buttonNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNone.Location = new System.Drawing.Point(19, 179);
            this.buttonNone.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNone.Name = "buttonNone";
            this.buttonNone.Size = new System.Drawing.Size(67, 22);
            this.buttonNone.TabIndex = 6;
            this.buttonNone.Text = "Select None";
            this.buttonNone.UseVisualStyleBackColor = true;
            this.buttonNone.Click += new System.EventHandler(this.buttonNone_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAll.Location = new System.Drawing.Point(94, 179);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(67, 22);
            this.buttonAll.TabIndex = 7;
            this.buttonAll.Text = "Select All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(108, 362);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(159, 25);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update Files";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "EQ Folder:";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(79, 66);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(138, 21);
            this.comboBoxServer.TabIndex = 14;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxServer_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Character Files:";
            // 
            // checkBoxBackup
            // 
            this.checkBoxBackup.AutoSize = true;
            this.checkBoxBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxBackup.Location = new System.Drawing.Point(235, 67);
            this.checkBoxBackup.Name = "checkBoxBackup";
            this.checkBoxBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxBackup.Size = new System.Drawing.Size(99, 17);
            this.checkBoxBackup.TabIndex = 16;
            this.checkBoxBackup.Text = "Create Backups";
            this.checkBoxBackup.UseVisualStyleBackColor = true;
            // 
            // buttonCopy
            // 
            this.buttonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopy.Location = new System.Drawing.Point(193, 179);
            this.buttonCopy.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(50, 22);
            this.buttonCopy.TabIndex = 17;
            this.buttonCopy.Text = "Copy All";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonPasteReplace
            // 
            this.buttonPasteReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPasteReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPasteReplace.Location = new System.Drawing.Point(249, 179);
            this.buttonPasteReplace.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPasteReplace.Name = "buttonPasteReplace";
            this.buttonPasteReplace.Size = new System.Drawing.Size(76, 22);
            this.buttonPasteReplace.TabIndex = 18;
            this.buttonPasteReplace.Text = "Paste / Merge";
            this.buttonPasteReplace.UseVisualStyleBackColor = true;
            this.buttonPasteReplace.Click += new System.EventHandler(this.buttonPasteReplace_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBasic);
            this.tabControl.Controls.Add(this.tabPageAdvanced);
            this.tabControl.Location = new System.Drawing.Point(12, 108);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(354, 239);
            this.tabControl.TabIndex = 19;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.panelStats);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(346, 213);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.SystemColors.Window;
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.panelStatus);
            this.panelStats.Controls.Add(this.label5);
            this.panelStats.Controls.Add(this.labelCharacterFilesParsed);
            this.panelStats.Controls.Add(this.label7);
            this.panelStats.Controls.Add(this.labelTotalCombinedFriends);
            this.panelStats.Location = new System.Drawing.Point(45, 34);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(255, 136);
            this.panelStats.TabIndex = 8;
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.label8);
            this.panelStatus.Controls.Add(this.labelStatus);
            this.panelStatus.Location = new System.Drawing.Point(-1, 85);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(255, 50);
            this.panelStatus.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(83, 17);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Character files parsed:";
            // 
            // labelCharacterFilesParsed
            // 
            this.labelCharacterFilesParsed.AutoSize = true;
            this.labelCharacterFilesParsed.Location = new System.Drawing.Point(153, 23);
            this.labelCharacterFilesParsed.Name = "labelCharacterFilesParsed";
            this.labelCharacterFilesParsed.Size = new System.Drawing.Size(13, 13);
            this.labelCharacterFilesParsed.TabIndex = 1;
            this.labelCharacterFilesParsed.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Total combined friends:";
            // 
            // labelTotalCombinedFriends
            // 
            this.labelTotalCombinedFriends.AutoSize = true;
            this.labelTotalCombinedFriends.Location = new System.Drawing.Point(153, 49);
            this.labelTotalCombinedFriends.Name = "labelTotalCombinedFriends";
            this.labelTotalCombinedFriends.Size = new System.Drawing.Size(13, 13);
            this.labelTotalCombinedFriends.TabIndex = 3;
            this.labelTotalCombinedFriends.Text = "0";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.listBoxDetails);
            this.tabPageAdvanced.Controls.Add(this.buttonPasteReplace);
            this.tabPageAdvanced.Controls.Add(this.label2);
            this.tabPageAdvanced.Controls.Add(this.buttonCopy);
            this.tabPageAdvanced.Controls.Add(this.buttonNone);
            this.tabPageAdvanced.Controls.Add(this.buttonAll);
            this.tabPageAdvanced.Controls.Add(this.label3);
            this.tabPageAdvanced.Controls.Add(this.listBoxSelected);
            this.tabPageAdvanced.Controls.Add(this.radioButtonIgnored);
            this.tabPageAdvanced.Controls.Add(this.radioButtonFriends);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(346, 213);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 397);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.checkBoxBackup);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EQFriends";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.RadioButton radioButtonFriends;
        private System.Windows.Forms.RadioButton radioButtonIgnored;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.ListBox listBoxDetails;
        private System.Windows.Forms.Button buttonNone;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxBackup;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonPasteReplace;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCharacterFilesParsed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTotalCombinedFriends;
        private System.Windows.Forms.TabPage tabPageAdvanced;
    }
}

