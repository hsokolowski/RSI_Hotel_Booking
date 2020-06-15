using RSI_Hotel_Booking.Auth;
using RSI_Hotel_Booking.Details;
using RSI_Hotel_Booking.Hotel;
using RSI_Hotel_Booking.Reservations;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RSI_Hotel_Booking
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            Application.Run(new HotelForm("abc", 11));
        }


        public static void AddAccessHeaders()
        {
            string str = "7682d860-7f58-11ea-bc55-0242ac130003";
            MessageHeader accessCodeTokenHeader = MessageHeader.CreateHeader("accessCode",
                "http://endpoint.ws.project.soap.rsi.com/", str);
            MessageHeader hostNameTokenHeader = MessageHeader.CreateHeader("hostName",
                "http://endpoint.ws.project.soap.rsi.com/", "hubert");
            OperationContext.Current.OutgoingMessageHeaders.Add(accessCodeTokenHeader);
            OperationContext.Current.OutgoingMessageHeaders.Add(hostNameTokenHeader);
        }
    }
}
