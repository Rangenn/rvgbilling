using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVGBilling;

namespace RVGBilling
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
