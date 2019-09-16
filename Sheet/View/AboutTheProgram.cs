using System;
using System.Windows.Forms;

namespace Sheet
{
    public partial class AboutTheProgram : Form
    {
        public AboutTheProgram()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
