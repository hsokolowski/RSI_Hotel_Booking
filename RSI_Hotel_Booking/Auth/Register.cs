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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (IsRegister()) // positive
            {
                this.Hide();
                Login sistema = new Login();
                sistema.ShowDialog();
                this.Close();
            }
            else
            {

            }
        }

        private bool IsRegister()
        {
            return true;
        }
    }
}
