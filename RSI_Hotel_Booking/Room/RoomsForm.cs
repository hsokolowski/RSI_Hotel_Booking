using System.Windows.Forms;
using RoomDto = RSI_Hotel_Booking.RoomService.roomListDto;
using RommServiceClient = RSI_Hotel_Booking.RoomService.RoomWebServiceClient;
using System.Drawing;
using System.ServiceModel;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RSI_Hotel_Booking.Room
{
    public partial class RoomsForm : Form
    {
        static HttpClient client2 = new HttpClient();
        public RoomsForm(string hoteName, long hotelID)
        {
            InitializeComponent();
            this.Text = "Rooms - " + hoteName;

            SetRooms(hotelID);
        }


        private async Task<RoomDto[]> getRoomDtoLISTREST(long id)
        {
            client2.BaseAddress = new Uri(Global.URL);
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client2.GetAsync("/localization/localization/list?personId=" + Global.ID);
            var response = await client2.GetAsync("/room/list?hotelId=" + id);

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RoomDto[]>(json);

            RoomDto[] localizationDtos = data;

            return localizationDtos;
        }

        private async void SetRooms(long id)
        {
            RommServiceClient client = new RommServiceClient();
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                //RoomDto[] roomListDtos = client.getRoomListDtos(id);
                RoomDto[] roomListDtos = await getRoomDtoLISTREST(id);

                if (roomListDtos != null)
                {
                    foreach (var item in roomListDtos)
                    {
                        RoomListItem listItem = new RoomListItem();

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
    }
}