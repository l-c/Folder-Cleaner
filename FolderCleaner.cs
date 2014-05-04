using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

namespace FolderCleaner
{
    public partial class FolderCleaner : Form
    {
        public BackgroundWorker bgw;
        public Cleaner fc;
        public bool console = false;

        public FolderCleaner(string s)
        {
            InitializeComponent();
            if (s.Length > 0)
            {
                this.Opacity = 0;
                console = true;

                if (File.Exists(s))
                {
                    if (importLoader(s))
                    {

                        if (!Directory.Exists(targetDirectory.Text))
                        {
                            Console.WriteLine();
                            Console.WriteLine("******************************");
                            Console.WriteLine("* Target Directory Not Found *");
                            Console.WriteLine("******************************");
                            Environment.Exit(0);
                        }
                        else if (saveBackup.Checked && !Directory.Exists(backupDirectory.Text))
                        {
                            Console.WriteLine();
                            Console.WriteLine("******************************");
                            Console.WriteLine("* Backup Directory Not Found *");
                            Console.WriteLine("******************************");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("*****************");
                            Console.WriteLine("* Starting Task *");
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            ExecuteWork();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("*******************************");
                        Console.WriteLine("* Error in Configuration FIle *");
                        Console.WriteLine("*******************************");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("******************");
                    Console.WriteLine("* File Not Found *");
                    Console.WriteLine("******************");
                    Console.WriteLine("** PATH: " + s);
                    Environment.Exit(0);
                }

            }
        }

        public void UpdateBox(string s)
        {
            logBox.Text += s + Environment.NewLine;
        }

        public void ExecuteWork()
        {
            progressBar.Value = 0;
            logBox.Clear();
            logBox.Text += "Starting Task..." + Environment.NewLine;
            startButton.Enabled = false;
            cancelButton.Enabled = true;
            Application.DoEvents();

            fc = new Cleaner();
            fc.RootDirectory = targetDirectory.Text;

            var p = profileLoader();
            folderLoader(p);
            fileTypeLoader();
            dateLoader();
            BackupSimulationLoader();

            RunBackgroundTask();
        }

        private void RunBackgroundTask()
        {
            bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += bgw_ProgressChanged;
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted += bgw_Complete;
            bgw.RunWorkerAsync();
        }

        private void BackupSimulationLoader()
        {
            if (saveBackup.Checked)
            {
                fc.Backup = true;
                var dt = DateTime.Now;
                fc.BackupDirectory = backupDirectory.Text + "//Backup " + dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.Hour + "-" + dt.Minute + "-" + dt.Second;
            }

            if (simulation.Checked) fc.Simulation = true;
            else fc.Simulation = false;
        }

        #region Cleaner Object Loaders

        private List<string> profileLoader()
        {
            var p = new List<string>();
            if (allProfiles.Checked)
            {
                foreach (KeyValuePair<string, string> s in profileListBox.Items)
                {
                    p.Add(s.Value);
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> s in profileListBox.SelectedItems)
                {
                    p.Add(s.Value);
                }
            }

            if (p != null) fc.Profiles = p.ToArray();
            return p;
        }

        private void dateLoader()
        {
            if (dateRange.Checked)
            {
                fc.FromDate = new DateTime(fromDate.Value.Year, fromDate.Value.Month, fromDate.Value.Day,0,0,0);
                fc.ToDate = new DateTime(toDate.Value.Year, toDate.Value.Month, toDate.Value.Day,23,59,59);
            }

            else if (dateCut.Checked)
            {
                int days = Convert.ToInt32(daysOld.Text) * -1;
                fc.FromDate = DateTime.Today.AddYears(-100);
                if (days != 0)
                {
                    fc.ToDate = DateTime.Today.AddDays(days);
                }
                else fc.ToDate = DateTime.Now;
            }
            else if (allFiles.Checked)
            {
                fc.FromDate = DateTime.Today.AddYears(-100);
                fc.ToDate = DateTime.Now;
            }
        }

        private void fileTypeLoader()
        {
            if (allTypes.Checked) fc.AllTypes = true;
            else if (selectTypes.Checked) fc.Types = listParser(extensionList.Text).ToArray();
        }

        private void folderLoader(List<string> p)
        {
            if (tempFolder.Checked) fc.Folders = new string[] { "temp" };

            else if (allFolders.Checked)
            {
                var af = new List<string>();
                foreach (string f in p)
                {
                    try
                    {
                        string[] s = Directory.GetDirectories(f);
                        foreach (string x in s)
                        {
                            af.Add(x.Remove(0, f.Length + 1));
                        }
                    }
                    catch (Exception ex) { }
                }
                fc.Folders = af.ToArray();
            }

            else if (selectFolders.Checked) fc.Folders = listParser(folderList.Text).ToArray();

            if (includeSub.Checked) fc.SubFolder = true;
            else fc.SubFolder = false;
        }

        private List<string> listParser(string s)
        {
            return s.Split(',').ToList<string>();
        }

        #endregion

        #region Directory Loader

        private void browse_Click(object sender, EventArgs e)
        {
            targetBrowserDialog.ShowDialog();
            targetDirectory.Text = targetBrowserDialog.SelectedPath;

            if (Directory.Exists(targetBrowserDialog.SelectedPath))
            {
                loadHelper(targetBrowserDialog.SelectedPath);
            }
            else MessageBox.Show("Unable to Access Directory.");
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(targetDirectory.Text))
            {
                loadHelper(targetDirectory.Text);
            }
            else MessageBox.Show("Unable to Access Directory.");
        }

        private void targetDirectory_lostFocus(object sender, EventArgs e)
        {
            load_Click(sender, e);
        }

        private void loadHelper(string directory)
        {
            if (Directory.Exists(directory))
            {
                string[] profiles = Directory.GetDirectories(directory);
                var pList = new Dictionary<string, string>();

                foreach (string p in profiles)
                {
                    int i = p.LastIndexOf("\\");
                    pList.Add(p.Remove(0, i + 1), p);
                }

                if (profiles.Length > 0)
                {
                    profileListBox.DataSource = new BindingSource(pList, null);
                    profileListBox.DisplayMember = "Key";
                    profileListBox.ValueMember = "Value";
                }
                else profileListBox.DataSource = new List<string>();
            }
            else
            {
                if (console)
                {
                    Console.WriteLine();
                    Console.WriteLine("Unable to Load Profiles: " + directory);
                }
                else MessageBox.Show("Unable to Load Profiles");
            }
        }

        #endregion

        #region UI Event Handlers

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(targetDirectory.Text))
            {
                MessageBox.Show("Please select a target directory.");
            }
            else if (saveBackup.Checked && !Directory.Exists(backupDirectory.Text))
            {
                MessageBox.Show("Please select a backup directory.");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to start?", "Execute", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ExecuteWork();
                }
            }

        }

        private void selectProfiles_CheckedChanged(object sender, EventArgs e)
        {
            if (selectProfiles.Checked)
            {
                profileListBox.Enabled = true;
            }
        }

        private void dateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (dateRange.Checked)
            {
                fromDate.Enabled = true;
                toDate.Enabled = true;
                daysOld.Enabled = false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TPO File Cleanup Utility. 2013 Created by Leslie Chan");
        }

        private void dateCut_CheckedChanged(object sender, EventArgs e)
        {
            if (dateCut.Checked)
            {
                daysOld.Enabled = true;
                fromDate.Enabled = false;
                toDate.Enabled = false;
            }
        }

        private void allFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (allFiles.Checked)
            {
                daysOld.Enabled = false;
                fromDate.Enabled = false;
                toDate.Enabled = false;
            }
        }

        private void allProfiles_CheckedChanged(object sender, EventArgs e)
        {
            if (allProfiles.Checked)
            {
                profileListBox.Enabled = false;
            }
        }

        private void allTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (allTypes.Checked)
            {
                extensionList.Enabled = false;
            }
        }

        private void selectTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (selectTypes.Checked)
            {
                extensionList.Enabled = true;
            }
        }

        private void tempFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (tempFolder.Checked)
            {
                folderList.Enabled = false;
            }
        }

        private void allFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (allFolders.Checked)
            {
                folderList.Enabled = false;
            }
        }

        private void selectFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (selectFolders.Checked)
            {
                folderList.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void browseBackup_Click(object sender, EventArgs e)
        {
            backupBrowserDialog.ShowDialog();
            backupDirectory.Text = backupBrowserDialog.SelectedPath;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            bgw.CancelAsync();
        }

        private void toDate_ValueChanged(object sender, EventArgs e)
        {
            if (fromDate.Value > toDate.Value) fromDate.Value = toDate.Value;
        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (fromDate.Value > toDate.Value) toDate.Value = fromDate.Value;
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tutorial = new Tutorial();
            tutorial.Show();
        }

        #endregion

        #region Background Threads

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!bgw.CancellationPending)
            {
                string log = fc.ExecuteDelete(bgw);
                e.Result = log;
            }
            if (bgw.CancellationPending) e.Cancel = true;
        }

        private void bgw_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
                FileInfo fiLatest = directory.GetFiles().OrderByDescending(fi => fi.CreationTime).First();
                string file = Path.GetFileName(fiLatest.FullName);

                if (!console)
                {                 
                    logBox.Text += File.ReadAllText(file);
                    logBox.SelectionStart = logBox.Text.Length;
                    logBox.ScrollToCaret();
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    MessageBox.Show("Cancelled");
                }
                else
                {
                    using (StreamReader tr = new StreamReader(fiLatest.FullName))
                    {
                        string line; 
                        while((line = tr.ReadLine()) != null)
                        {
                        Console.WriteLine(line);
                        }
                    }
                }
            }
            else
            {
                if (!console)
                {
                    progressBar.Value = 100;
                    logBox.Text += File.ReadAllText(e.Result.ToString()) + Environment.NewLine;
                    logBox.SelectionStart = logBox.Text.Length;
                    logBox.ScrollToCaret();
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    MessageBox.Show("Complete");
                }
                else
                {
                    using (StreamReader tr = new StreamReader(e.Result.ToString()))
                    {
                        string line;
                        while ((line = tr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    
                }
            }
            Console.WriteLine();
            Console.WriteLine("*****************");
            Console.WriteLine("*   Finished    *");
            Console.WriteLine("*****************");

            DirectoryInfo dx = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo fx = dx.GetFiles().OrderByDescending(fi => fi.CreationTime).First();
            string final = Path.GetFullPath(fx.FullName);

            Console.WriteLine("** LOGFILE: " + final);

            if (console) Application.Exit();
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 100)
                progressBar.Value = 100;
            else if (e.ProgressPercentage < 0)
                progressBar.Value = 0;
            else
            {
                progressBar.Value = e.ProgressPercentage;
                Console.Write("*");
            }
        }

        #endregion 

        #region Import/Export

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(targetDirectory.Text))
            {
                MessageBox.Show("Please select a target directory.");
            }
            else if (saveBackup.Checked && !Directory.Exists(backupDirectory.Text))
            {
                MessageBox.Show("Please select a backup directory.");
            }
            else
            {
                saveDialog.Filter = "XML (*.xml)|*.xml";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlTextWriter textWriter = new XmlTextWriter(saveDialog.FileName, null);

                    textWriter.WriteStartDocument();
                    textWriter.WriteStartElement("config", "");

                    textWriter.WriteStartElement("targetDirectory", "");
                    textWriter.WriteString(targetDirectory.Text);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("profileSelection", "");
                    if (allProfiles.Checked)
                    {
                        textWriter.WriteString("all");
                        textWriter.WriteEndElement();
                    }
                    else if (selectProfiles.Checked)
                    {
                        textWriter.WriteString("select");
                        textWriter.WriteEndElement();
                        foreach (KeyValuePair<string, string> s in profileListBox.SelectedItems)
                        {
                            textWriter.WriteStartElement("profile", "");
                            textWriter.WriteString(s.Value);
                            textWriter.WriteEndElement();
                        }
                    }

                    textWriter.WriteStartElement("folderSelection", "");
                    if (tempFolder.Checked) textWriter.WriteString("temp");
                    if (allFolders.Checked) textWriter.WriteString("all");
                    if (selectFolders.Checked) textWriter.WriteString(folderList.Text);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("includeSubfolders", "");
                    if (includeSub.Checked) textWriter.WriteString("true");
                    else textWriter.WriteString("false");
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("fileTypes", "");
                    if (allTypes.Checked) textWriter.WriteString("all");
                    if (selectTypes.Checked) textWriter.WriteString(extensionList.Text);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("fileSelection", "");
                    if (allFiles.Checked) textWriter.WriteString("all");
                    textWriter.WriteEndElement();

                    if (dateRange.Checked)
                    {
                        textWriter.WriteStartElement("fromDate", "");
                        var fd = new DateTime(fromDate.Value.Year, fromDate.Value.Month, fromDate.Value.Day);
                        textWriter.WriteString(fd.ToString());
                        textWriter.WriteEndElement();
                        var td = new DateTime(toDate.Value.Year, toDate.Value.Month, toDate.Value.Day);
                        textWriter.WriteStartElement("toDate", "");
                        textWriter.WriteString(td.ToString());
                        textWriter.WriteEndElement();
                    }
                    if (dateCut.Checked)
                    {
                        textWriter.WriteStartElement("dateCut", "");
                        textWriter.WriteString(daysOld.Text);
                        textWriter.WriteEndElement();
                    }

                    textWriter.WriteStartElement("backup", "");
                    if (!saveBackup.Checked)
                    {
                        textWriter.WriteString("false");
                        textWriter.WriteEndElement();
                    }
                    else
                    {
                        textWriter.WriteString("true");
                        textWriter.WriteEndElement();
                        textWriter.WriteStartElement("backupDirectory", "");
                        textWriter.WriteString(backupDirectory.Text);
                        textWriter.WriteEndElement();
                    }

                    textWriter.WriteStartElement("simulation", "");
                    if (simulation.Checked) textWriter.WriteString("true");
                    else textWriter.WriteString("false");
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();
                    textWriter.WriteEndDocument();
                    textWriter.Close();
                }
            }

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "XML (*.xml)|*.xml";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if (!importLoader(openDialog.FileName)) MessageBox.Show("Error in Configuration File");
            }
        }

        public bool importLoader(string s)
        {
            XmlTextReader textReader = new XmlTextReader(s);
            string temp;
            try
            {
                while (textReader.Read())
                {
                    if (textReader.IsStartElement())
                    {

                        if (textReader.Name == "targetDirectory")
                        {
                            temp = textReader.ReadString();
                            targetDirectory.Text = temp;
                            loadHelper(temp);
                        }
                        else if (textReader.Name == "profileSelection")
                        {
                            temp = textReader.ReadString();
                            if (temp == "all") allProfiles.Checked = true;
                            else
                            {
                                selectProfiles.Checked = true;
                                profileListBox.ClearSelected();
                            }
                        }
                        else if (textReader.Name == "profile")
                        {
                            temp = textReader.ReadString();
                            int i = temp.LastIndexOf("\\");
                            int index = profileListBox.FindString(temp.Remove(0, i + 1));
                            if (index >= 0) profileListBox.SetSelected(index, true);
                        }
                        else if (textReader.Name == "folderSelection")
                        {
                            temp = textReader.ReadString();
                            if (temp == "temp") tempFolder.Checked = true;
                            else if (temp == "all") allFolders.Checked = true;
                            else
                            {
                                selectFolders.Checked = true;
                                folderList.Text = temp;
                            }
                        }
                        else if (textReader.Name == "includeSubfolders")
                        {
                            temp = textReader.ReadString();
                            if (temp == "true") includeSub.Checked = true;
                            else includeSub.Checked = false;
                        }
                        else if (textReader.Name == "fileTypes")
                        {
                            temp = textReader.ReadString();
                            if (temp == "all") allTypes.Checked = true;
                            else
                            {
                                selectTypes.Checked = true;
                                extensionList.Text = temp;
                            }
                        }
                        else if (textReader.Name == "fileSelection")
                        {
                            temp = textReader.ReadString();
                            if (temp == "all") allFiles.Checked = true;
                        }
                        else if (textReader.Name == "fromDate")
                        {
                            dateRange.Checked = true;
                            fromDate.Value = Convert.ToDateTime(textReader.ReadString());
                        }
                        else if (textReader.Name == "toDate")
                        {
                            dateRange.Checked = true;
                            toDate.Value = Convert.ToDateTime(textReader.ReadString());
                        }
                        else if (textReader.Name == "dateCut")
                        {
                            dateCut.Checked = true;
                            daysOld.Text = textReader.ReadString();
                        }
                        else if (textReader.Name == "backup")
                        {
                            temp = textReader.ReadString();
                            if (temp == "false") saveBackup.Checked = false;
                        }
                        else if (textReader.Name == "backupDirectory")
                        {
                            saveBackup.Checked = true;
                            backupDirectory.Text = textReader.ReadString();
                        }
                        else if (textReader.Name == "simulation")
                        {
                            temp = textReader.ReadString();
                            if (temp == "true") simulation.Checked = true;
                            else simulation.Checked = false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                textReader.Close();
            }
        }

        #endregion
        

    }
}
