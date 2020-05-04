using System;
using System.Drawing;
using System.Windows.Forms;
using SecurityWebServiceClient = RSI_Hotel_Booking.SecurityService.SecurityWebServiceClient;
using UserDto = RSI_Hotel_Booking.SecurityService.userDto;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.ServiceModel;
using System.ServiceModel.Channels;

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

            using (new OperationContextScope(client.InnerChannel))
            {
                string str = "7682d860-7f58-11ea-bc55-0242ac130003";
                HttpRequestMessageProperty reqMsg = new HttpRequestMessageProperty();

                MessageHeader usernameTokenHeader = MessageHeader.CreateHeader("accessCode",
                    "http://endpoint.ws.project.soap.rsi.com/", str);
                OperationContext.Current.OutgoingMessageHeaders.Add(usernameTokenHeader);

                try
                {
                    Global.ID = client.login(user);
                    Global.Login = loginTextBox.Text;
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                //reqMsg.Headers.Add("accessCode", str);
                //reqMsg.Headers.Add("hostName", "Hubert");
                //var usernameHeader = MessageHeader.CreateHeader("username", string.Empty, _username);
                //OperationContext.Current.OutgoingMessageHeaders.Add(usernameHeader);
                //var passwordHeader = MessageHeader.CreateHeader("password", string.Empty, _passowrd);
                //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name]=reqMsg;

                //client.(serviceId);
            }
            
        }

        private void SetData()
        {
            user.username = loginTextBox.Text;
            user.password = passwordTextBox.Text;
        }
    }
}
