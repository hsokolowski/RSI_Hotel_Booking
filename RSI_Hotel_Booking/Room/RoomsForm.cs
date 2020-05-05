using System.Windows.Forms;
using RoomDto = RSI_Hotel_Booking.RoomService.roomListDto;
using RommServiceClient = RSI_Hotel_Booking.RoomService.RoomWebServiceClient;
using System.Drawing;
using System.ServiceModel;

namespace RSI_Hotel_Booking.Room
{
    public partial class RoomsForm : Form
    {
        public RoomsForm(string hoteName, long hotelID)
        {
            InitializeComponent();
            this.Text = "Rooms - " + hoteName;

            SetRooms(hotelID);
        }

        private void SetRooms(long id)
        {
            RommServiceClient client = new RommServiceClient();
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                RoomDto[] roomListDtos = client.getRoomListDtos(id);

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