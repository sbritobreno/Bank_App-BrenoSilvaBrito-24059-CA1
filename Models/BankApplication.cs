//Breno Silva Brito
//ID: 24059

using BankApp.Models;
using CA1.Models;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BankApp
{
    public partial class BankApplication : Form 
    {
        public BankApplication()
        {
            InitializeComponent();
        }

        public void CustomersListFile()
        {
            //Creates a new file only if it does not exist

            string path = "C:/BankApp/Accounts/.CustomersFile.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }            
        }

        private void BankApplication_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeBTN(object sender, EventArgs e)
        {
            this.Close();
            Thread t1 = new Thread(OpenEmployeeWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void OpenEmployeeWindow()
        {
            Application.Run(new Employee());
        }

        private void CustomerBTN(object sender, EventArgs e)
        {
            this.Close();
            Thread t1 = new Thread(OpenCustomerWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void OpenCustomerWindow()
        {
            Application.Run(new Customer());
        }
    }
}
