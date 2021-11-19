//Breno Silva Brito
//ID:24059

using BankApp;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CA1.Models
{
    public partial class SavingTransaction : Form
    {
        public string AccountNumber { get; set; }
        public string Path { get; set; }

        public SavingTransaction(string accountNumber)
        {
            AccountNumber = accountNumber;
            Path = $"C:/BankApp/Accounts/{AccountNumber}_saving.txt";
            InitializeComponent();
        }

        private void SavingTransaction_Load(object sender, EventArgs e)
        {
            string line;

            using (StreamReader reader = new StreamReader(Path))    //Reads only the first line, the one with the atual balance
            {
                line = reader.ReadLine();
                listBox1.Items.Add(line);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TransactionHistoryBTN(object sender, EventArgs e)
        {
            Thread t1 = new Thread(NewSavingTransactionHistory);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void NewSavingTransactionHistory()
        {
            Application.Run(new SavingTransactionHistory(AccountNumber));
        }

        private void WithdrawBTN(object sender, EventArgs e)
        {
            double atualBalance;
            DateTime todaysDate = DateTime.Today;        

            using (StreamReader reader = new StreamReader(Path))
            {
                string s = reader.ReadLine();
                atualBalance = Convert.ToDouble(s.Substring(s.IndexOf("$") + 1));
            }

            double withdraw = Convert.ToDouble(textBox1.Text);

            if (withdraw > atualBalance)
            {
                MessageBox.Show("There is not enough money");
            }
            else if (withdraw == 0)
            {
                MessageBox.Show("There is not how to withdraw $0.00 euro");
            }
            else
            {
                atualBalance -= withdraw;
                string newRecord = $"{todaysDate.ToString("d")}\tWithdraw\t\t${withdraw}";
                MessageBox.Show("Withdraw done");

                string[] arrLine = File.ReadAllLines(Path);
                arrLine[0] = $"Balance = ${atualBalance}";          //Updates the balance on the file
                File.WriteAllLines(Path, arrLine);
                TextWriter tw = File.AppendText(Path);
                tw.WriteLine(newRecord);
                tw.Close();

                listBox1.Items.Clear();                  //Updates the balance on the display
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
                atualBalance = Convert.ToDouble(s.Substring(s.IndexOf("$") + 1));
            }

            double deposit = Convert.ToDouble(textBox1.Text);

            if (deposit == 0)
            {
                MessageBox.Show("You should deposit more than $0.00 euro");
            }
            else
            {
                atualBalance += deposit;
                string newRecord = $"{todaysDate.ToString("d")}\tDeposit\t\t${deposit}";
                MessageBox.Show("Deposit done");

                string[] arrLine = File.ReadAllLines(Path);
                arrLine[0] = $"Balance = ${atualBalance}";
                File.WriteAllLines(Path, arrLine);
                TextWriter tw = File.AppendText(Path);
                tw.WriteLine(newRecord);
                tw.Close();

                listBox1.Items.Clear();
                listBox1.Items.Add(arrLine[0]);
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
