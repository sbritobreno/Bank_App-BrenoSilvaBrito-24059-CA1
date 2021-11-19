//Breno Silva Brito
//ID:24059

using CA1.Models;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BankApp.Models
{
    public partial class CurrentTransaction : Form
    {
        Thread t1;

        public string AccountNumber { get; set; }
        public string Path { get; set; }

        public CurrentTransaction(string accountNumber)
        {
            AccountNumber = accountNumber;
            Path = $"C:/BankApp/Accounts/{AccountNumber}_current.txt";
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            
            string line;

            using (StreamReader reader = new StreamReader(Path))
            {
                line = reader.ReadLine();
                listBox1.Items.Add(line);
            }
        }

        private void TransactionHistoryBTN(object sender, EventArgs e)
        {
            Thread t2 = new Thread(OpenCurrentTransactionHistory);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }

        private void OpenCurrentTransactionHistory()
        {
            Application.Run(new CurrentTransactionHistory(AccountNumber));
        }

        private void WithdrawBTN(object sender, EventArgs e)
        {
            double atualBalance;
            DateTime todaysDate = DateTime.Today;

            using (StreamReader reader = new StreamReader(Path))
            {
                string s = reader.ReadLine();
                atualBalance = Convert.ToDouble(s.Substring(s.IndexOf("$")+1));    //Converts the string value after index "$" to double 
            }

            double withdraw = Convert.ToDouble(textBox1.Text);

            if(withdraw > atualBalance)
            {
                MessageBox.Show("There is not enough money");
            }
            else if(withdraw == 0)
            {
                MessageBox.Show("There is not how to withdraw $0.00 euro");
            }
            else
            {
                atualBalance -= withdraw;
                string newRecord = $"{todaysDate.ToString("d")}\tWithdraw\t\t${withdraw}";    //Message to be append to the transaction history
                MessageBox.Show("Withdraw done");

                string[] arrLine = File.ReadAllLines(Path);         //Overwrites the first line with the new account balance
                arrLine[0] = $"Balance = ${atualBalance}";
                File.WriteAllLines(Path, arrLine);
                TextWriter tw = File.AppendText(Path);
                tw.WriteLine(newRecord);
                tw.Close();

                listBox1.Items.Clear();               //updates the balance on the display
                listBox1.Items.Add(arrLine[0]);

            }
        }

        private void DepositBTN(object sender, EventArgs e)
        {
            double atualBalance;
            DateTime todaysDate = DateTime.Today;
 
            

            using (StreamReader reader = new StreamReader(Path))
            {
                string s = reader.ReadLine();
                atualBalance = Convert.ToDouble(s.Substring(s.IndexOf("$") + 1));      //Converts the string value after index "$" to double
            }

            double deposit = Convert.ToDouble(textBox1.Text);
            
            if (deposit == 0)
            {
                MessageBox.Show("You should deposit more than $0.00 euro");
            }
            else
            {
                atualBalance += deposit;
                string newRecord = $"{todaysDate.ToString("d")}\tDeposit\t\t${deposit}";      //Message to be append to the transaction history
                MessageBox.Show("Deposit done");               

                string[] arrLine = File.ReadAllLines(Path);           //Overwrites the first line with the new account balance
                arrLine[0] = $"Balance = ${atualBalance}";
                File.WriteAllLines(Path, arrLine);
                TextWriter tw = File.AppendText(Path);
                tw.WriteLine(newRecord);
                tw.Close();

                listBox1.Items.Clear();           //updates the balance on the display
                listBox1.Items.Add(arrLine[0]);

            }
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
