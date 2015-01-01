using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickPath
{
    class EnvironmentPath
    {
        public List<string> Paths { get; private set; }
        public EnvironmentPath()
        {
            try
            {
                Paths = new List<string>();
                string EnvironmentPaths = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                Paths.AddRange(EnvironmentPaths.Split(new char[] { ';' }));
            }
            catch(Exception e)
            {
                onException(e.Message + Properties.Resources.MessageBoxErrorReadPATH);
            }
        }

        public void ApplyChange()
        {
            try
            {
                StringBuilder ChangedPATH = new StringBuilder();
                foreach (string m in Paths)
                {
                    ChangedPATH.Append(m);
                    ChangedPATH.Append(";");
                }
                ChangedPATH.Remove(ChangedPATH.Length - 1, 1);
                Environment.SetEnvironmentVariable("PATH", ChangedPATH.ToString(), EnvironmentVariableTarget.Machine);
            }
            catch(Exception e)
            {
                onException(e.Message + Properties.Resources.MessageBoxErrorWritePATH);
            }
        }
        private void onException(string message)
        {
            MessageBox.Show(message, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
    static class CommonMethods
    {
        static public List<string> DeleteInexistentDir(string[] directorys)
        {
            List<string> result = new List<string>();
            foreach (string dir in directorys)
                if (Directory.Exists(dir))
                    result.Add(dir);
            return result;
        }    
    }
}
