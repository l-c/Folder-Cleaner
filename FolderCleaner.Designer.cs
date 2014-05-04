namespace FolderCleaner
{
    partial class FolderCleaner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browse = new System.Windows.Forms.Button();
            this.targetDirectory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.profileListBox = new System.Windows.Forms.ListBox();
            this.selectProfiles = new System.Windows.Forms.RadioButton();
            this.allProfiles = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.extensionList = new System.Windows.Forms.TextBox();
            this.selectTypes = new System.Windows.Forms.RadioButton();
            this.allTypes = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.daysOld = new System.Windows.Forms.TextBox();
            this.dateCut = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.dateRange = new System.Windows.Forms.RadioButton();
            this.allFiles = new System.Windows.Forms.RadioButton();
            this.includeSub = new System.Windows.Forms.CheckBox();
            this.targetBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.simulation = new System.Windows.Forms.CheckBox();
            this.backupDirectory = new System.Windows.Forms.TextBox();
            this.browseBackup = new System.Windows.Forms.Button();
            this.saveBackup = new System.Windows.Forms.CheckBox();
            this.backupBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.startButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.folderList = new System.Windows.Forms.TextBox();
            this.selectFolders = new System.Windows.Forms.RadioButton();
            this.allFolders = new System.Windows.Forms.RadioButton();
            this.tempFolder = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.load = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importToolStripMenuItem.Text = "Import Config";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportToolStripMenuItem.Text = "Save Config";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(13, 34);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(68, 22);
            this.browse.TabIndex = 1;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // targetDirectory
            // 
            this.targetDirectory.Location = new System.Drawing.Point(170, 34);
            this.targetDirectory.Name = "targetDirectory";
            this.targetDirectory.Size = new System.Drawing.Size(653, 22);
            this.targetDirectory.TabIndex = 2;
            this.targetDirectory.Text = "Target Directory";
            this.targetDirectory.LostFocus += new System.EventHandler(this.targetDirectory_lostFocus);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.profileListBox);
            this.groupBox1.Controls.Add(this.selectProfiles);
            this.groupBox1.Controls.Add(this.allProfiles);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 496);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profiles";
            // 
            // profileListBox
            // 
            this.profileListBox.Enabled = false;
            this.profileListBox.FormattingEnabled = true;
            this.profileListBox.Location = new System.Drawing.Point(7, 68);
            this.profileListBox.Name = "profileListBox";
            this.profileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.profileListBox.Size = new System.Drawing.Size(137, 420);
            this.profileListBox.TabIndex = 2;
            // 
            // selectProfiles
            // 
            this.selectProfiles.AutoSize = true;
            this.selectProfiles.Location = new System.Drawing.Point(7, 44);
            this.selectProfiles.Name = "selectProfiles";
            this.selectProfiles.Size = new System.Drawing.Size(96, 17);
            this.selectProfiles.TabIndex = 1;
            this.selectProfiles.Text = "Select Profiles";
            this.selectProfiles.UseVisualStyleBackColor = true;
            this.selectProfiles.CheckedChanged += new System.EventHandler(this.selectProfiles_CheckedChanged);
            // 
            // allProfiles
            // 
            this.allProfiles.AutoSize = true;
            this.allProfiles.Checked = true;
            this.allProfiles.Location = new System.Drawing.Point(7, 19);
            this.allProfiles.Name = "allProfiles";
            this.allProfiles.Size = new System.Drawing.Size(79, 17);
            this.allProfiles.TabIndex = 0;
            this.allProfiles.TabStop = true;
            this.allProfiles.Text = "All Profiles";
            this.allProfiles.UseVisualStyleBackColor = true;
            this.allProfiles.CheckedChanged += new System.EventHandler(this.allProfiles_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.extensionList);
            this.groupBox2.Controls.Add(this.selectTypes);
            this.groupBox2.Controls.Add(this.allTypes);
            this.groupBox2.Location = new System.Drawing.Point(170, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Types";
            // 
            // extensionList
            // 
            this.extensionList.Enabled = false;
            this.extensionList.Location = new System.Drawing.Point(28, 44);
            this.extensionList.Name = "extensionList";
            this.extensionList.Size = new System.Drawing.Size(276, 22);
            this.extensionList.TabIndex = 2;
            this.extensionList.Text = "csv,jpg,bmp";
            // 
            // selectTypes
            // 
            this.selectTypes.AutoSize = true;
            this.selectTypes.Location = new System.Drawing.Point(7, 44);
            this.selectTypes.Name = "selectTypes";
            this.selectTypes.Size = new System.Drawing.Size(14, 13);
            this.selectTypes.TabIndex = 1;
            this.selectTypes.UseVisualStyleBackColor = true;
            this.selectTypes.CheckedChanged += new System.EventHandler(this.selectTypes_CheckedChanged);
            // 
            // allTypes
            // 
            this.allTypes.AutoSize = true;
            this.allTypes.Checked = true;
            this.allTypes.Location = new System.Drawing.Point(7, 19);
            this.allTypes.Name = "allTypes";
            this.allTypes.Size = new System.Drawing.Size(69, 17);
            this.allTypes.TabIndex = 0;
            this.allTypes.TabStop = true;
            this.allTypes.Text = "All Types";
            this.allTypes.UseVisualStyleBackColor = true;
            this.allTypes.CheckedChanged += new System.EventHandler(this.allTypes_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.daysOld);
            this.groupBox3.Controls.Add(this.dateCut);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.toDate);
            this.groupBox3.Controls.Add(this.fromDate);
            this.groupBox3.Controls.Add(this.dateRange);
            this.groupBox3.Controls.Add(this.allFiles);
            this.groupBox3.Location = new System.Drawing.Point(170, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 135);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "days since last modified.";
            // 
            // daysOld
            // 
            this.daysOld.Enabled = false;
            this.daysOld.Location = new System.Drawing.Point(97, 108);
            this.daysOld.Name = "daysOld";
            this.daysOld.Size = new System.Drawing.Size(30, 22);
            this.daysOld.TabIndex = 8;
            this.daysOld.Text = "2";
            // 
            // dateCut
            // 
            this.dateCut.AutoSize = true;
            this.dateCut.Location = new System.Drawing.Point(7, 108);
            this.dateCut.Name = "dateCut";
            this.dateCut.Size = new System.Drawing.Size(82, 17);
            this.dateCut.TabIndex = 7;
            this.dateCut.TabStop = true;
            this.dateCut.Text = "More than ";
            this.dateCut.UseVisualStyleBackColor = true;
            this.dateCut.CheckedChanged += new System.EventHandler(this.dateCut_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // toDate
            // 
            this.toDate.Enabled = false;
            this.toDate.Location = new System.Drawing.Point(97, 82);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(207, 22);
            this.toDate.TabIndex = 3;
            this.toDate.ValueChanged += new System.EventHandler(this.toDate_ValueChanged);
            // 
            // fromDate
            // 
            this.fromDate.Enabled = false;
            this.fromDate.Location = new System.Drawing.Point(97, 43);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(207, 22);
            this.fromDate.TabIndex = 2;
            this.fromDate.Value = new System.DateTime(1990, 12, 11, 16, 22, 0, 0);
            this.fromDate.ValueChanged += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // dateRange
            // 
            this.dateRange.AutoSize = true;
            this.dateRange.Location = new System.Drawing.Point(7, 43);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(95, 17);
            this.dateRange.TabIndex = 1;
            this.dateRange.Text = "Last Modified";
            this.dateRange.UseVisualStyleBackColor = true;
            this.dateRange.CheckedChanged += new System.EventHandler(this.dateRange_CheckedChanged);
            // 
            // allFiles
            // 
            this.allFiles.AutoSize = true;
            this.allFiles.Checked = true;
            this.allFiles.Location = new System.Drawing.Point(7, 19);
            this.allFiles.Name = "allFiles";
            this.allFiles.Size = new System.Drawing.Size(64, 17);
            this.allFiles.TabIndex = 0;
            this.allFiles.TabStop = true;
            this.allFiles.Text = "All Files";
            this.allFiles.UseVisualStyleBackColor = true;
            this.allFiles.CheckedChanged += new System.EventHandler(this.allFiles_CheckedChanged);
            // 
            // includeSub
            // 
            this.includeSub.AutoSize = true;
            this.includeSub.Checked = true;
            this.includeSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeSub.Location = new System.Drawing.Point(6, 84);
            this.includeSub.Name = "includeSub";
            this.includeSub.Size = new System.Drawing.Size(237, 17);
            this.includeSub.TabIndex = 6;
            this.includeSub.Text = "Remove Sub Folders and Associated Files";
            this.includeSub.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.simulation);
            this.groupBox4.Controls.Add(this.backupDirectory);
            this.groupBox4.Controls.Add(this.browseBackup);
            this.groupBox4.Controls.Add(this.saveBackup);
            this.groupBox4.Location = new System.Drawing.Point(170, 396);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 81);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backup and Simulation";
            // 
            // simulation
            // 
            this.simulation.AutoSize = true;
            this.simulation.Location = new System.Drawing.Point(152, 55);
            this.simulation.Name = "simulation";
            this.simulation.Size = new System.Drawing.Size(105, 17);
            this.simulation.TabIndex = 3;
            this.simulation.Text = "Run Simulation";
            this.simulation.UseVisualStyleBackColor = true;
            // 
            // backupDirectory
            // 
            this.backupDirectory.Location = new System.Drawing.Point(88, 19);
            this.backupDirectory.Name = "backupDirectory";
            this.backupDirectory.Size = new System.Drawing.Size(216, 22);
            this.backupDirectory.TabIndex = 2;
            this.backupDirectory.Text = "Backup Directory";
            // 
            // browseBackup
            // 
            this.browseBackup.Location = new System.Drawing.Point(6, 19);
            this.browseBackup.Name = "browseBackup";
            this.browseBackup.Size = new System.Drawing.Size(75, 21);
            this.browseBackup.TabIndex = 1;
            this.browseBackup.Text = "Browse";
            this.browseBackup.UseVisualStyleBackColor = true;
            this.browseBackup.Click += new System.EventHandler(this.browseBackup_Click);
            // 
            // saveBackup
            // 
            this.saveBackup.AutoSize = true;
            this.saveBackup.Location = new System.Drawing.Point(7, 55);
            this.saveBackup.Name = "saveBackup";
            this.saveBackup.Size = new System.Drawing.Size(90, 17);
            this.saveBackup.TabIndex = 0;
            this.saveBackup.Text = "Save Backup";
            this.saveBackup.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(170, 513);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(146, 40);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(6, 17);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(325, 471);
            this.logBox.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.logBox);
            this.groupBox5.Location = new System.Drawing.Point(486, 62);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 496);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Log";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.folderList);
            this.groupBox6.Controls.Add(this.selectFolders);
            this.groupBox6.Controls.Add(this.allFolders);
            this.groupBox6.Controls.Add(this.includeSub);
            this.groupBox6.Controls.Add(this.tempFolder);
            this.groupBox6.Location = new System.Drawing.Point(170, 62);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(310, 109);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Folder Select";
            // 
            // folderList
            // 
            this.folderList.Enabled = false;
            this.folderList.Location = new System.Drawing.Point(28, 58);
            this.folderList.Name = "folderList";
            this.folderList.Size = new System.Drawing.Size(276, 22);
            this.folderList.TabIndex = 3;
            this.folderList.Text = "temp,bin,debug";
            // 
            // selectFolders
            // 
            this.selectFolders.AutoSize = true;
            this.selectFolders.Location = new System.Drawing.Point(6, 58);
            this.selectFolders.Name = "selectFolders";
            this.selectFolders.Size = new System.Drawing.Size(14, 13);
            this.selectFolders.TabIndex = 2;
            this.selectFolders.TabStop = true;
            this.selectFolders.UseVisualStyleBackColor = true;
            this.selectFolders.CheckedChanged += new System.EventHandler(this.selectFolders_CheckedChanged);
            // 
            // allFolders
            // 
            this.allFolders.AutoSize = true;
            this.allFolders.Location = new System.Drawing.Point(6, 36);
            this.allFolders.Name = "allFolders";
            this.allFolders.Size = new System.Drawing.Size(79, 17);
            this.allFolders.TabIndex = 1;
            this.allFolders.Text = "All Folders";
            this.allFolders.UseVisualStyleBackColor = true;
            this.allFolders.CheckedChanged += new System.EventHandler(this.allFolders_CheckedChanged);
            // 
            // tempFolder
            // 
            this.tempFolder.AutoSize = true;
            this.tempFolder.Checked = true;
            this.tempFolder.Location = new System.Drawing.Point(6, 17);
            this.tempFolder.Name = "tempFolder";
            this.tempFolder.Size = new System.Drawing.Size(88, 17);
            this.tempFolder.TabIndex = 0;
            this.tempFolder.TabStop = true;
            this.tempFolder.Text = "Temp Folder";
            this.tempFolder.UseVisualStyleBackColor = true;
            this.tempFolder.CheckedChanged += new System.EventHandler(this.tempFolder_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(331, 513);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(149, 40);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(170, 484);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(310, 23);
            this.progressBar.TabIndex = 13;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(89, 34);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(68, 22);
            this.load.TabIndex = 14;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openDialog";
            // 
            // FolderCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(842, 570);
            this.Controls.Add(this.load);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.targetDirectory);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FolderCleaner";
            this.Text = "TPO Folder Cleaner Utility";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox targetDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton selectProfiles;
        private System.Windows.Forms.RadioButton allProfiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox extensionList;
        private System.Windows.Forms.RadioButton selectTypes;
        private System.Windows.Forms.RadioButton allTypes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.RadioButton dateRange;
        private System.Windows.Forms.RadioButton allFiles;
        private System.Windows.Forms.CheckBox includeSub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog targetBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox saveBackup;
        private System.Windows.Forms.Button browseBackup;
        private System.Windows.Forms.FolderBrowserDialog backupBrowserDialog;
        private System.Windows.Forms.CheckBox simulation;
        private System.Windows.Forms.TextBox backupDirectory;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox daysOld;
        private System.Windows.Forms.RadioButton dateCut;
        private System.Windows.Forms.ListBox profileListBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox folderList;
        private System.Windows.Forms.RadioButton selectFolders;
        private System.Windows.Forms.RadioButton allFolders;
        private System.Windows.Forms.RadioButton tempFolder;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;

    }
}

