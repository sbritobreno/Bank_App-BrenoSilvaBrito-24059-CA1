//Breno Silva Brito
//ID:24059

using CA1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BankApp.Models
{
    public partial class DeleteAccount : Form
    {
        public string FNameTB { get; set; }
        public string LNameTB { get; set; }
        public string AccountNoTB { get; set; }

        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {

        }

        private void DeleteBTN(object sender, EventArgs e)
        {
            List<string> Accounts = new List<string>();
            FNameTB = textBox1FName.Text.ToUpper();
            LNameTB = textBox2LName.Text.ToUpper();
            AccountNoTB = textBox3AccountNo.Text.ToUpper();

            NewCustomer newCustomer = new NewCustomer(FNameTB, LNameTB);   //Initializes a new Customer to then check its existence
            newCustomer.SetAccountNumber();

            string customersFilePath = "C:/BankApp/Accounts/.CustomersFile.txt";
            string currentFilePath = $"C:/BankApp/Accounts/{AccountNoTB}_current.txt";
            string savingFilePath = $"C:/BankApp/Accounts/{AccountNoTB}_saving.txt";
            string line;

            using (StreamReader reader = new StreamReader(customersFilePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Accounts.Add(line);
                }
            }

            if (string.IsNullOrWhiteSpace(textBox1FName.Text) || string.IsNullOrWhiteSpace(textBox2LName.Text) ||
                  string.IsNullOrWhiteSpace(textBox3AccountNo.Text))
            {
                MessageBox.Show("All the TextBox must be filled up");
            }
            else if (!Accounts.Contains(newCustomer.ToString()))       //Check if the list contains the "new customer" that was initialized previously
            {
                MessageBox.Show("Account does not exist!");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(customersFilePath))
                {
                    foreach (string account in Accounts)
                    {
                        if (newCustomer.ToString() == account)
                        {
                            double currentBalance;
                            double savingBalance;

                            using (StreamReader reader = new StreamReader(currentFilePath))
                            {
                                string s = reader.ReadLine();
                                currentBalance = Convert.ToDouble(s.Substring(s.IndexOf("$") + 1));   //Converts the string value after the index of "$" to double
                            }

                            using (StreamReader reader = new StreamReader(savingFilePath))
                            {
                                string s = reader.ReadLine();
                                savingBalance = Convert.ToDouble(s.Substring(s.IndexOf("$") + 1));    //Converts the string value after the index of "$" to double
                            }

                            if (currentBalance > 0 || savingBalance > 0)
                            {
                                MessageBox.Show("Only accounts with Balance 0.00 can be deleted");
                            }
                            else
                            {
                                File.Delete(currentFilePath);
                                File.Delete(savingFilePath);
                                textBox1FName.Clear();
                                textBox2LName.Clear();
                                textBox3AccountNo.Clear();
                                MessageBox.Show("Account deleted");
                                continue;
                            }
                        }
                        writer.WriteLine(account);
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
