//Breno Silva Brito
//ID: 24059

using BankApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CA1.Models
{
    public partial class Customer : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void EnterBTN(object sender, EventArgs e)
        {
            List<string> Accounts = new List<string>();
            FirstName = textBox1.Text.ToUpper();
            LastName = textBox2.Text.ToUpper();
            AccountNumber = textBox3.Text.ToUpper();
            PinCode = textBox4.Text.ToUpper();

            string accountDetails = $"{FirstName}\t{LastName}\t{AccountNumber}\t{PinCode}";   //Creates a string that suppose to exist in the Customer's list file

            string path = "C:/BankApp/Accounts/.CustomersFile.txt";
            string line;

            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                        Accounts.Add(line);
                }
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("All the TextBox must be filled up");
            }
            else if(!Accounts.Contains(accountDetails))    //Check if the accountDetails string exists in the file
            {
                MessageBox.Show("Account does not exist, please check all the text boxes");
            }
            else
            {
                this.Close();
                Thread t1 = new Thread(OpenExecTransactionWindow);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }

        private void OpenExecTransactionWindow()
        {
            Application.Run(new ExecTransaction());
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
