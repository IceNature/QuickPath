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
            Paths = new List<string>();
            string EnvironmentPaths = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
            Paths.AddRange(EnvironmentPaths.Split(new char[] {';'}));
        }

        public void ApplyChange()
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
