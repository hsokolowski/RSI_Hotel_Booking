using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSI_Hotel_Booking.Auth
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(IsPositiveLogin()) // positive
            {
                this.Hide();
                Form1 sistema = new Form1();
                sistema.ShowDialog();
                this.Close();
            }
            else
            {

            }
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register sistema = new Register();
            sistema.ShowDialog();
            this.Close();
        }

        private bool IsPositiveLogin()
        {
            return true;
        }
    }
}
