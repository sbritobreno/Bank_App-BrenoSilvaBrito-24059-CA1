//Breno Silva Brito
//ID:24059

using BankApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CA1.Models
{
    public partial class CurrentTransactionHistory : Form
    {
        public string AccountNumber { get; set; }

        public CurrentTransactionHistory(string accountNumber)
        {
            AccountNumber = accountNumber;
            InitializeComponent();
        }

        private void CurrentTransactionHistory_Load(object sender, EventArgs e)
        {
            List<string> Accounts = new List<string>();
            string path = $"C:/BankApp/Accounts/{AccountNumber}_current.txt";
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
    }
}
