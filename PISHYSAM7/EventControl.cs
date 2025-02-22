using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISHYSAM7
{
    public partial class EventControl : UserControl
    {
        public EventControl(string name, string dates, string desc)
        {
            InitializeComponent();
            labelName.Text = name;
            labelDates.Text = dates;
            labelDesc.Text = desc;
        }
    }
}
