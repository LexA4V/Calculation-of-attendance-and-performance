using System.Windows.Forms;

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
            EnabledOpenReference.Enabled = true;
        }
    }
}
