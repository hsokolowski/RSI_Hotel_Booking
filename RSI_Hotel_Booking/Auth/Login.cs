using System;
using System.Drawing;
using System.Windows.Forms;
using SecurityWebServiceClient = RSI_Hotel_Booking.SecurityService.SecurityWebServiceClient;
using UserDto = RSI_Hotel_Booking.SecurityService.userDto;
using Global = RSI_Hotel_Booking.Globals.Globals;

namespace RSI_Hotel_Booking.Auth
{
    public partial class Login : Form
    {
        UserDto user = new UserDto();

        public Login()
        {
            InitializeComponent();
            exceptionLabel.Visible = false;
            exceptionLabel.ForeColor = Color.Red;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            exceptionLabel.Visible = false;

            if (IsPositiveLogin()) // positive
            {
                this.Hide();
                Form1 sistema = new Form1();
                sistema.ShowDialog();
                this.Close();
            }
            else
            {
                exceptionLabel.Text = "Wrong login or password";
                exceptionLabel.Visible = true;
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
            SetData();

            SecurityWebServiceClient client = new SecurityWebServiceClient();
            try
            {
                Global.ID = client.login(user);
                Global.Login = loginTextBox.Text;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetData()
        {
            user.username = loginTextBox.Text;
            user.password = passwordTextBox.Text;
        }
    }
}
