using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace RVGBilling
{
    public class Controller
    {
        FormMain formMain;

        public Controller()
        {
            logger.log("Creating Controller...");
            formMain = new FormMain(this);
            formMain.Show();
            logger.log("Controller Created.");
        }
        
        public FormMain fmMain
        {
            get { return formMain; }
        }
    }
}
