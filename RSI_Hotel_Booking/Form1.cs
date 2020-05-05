using System.Windows.Forms;
using Localization = RSI_Hotel_Booking.LocalizationService.localizationDto;
using LocalizationWebServiceClient = RSI_Hotel_Booking.LocalizationService.LocalizationWebServiceClient;
using Global = RSI_Hotel_Booking.Globals.Globals;
using Resources = RSI_Hotel_Booking.Properties.Resources;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using RSI_Hotel_Booking.Auth;
using RSI_Hotel_Booking.Reservations;

namespace RSI_Hotel_Booking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Hello " + Global.Login.ToString() + "!";

            logout.Image = (Image) (new Bitmap(Resources.logout, new Size(30, 30)));

            SetLocalization();
        }

        private void SetLocalization()
        {
            LocalizationWebServiceClient client = new LocalizationWebServiceClient();
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                Localization[] localizationDtos = client.getLocalizationListDto();
                foreach (var item in localizationDtos)
                {
                    System.Console.WriteLine(item.id + " " + item.name + " " + item.photo);
                    Form1ListItem listItem = new Form1ListItem();
                    listItem.Title = item.name;
                    listItem.Subtitle = item.id;

                    if (item.photo != null)
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create(item.photo);
                        System.Net.WebResponse response = request.GetResponse();
                        System.IO.Stream responseStream = response.GetResponseStream();
                        Bitmap bitmap = new Bitmap(responseStream);

                        listItem.Image = bitmap;
                    }
                    flowLayoutPanel1.Controls.Add(listItem);
                }
            }
        }

        private void logout_Click(object sender, System.EventArgs e)
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form thisForm in forms)
            {
                if (thisForm.Name != "Login") thisForm.Close();
            }

            Login form = new Login();
            form.ShowDialog();
        }

        private void search_Click(object sender, System.EventArgs e)
        {
            ReservationForm f = new ReservationForm();
            f.ShowDialog();
        }
    }
}