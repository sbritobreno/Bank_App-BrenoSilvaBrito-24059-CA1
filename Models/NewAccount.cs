//Breno Silva Brito
//ID:24059

using CA1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BankApp.Models
{
    public partial class NewAccount : Form
    {
        public string FNameFromTB { get; set; }
        public string LNameFromTB { get; set; }
        public string EmailFromTB { get; set; }

        public NewAccount()
        {
            InitializeComponent();           
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {

        }
     
        private void CreateBTN(object sender, EventArgs e)
        {
            List<NewCustomer> Customers = new List<NewCustomer>();
            List<string> Accounts = new List<string>();

            FNameFromTB = fNameTB.Text.ToUpper();
            LNameFromTB = lNameTB.Text.ToUpper();
            EmailFromTB = emailTB.Text.ToUpper();

            NewCustomer newCustomer = new NewCustomer(FNameFromTB,LNameFromTB,EmailFromTB);
            newCustomer.SetAccountNumber();
            newCustomer.NewCurreentAccount();
            newCustomer.NewSavingAccount();

            Customers.Add(newCustomer);
            string path = "C:/BankApp/Accounts/.CustomersFile.txt";
            string line;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        Accounts.Add(line);
                    }
                }
            }
            
            if (string.IsNullOrWhiteSpace(fNameTB.Text) || string.IsNullOrWhiteSpace(lNameTB.Text) ||
               string.IsNullOrWhiteSpace(emailTB.Text))
            {
                MessageBox.Show("All the TextBox must be filled up");
            }
            else if (Accounts.Contains(newCustomer.ToString()))
            {
                MessageBox.Show("Account already exists");
            }
            else
            {
                MessageBox.Show("Account created successfully");

                foreach (NewCustomer currentCustomer in Customers)
                {
                    using (TextWriter tw = File.AppendText(path))
                    {
                        tw.WriteLine(newCustomer.ToString());
                        tw.Close();       
                    }
                }
                fNameTB.Clear();
                lNameTB.Clear();
                emailTB.Clear();
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
