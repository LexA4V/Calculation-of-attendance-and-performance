using System.Windows.Forms;
using ControlWeekS;
using System;

namespace Sheet
{
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();
        }

        public Reference(Control enabled) : this()
        {
            EnabledOpenReference = enabled;
        }

        Control EnabledOpenReference;

        private void Reference_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(EnabledOpenReference != null)
            EnabledOpenReference.Enabled = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            label1.Text = controlDayOfWeek1.DivisionEnabled.ToString();
            try
            {
                label2.Text = controlDayOfWeek1.TotalCountHours.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }
    }
}
