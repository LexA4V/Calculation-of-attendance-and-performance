using System;
using System.Windows.Forms;

namespace Sheet
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
        }

        public Calendar(Button btn)
            : this()
        {
            btnOpenCalendar = btn;
        }

        Button btnOpenCalendar;

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnOpenCalendar.Enabled = true;
        }
    }
}
