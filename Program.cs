//Breno Silva Brito
//ID: 24059

using System;
using System.Windows.Forms;


namespace BankApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BankApplication myBank = new BankApplication();
            Application.Run(myBank);
        }       
    }
}
