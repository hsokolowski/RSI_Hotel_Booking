using System;
using System.Drawing;
using System.Windows.Forms;
using SecurityWebServiceClient = RSI_Hotel_Booking.SecurityService.SecurityWebServiceClient;
using UserDto = RSI_Hotel_Booking.SecurityService.userDto;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RSI_Hotel_Booking.Auth
{
    public partial class Login : Form
    {
        UserDto user = new UserDto();
        static HttpClient client2 = new HttpClient();

        public Login()
        {
            InitializeComponent();
            exceptionLabel.Visible = false;
            exceptionLabel.ForeColor = Color.Red;
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            exceptionLabel.Visible = false;

            var task = IsPositiveLogin();
            var isPositive = await task;

            if (isPositive) // positive
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

        private async Task<bool> IsPositiveLogin()
        {
            SetData();

            SecurityWebServiceClient client = new SecurityWebServiceClient();

            using (new OperationContextScope(client.InnerChannel))
            {

                Program.AddAccessHeaders();
                try
                {
                    //Global.ID = client.login(user);


                    Global.ID = await LoginREST(user);
                    Global.Login = loginTextBox.Text;
                    Global.Password = passwordTextBox.Text;
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

        private async Task<long> LoginREST(UserDto u)
        {
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(Global.URL);
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client2.PostAsync("/login", byteContent);

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<long>(json);


            long id = data; // response get id

            return id;

        }
    }
}
