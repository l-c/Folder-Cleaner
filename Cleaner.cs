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

namespace FolderCleaner
{
    public class Cleaner
    {
        #region

        public string RootDirectory { get; set; }
        public string[] Profiles { get; set; }
        public string[] Folders { get; set; }
        public string[] Types { get; set; }
        public bool AllTypes { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool SubFolder { get; set; }
        public bool Backup { get; set; }
        public string BackupDirectory { get; set; }
        public bool Simulation { get; set; }
        public Object Updater { get; set; }
        public BackgroundWorker bgw { get; set; }
        public double totalCount { get; set; }
        public double Counter { get; set; }
        public double FileSize { get; set; }
        public string LogFile { get; set; }

        #endregion

        public string ExecuteDelete(BackgroundWorker bg)
        {
            Counter = 0;
            totalCount = 0;
            bgw = bg;

            LogFile = DateTime.Now.ToString("MM-dd-yyyy HHmmsstt") + ".txt";

            while (File.Exists(LogFile))
            {
                LogFile = DateTime.Now.ToString("MM-dd-yyyy HHmmsstt") + ".txt";
            }
            TextWriter tw = new StreamWriter(LogFile);

            tw.WriteLine("Execute Delete: " + DateTime.Now.ToString());
            tw.WriteLine("Root Directory: " + RootDirectory);
            tw.Write("Folders to be cleaned: ");
            foreach (string f in Folders)
            {
                tw.Write(f + " ");
            }
            tw.WriteLine();
            tw.WriteLine();
            tw.Close();

            // 
            // Load all folders in select profiles for deletion
            //

            var folderUpdate = new List<string>();
            foreach (string f in Folders)
            {
                foreach (string p in Profiles)
                {
                    folderUpdate.Add(p + "/" + f + "/");
                }
            }
            Profiles = folderUpdate.ToArray();

            //
            // Scan directory to collect deletion information
            //

            foreach (string p in Profiles)
            {
                if (Directory.Exists(p))
                {
                    try
                    {
                        if (!SubFolder) FileCount(p);
                        else GetDirectoryFileCount(p);
                    }
                    catch (Exception ex)
                    {
                        AccessDirectoryError(ex);
                    }
                }
            }

            //
            // Execute Deletion
            //

            foreach (string profile in Profiles)
            {
                if (Directory.Exists(profile))
                {
                    try
                    {
                        if (Backup) BackupHelper(profile);
                        DeleteFiles(Directory.GetFiles(profile));
                        if (SubFolder)
                        {
                            string[] p = Directory.GetDirectories(profile);
                            DeleteDirectories(p);
                        }
                    }
                    catch (Exception ex)
                    {
                        AccessDirectoryError(ex);
                    }
                }
            }

            TextWriter fw = File.AppendText(LogFile);

            fw.WriteLine("---------------------------------------------");
            fw.WriteLine("# Files Removed: " + Counter);
            fw.WriteLine("Space Cleaned: " + Math.Round((FileSize / (1024 * 1024)), 2) + " MB");

            if (Simulation) fw.WriteLine("** SIMULATION ONLY **");
            if (bgw.CancellationPending) fw.WriteLine("Operation Terminated.");
            else fw.WriteLine("Task Complete.");
            fw.Close();
            return LogFile;
        }

        private void AccessDirectoryError(Exception ex)
        {
            TextWriter tx = File.AppendText(LogFile);
            tx.WriteLine("Error Accessing Directory [" + ex.Message + "]");
            tx.Close();
        }

        #region Backup Methods

        private void BackupHelper(string profile)
        {
            if(!Directory.Exists(BackupDirectory)) Directory.CreateDirectory(BackupDirectory);
            DirectoryInfo source = new DirectoryInfo(profile);
            string backupDirectory = BackupDirectory + "\\" + source.Parent + "\\" + source.Name;
            DirectoryInfo target = new DirectoryInfo(backupDirectory);
            CopyAll(source, target);
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it. 
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory. 
            try
            {
                foreach (FileInfo fi in source.GetFiles())
                {
                    if (bgw.CancellationPending) break;
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                }
            }
            catch (Exception ex)
            {
            }

            // Copy each subdirectory using recursion. 
            try
            {
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion 

        #region Deletion Methods

        //
        // Recursively delete files in profiles
        //

        public void DeleteDirectories(string[] directories)
        {
            foreach (string directory in directories)
            {
                try
                {
                    string[] files = Directory.GetFiles(directory);
                    DeleteFiles(files);
                    directories = Directory.GetDirectories(directory);
                    DeleteDirectories(directories);

                    List<string> directLog = new List<string>();

                    if (!Directory.EnumerateFileSystemEntries(directory).Any())
                    {
                        try
                        {
                            if (bgw.CancellationPending) break;
                            if (!Simulation) Directory.Delete(directory);
                            Counter++;
                            double c = (Counter / totalCount) * 100;
                            bgw.ReportProgress((int)c);
                        }
                        catch (Exception e)
                        {
                            directLog.Add("Error Deleting Directory [" + e.Message + "]");
                            Counter++;
                            double c = (Counter / totalCount) * 100;
                            bgw.ReportProgress((int)c); ;
                        }
                    }

                    TextWriter tw = File.AppendText(LogFile);
                    foreach (string l in directLog)
                    {
                        tw.WriteLine(l);
                    }
                    tw.Close();
                }
                catch (Exception ex)
                {
                    AccessDirectoryError(ex);
                }

            }
        }

        public void DeleteFiles(string[] files)
        {
            var fileLog = new List<string>();

            foreach (string file in files)
            {
                if (bgw.CancellationPending) break;
                var f = new FileInfo(file);

                if (f.LastWriteTime >= FromDate && f.LastWriteTime <= ToDate)
                {
                    if (!AllTypes)
                    {
                        foreach (var ext in Types)
                        {
                            if (Path.GetExtension(f.Name).Equals("." + ext, StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (bgw.CancellationPending) break;
                                fileLog.Add(DeleteHelper(f));
                            }
                        }
                    }
                    else
                    {
                        if (bgw.CancellationPending) break;
                        fileLog.Add(DeleteHelper(f));
                    }
                }
            }

            TextWriter tw = File.AppendText(LogFile);
            foreach (string l in fileLog)
            {
                tw.WriteLine(l);
            }
            tw.Close();

        }

        public string DeleteHelper(FileInfo f)
        {
            try
            {
                if (!Simulation) f.Delete();
                FileSize += f.Length;
                Counter++;
                double c = (Counter / totalCount) * 100;
                bgw.ReportProgress((int)c);
                return f.FullName;
            }
            catch (Exception e)
            {
                Counter++;
                double c = (Counter / totalCount) * 100;
                bgw.ReportProgress((int)c);
                return "Error Deleting File [" + e.Message + "]: " + f.FullName;
            }
        }  

        #endregion

        #region File Metric Methods

        //
        // Recursively access directory structure to obtain file count / size
        //

        public void FileCount(string dir)
        {
            dir = dir + @"\";
            try
            {
                String[] all_files = Directory.GetFileSystemEntries(dir);
                foreach (string file in all_files)
                {
                    if (bgw.CancellationPending) break;
                    FileCountHelper(file);
                }
            }
            catch (Exception ex) { }
        }

        public void GetDirectoryFileCount(string dir)
        {
            dir = dir + @"\";
            try
            {
                String[] all_files = Directory.GetFileSystemEntries(dir);
                foreach (string file in all_files)
                {
                    if (Directory.Exists(file))
                    {
                        GetDirectoryFileCount(file);
                    }
                    else
                    {
                        if (bgw.CancellationPending) break;
                        FileCountHelper(file);
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void FileCountHelper(string file)
        {
            var f = new FileInfo(file);
            if (f.LastWriteTime >= FromDate && f.LastWriteTime <= ToDate)
            {
                if (!AllTypes)
                {
                    foreach (var ext in Types)
                    {
                        if (Path.GetExtension(f.Name).Equals("." + ext, StringComparison.InvariantCultureIgnoreCase)) totalCount++;
                    }
                }
                else totalCount++;
            }
        }
        #endregion

    }
}
