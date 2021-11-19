//Breno Silva Brito
//ID: 24059

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BankApp.Models
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            List<string> Accounts = new List<string>();
            string path = "C:/BankApp/Accounts/.CustomersFile.txt";
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
