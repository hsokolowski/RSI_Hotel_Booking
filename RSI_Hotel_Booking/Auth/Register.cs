using System;
using System.Drawing;
using System.Windows.Forms;
using SecurityWebServiceClient = RSI_Hotel_Booking.SecurityService.SecurityWebServiceClient;
using UserDto = RSI_Hotel_Booking.SecurityService.userDto;

namespace RSI_Hotel_Booking.Auth
{
    public partial class Register : Form
    {
        SecurityWebServiceClient client = new SecurityWebServiceClient();

        public Register()
        {
            InitializeComponent();
            exceptionlabel.Visible = false;
            exceptionlabel.ForeColor = Color.Red;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            exceptionlabel.Visible = false;

            UserDto user = SetData();

            if (IsValid(user)) // positive
            {
                if(IsRegister(user))
                {
                    this.Hide();
                    Login sistema = new Login();
                    sistema.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                exceptionlabel.Text = "Some fields are empty";
                exceptionlabel.Visible = true;
            }
        }

        private bool IsRegister(UserDto user)
        {
            try
            {
                exceptionlabel.Text = client.register(user).ToString();
                return true;
            }
            catch (Exception e)
            {
                exceptionlabel.Text = e.Message;
            }
            exceptionlabel.Visible = true;
            return false;
        }

        private UserDto SetData()
        {
            UserDto user = new UserDto();
            user.email = emailTb.Text;
            user.password = passwordTb.Text;
            user.username = nameTb.Text;

            return user;
        }

        private bool IsValid(UserDto user)
        {
            if (string.IsNullOrEmpty(user.email)
                || string.IsNullOrEmpty(user.password)
                || string.IsNullOrEmpty(user.username))
            {
                return false;
            }
            return true;
        }
    }
}
