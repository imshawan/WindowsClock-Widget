using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClock
{
    public partial class WInClock : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }
        public WInClock()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void WInClock_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.ControlBox = false;
            this.Text = String.Empty;
            this.Opacity = .80;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const string year = "yyyy";
            const string month = "MMMM";
            const string day = "dddd";
            const string dayInNumber = "dd";

            const string time = "HH:mm:ss";
            DateTime now = DateTime.Now;

            string strTime = now.ToString(time);
            string strYear = now.ToString(year);
            string strMonth = now.ToString(month);
            string strDay = now.ToString(day);
            string strDayInINT = now.ToString(dayInNumber);
            string date = strDay + ", " + strDayInINT + "th " + strMonth + " " + strYear;

            label1.Text = strTime;
            label2.Text = date;
        }
    }
}
