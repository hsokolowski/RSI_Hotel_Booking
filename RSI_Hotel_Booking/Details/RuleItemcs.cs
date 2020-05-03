using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSI_Hotel_Booking.Details
{
    public partial class RuleItemcs : UserControl
    {
        public RuleItemcs(string group,string text)
        {
            InitializeComponent();
            label2.Text = group == "Brak" ? "" : group;
            descriptionTb.Text = text;
        }
    }
}
