//Breno Silva Brito
//ID:24059

using BankApp;
using BankApp.Models;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CA1.Models
{
    public partial class ExecTransaction : Form
    {
        public string AccountNumber { get; set; }

        public ExecTransaction()
        {
            InitializeComponent();
        }

        private void ExecCustomerTransaction_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CurrentBTN(object sender, EventArgs e)
        {
            AccountNumber = textBox1.Text;
            string currentFilePath = $"C:/BankApp/Accounts/{AccountNumber}_current.txt";

            if (!File.Exists(currentFilePath))
            {
                MessageBox.Show("Account does not exist");
            }
            else
            {
                this.Close();
                Thread t1 = new Thread(OpenCurrentTransactionWindow);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }

        private void OpenCurrentTransactionWindow()
        {
            Application.Run(new CurrentTransaction(AccountNumber));
        }

        private void SavingBTN(object sender, EventArgs e)
        {
            AccountNumber = textBox1.Text;
            string savingFilePath = $"C:/BankApp/Accounts/{AccountNumber}_saving.txt";

            if (!File.Exists(savingFilePath))
            {
                MessageBox.Show("Account does not exist");
            }
            else
            {
                this.Close();
                Thread t1 = new Thread(OpenSavingTransactionWindow);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }

        private void OpenSavingTransactionWindow()
        {
            Application.Run(new SavingTransaction(AccountNumber));
        }

        private void HomeBTN(object sender, EventArgs e)
        {
            this.Close();
            Thread t2 = new Thread(BackToLoginPage);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }

        private void BackToLoginPage()
        {
            Application.Run(new BankApplication());
        }     
    }
}
