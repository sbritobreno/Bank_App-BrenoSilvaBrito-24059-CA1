//Breno Silva Brito
//ID: 24059

using System;
using System.Windows.Forms;
using System.Threading;

namespace BankApp.Models
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnterBTN(object sender, EventArgs e)
        {
            string employeePin = "A1234";

            if (textBox1.Text != employeePin)
            {
                MessageBox.Show("Invalid Pin");
            }
            else
            {
                this.Close();
                Thread t1 = new Thread(OpenEmployeeTasksWindow);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }

        private void OpenEmployeeTasksWindow()
        {
            Application.Run(new EmployeeTasks());
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
