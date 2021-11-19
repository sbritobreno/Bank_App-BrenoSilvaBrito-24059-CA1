//Breno Silva Brito
//ID:24059

using System;
using System.IO;

namespace CA1.Models
{
    public class NewCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public int PinCode { get; set; }

        public NewCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public NewCustomer(string firstName, string lastName,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void SetAccountNumber()
        {           

            string s = FirstName.Substring(0,1);    //Gets the first letter of each name
            string s2 = LastName.Substring(0,1);
            string xx = s + s2;                     //Put the initials together

            int nn = FirstName.Length + LastName.Length;       //Length of the whole name

            char[] y = s.ToLower().ToCharArray();     //Converting the initials to a corresponding number
            char[] z = s2.ToLower().ToCharArray();
            int yy = Convert.ToInt32(y[0]) - 96;      //a-z = 0-26
            int zz = Convert.ToInt32(z[0]) - 96;       //a-z = 0-26

            AccountNumber = $"{xx}-{nn}-{yy}-{zz}";
            PinCode = Convert.ToInt32($"{yy}{zz}");
        }

        public void NewCurreentAccount()
        {
            string currentFilePath = $"C:/BankApp/Accounts/{AccountNumber}_current.txt";
            File.Create(currentFilePath).Close();
            TextWriter tw = File.AppendText(currentFilePath);
            tw.WriteLine("Balance = $0.00");
            tw.Close();
        }

        public void NewSavingAccount()
        {
            string savingFilePath = $"C:/BankApp/Accounts/{AccountNumber}_saving.txt";
            File.Create(savingFilePath).Close();
            TextWriter tw2 = File.AppendText(savingFilePath);
            tw2.WriteLine("Balance = $0.00");
            tw2.Close();
        }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{AccountNumber}\t{PinCode}";
        }
    }
}
