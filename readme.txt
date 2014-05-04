TPO Folder Cleaner Utility
******************************************

.NET C# WinForms

A utility for cleaning up temporary/unused files/folders from profiles (organized as folders in a directory) 
Configurations can be imported/exported to XML and used for batch jobs in Command Line interface.
 
GENERAL USAGE: 

1. Select Directory
2. Select all / individual profiles (folders in selected directory)
3. Select temporary / all / command seperated folders to scan for files
4. Select file types/ date range
5. Setup backup options/ simulation 
6. Start

IMPORT/EXPORT:

Under File > Import/Export your configuration settings
Saved configuration settings can be used for batch
cleanup in command line.

BATCH JOBS:

Using command prompt, execute FolderCleaner.exe
with an argument containing the path of the
configuration file set in the GUI.

ex. Foldercleaner.exe C:\ConfigFile.xml


