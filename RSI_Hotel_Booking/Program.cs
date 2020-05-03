using RSI_Hotel_Booking.Auth;
using RSI_Hotel_Booking.Details;
using System;
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
            Application.Run(new DetailsForm("Pokoój", 76));
        }
    }
}
