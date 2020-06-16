using Newtonsoft.Json;
using RSI_Hotel_Booking.Globals;
using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelListDto = RSI_Hotel_Booking.HotelService.hotelListDto;
using HotelServiceClient = RSI_Hotel_Booking.HotelService.HotelWebServiceClient;
using Global = RSI_Hotel_Booking.Globals.Globals;

namespace RSI_Hotel_Booking.Hotel
{
    public partial class HotelForm : Form
    {
        string _name;
        long _ID;
        static HttpClient client2 = new HttpClient();

        public HotelForm(string name, long id)
        {
            InitializeComponent();
            this.Text = name;
            _ID = id;
            _name = name;

            SetHotels();
        }

        private async void SetHotels()
        {
            HotelServiceClient client = new HotelServiceClient();
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                var data =  await getHotelListDto();
                HotelListDto[] hotelListDtos = data;

                if (hotelListDtos != null)
                {
                    foreach (var item in hotelListDtos)
                    {
                        HotelListItem listItem = new HotelListItem();

                        listItem.Title = item.name;
                        listItem.Subtitle = item.id;

                        if (item.exhibitionPhoto != null)
                        {
                            System.Net.WebRequest request = System.Net.WebRequest.Create(item.exhibitionPhoto);
                            System.Net.WebResponse response = request.GetResponse();
                            System.IO.Stream responseStream = response.GetResponseStream();
                            Bitmap bitmap = new Bitmap(responseStream);

                            listItem.Image = bitmap;
                        }


                        flowLayoutPanel1.Controls.Add(listItem);
                    }
                }
            }
        }

        private async Task<HotelListDto[]> getHotelListDto()
        {
            client2.BaseAddress = new Uri(Global.URL);
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client2.GetAsync("/localization/localization/list?personId=" + Global.ID);
            var response = await client2.GetAsync("hotel/list?hotelId="+_ID);

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<HotelListDto[]>(json);

            HotelListDto[] localizationDtos = data;

            return localizationDtos; 
        }
    }
}