//Breno Silva Brito
//ID:24059

using System;
using System.Windows.Forms;
using System.Threading;
using CA1.Models;

namespace BankApp.Models
{
    public partial class EmployeeTasks : Form
    {
        Thread t1;

        public EmployeeTasks()
        {
            InitializeComponent();
        }

        private void EmployeeTasks_Load(object sender, EventArgs e)
        {

        }

        private void CreateAccountBTN(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(OpenNewAccountWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void OpenNewAccountWindow()
        {
            Application.Run(new NewAccount());
        }

        private void DeleteAccountBTN(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(OpenDelAccountWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void OpenDelAccountWindow()
        {
            Application.Run(new DeleteAccount());
        }

        private void TransactionBTN(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(OpenExecCustomerTransactionWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void OpenExecCustomerTransactionWindow()
        {
            Application.Run(new ExecTransaction());
        }

        private void CustomerListBTN(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(OpenCustomerListWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void OpenCustomerListWindow()
        {
            Application.Run(new CustomerList());
        }

        private void HomeBTN(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(BackToLoginPage);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void BackToLoginPage()
        {
            Application.Run(new BankApplication());
        }
    }
}
