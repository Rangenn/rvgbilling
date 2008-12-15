using System;
using System.Collections.Generic;
using System.Text;

using RVGlib.Framework;

namespace RVGBilling
{
    public class Controller
    {
        FormMain formMain;
        FormAbonent formAbonent;
        DBConnector connector;

        public Controller()
        {
            logger.log("Creating Controller...");
            connector = new DBConnector();
            //formMain = new FormMain(this);
            //formMain.Show();
            Int64 id=5;
            formAbonent = new FormAbonent(this,id);
            formAbonent.Show();
            logger.log("Controller Created.");

        }
        
        public FormMain fmMain
        {
            get { return formMain; }
        }

        public FormAbonent fmAbonent
        {
            get { return formAbonent; }
        }

        public DBConnector conn
        {
            get { return connector; }
        }
    }
}
