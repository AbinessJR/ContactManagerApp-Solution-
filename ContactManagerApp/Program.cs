using System;
using System.Windows.Forms;

namespace ContactManagerApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of your main form (Form1 in this case) and run it.
            Application.Run(new Form1());
        }
    }
}
