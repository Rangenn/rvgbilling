using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling
{
    public class Controller
    {
        private FormMain formMain;

        public Controller()
        {
            formMain = new FormMain(this);
            formMain.Show();
        }

        public void AddPerson(string name, string passport, string phone)
        {
            throw new System.NotImplementedException();
        }

        public void/*PersonCollection*/ SearchPerson(string name, string passport, string phone)
        {
            throw new System.NotImplementedException();
        }

        public void SelectPerson(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SelectCorporate(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddCorporate(string name, string address, string phone)
        {
            throw new System.NotImplementedException();
        }

        public void/*CorporateCollection*/ SearchCoporate(string name, string address, string phone)
        {
            throw new System.NotImplementedException();
        }

        public void Payment(string phone, decimal summa)
        {
            throw new System.NotImplementedException();
        }

        public FormMain fmMain
        {
            get { return formMain; }
        }
    }
}
