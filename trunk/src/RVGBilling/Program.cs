using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVGBilling;
using RVGlib.Framework;

namespace RVGBilling
{
    /// <summary>
    /// Program Startup Class
    /// </summary>
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
            try
            {
                Controller ctrl = new Controller();
                Application.Run(ctrl.fmMain);
            }
            catch (EstablishConnectionException ex) { MessageBox.Show(ex.Message); }            
            logger.log("Application closed.");
        }
    }
}
