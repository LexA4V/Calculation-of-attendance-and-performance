using System;
using System.Windows.Forms;

namespace Sheet
{
    public partial class GForm : Form
    {
        public GForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About_the_program a = new About_the_program();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reference r = new Reference();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Dialog1 d = new Dialog1();
            //this.Hide();
            //d.ShowDialog();
            //this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm t = new MainForm();
            this.Hide();
            t.ShowDialog();
            //this.Show();
        }
    }
}
