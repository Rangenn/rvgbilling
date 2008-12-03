using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RVGbilling
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.log("-");
            logger.log("Application started.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller ctrl = new Controller();
            Application.Run(ctrl.fmMain);
            logger.log("Application closed.");
        }
    }
}
