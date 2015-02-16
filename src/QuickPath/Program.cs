using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuickPath
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string currentCulture = System.Globalization.CultureInfo.InstalledUICulture.Name;
            if (currentCulture == "zh-CHT" || currentCulture == "zh-MO" || currentCulture == "zh-TW" || currentCulture == "zh-HK")
                currentCulture = "zh-Hant";
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(currentCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
