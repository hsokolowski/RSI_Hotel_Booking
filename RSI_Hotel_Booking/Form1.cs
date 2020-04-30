using System.Windows.Forms;
using Localization = RSI_Hotel_Booking.LocalizationService.localizationDto;
using LocalizationWebServiceClient = RSI_Hotel_Booking.LocalizationService.LocalizationWebServiceClient;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.Drawing;

namespace RSI_Hotel_Booking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = Global.ID.ToString();

            LocalizationWebServiceClient client = new LocalizationWebServiceClient();
            Localization[] localizationDtos = client.getLocalizationListDto();

            foreach (var item in localizationDtos)
            {
                System.Console.WriteLine(item.id + " " + item.name + " " + item.photo);
                Form1ListItem listItem = new Form1ListItem();
                listItem.Title = item.name;
                listItem.Subtitle = item.id.ToString();

                System.Net.WebRequest request = System.Net.WebRequest.Create(item.photo);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bitmap = new Bitmap(responseStream);

                listItem.Image = bitmap;

                flowLayoutPanel1.Controls.Add(listItem);
            }
        }
    }
}
