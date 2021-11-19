//Breno Silva Brito
//ID:24059

using BankApp;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CA1.Models
{
    public partial class SavingTransactionHistory : Form
    {
        public string AccountNumber { get; set; }

        public SavingTransactionHistory(string accountNumber)
        {
            AccountNumber = accountNumber;
            InitializeComponent();
        }

        private void SavingTransactionHistory_Load(object sender, EventArgs e)
        {
            string path = $"C:/BankApp/Accounts/{AccountNumber}_saving.txt";
            string line;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }
        }

        private void HomeBTN(object sender, EventArgs e)
        {
            this.Close();
            Thread t1 = new Thread(BackToLoginPage);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void BackToLoginPage()
        {
            Application.Run(new BankApplication());
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
