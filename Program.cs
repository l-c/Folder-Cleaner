using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FolderCleaner
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;


        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            StringBuilder sb = new StringBuilder();
            foreach (string a in args)
            {
                sb.Append(a);
                sb.Append(" ");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FolderCleaner(sb.ToString()));
        }
    }
}
