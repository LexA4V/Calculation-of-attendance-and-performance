﻿using System;
using System.Windows.Forms;

namespace Sheet
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AboutTheProgram a = new AboutTheProgram();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            MainForm t = new MainForm();
            this.Hide();
            t.ShowDialog();
            //this.Show();
        }
    }
}
