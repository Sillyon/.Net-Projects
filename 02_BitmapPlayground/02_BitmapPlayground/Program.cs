using System;
using System.Windows.Forms;

/// <author>Fatih Çomak</author>
/// <date>12.04.2020</date>
/// <time>21:15 (GMT+3)</time>

namespace _02_BitmapPlayground
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
