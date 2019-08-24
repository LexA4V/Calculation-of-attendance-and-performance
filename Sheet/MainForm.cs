using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sheet
{
    public partial class MainForm : Form
    {
        uint n, tr, hr, vpr, prby;
        double ysp, kz, chch = 0, ovpr, oprby;
        double[] dnV = new double[5];
        double[] dnN = new double[5];
        double[] dchV = new double[5];
        double[] dchN = new double[5];
        bool[] flagsDivWeek = new bool[5];

        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox16.Text = textBox1.Text;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox16.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms["GForm"].Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox16.Text != "") n = Convert.ToUInt32(textBox1.Text);
            if (textBox2.Text != "") tr = Convert.ToUInt32(textBox2.Text);
            if (textBox3.Text != "") hr = Convert.ToUInt32(textBox3.Text);
            if (comboBox1.Text != "") dnV[0] = Convert.ToDouble(comboBox1.Text);
            if (comboBox2.Text != "") dnV[1] = Convert.ToDouble(comboBox2.Text);
            if (comboBox3.Text != "") dnV[2] = Convert.ToDouble(comboBox3.Text);
            if (comboBox4.Text != "") dnV[3] = Convert.ToDouble(comboBox4.Text);
            if (comboBox5.Text != "") dnV[4] = Convert.ToDouble(comboBox5.Text);
            if (textBox6.Text != "") dchV[0] = Convert.ToDouble(textBox6.Text);
            if (textBox7.Text != "") dchV[1] = Convert.ToDouble(textBox7.Text);
            if (textBox8.Text != "") dchV[2] = Convert.ToDouble(textBox8.Text);
            if (textBox9.Text != "") dchV[3] = Convert.ToDouble(textBox9.Text);
            if (textBox10.Text != "") dchV[4] = Convert.ToDouble(textBox10.Text);
            if (comboBox6.Text != "") dnN[0] = Convert.ToDouble(comboBox6.Text);
            if (comboBox7.Text != "") dnN[1] = Convert.ToDouble(comboBox7.Text);
            if (comboBox8.Text != "") dnN[2] = Convert.ToDouble(comboBox8.Text);
            if (comboBox9.Text != "") dnN[3] = Convert.ToDouble(comboBox9.Text);
            if (comboBox10.Text != "") dnN[4] = Convert.ToDouble(comboBox10.Text);
            if (textBox11.Text != "") dchN[0] = Convert.ToDouble(textBox11.Text);
            if (textBox12.Text != "") dchN[1] = Convert.ToDouble(textBox12.Text);
            if (textBox13.Text != "") dchN[2] = Convert.ToDouble(textBox13.Text);
            if (textBox14.Text != "") dchN[3] = Convert.ToDouble(textBox14.Text);
            if (textBox15.Text != "") dchN[4] = Convert.ToDouble(textBox15.Text);
            if (textBox17.Text != "") vpr = Convert.ToUInt32(textBox17.Text);
            if (textBox18.Text != "") prby = Convert.ToUInt32(textBox18.Text);
            //для человеко-часов
            if ((textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox4.Text != "") && (comboBox5.Text != ""))
            {
                if ((dnV[0] + dnN[0] < 6) && (dnV[1] + dnN[1] < 6) && (dnV[2] + dnN[2] < 6) && (dnV[3] + dnN[3] < 6) && (dnV[4] + dnN[4] < 6))
                {
                    textBox19.Clear();
                    double m;
                    m = dnV[0] * dchV[0];
                    if ((checkBox1.Checked == true) && (comboBox6.Text != "") && (textBox11.Text != ""))
                        m += dnN[0] * dchN[0];
                    m += dnV[1] * dchV[1];
                    if ((checkBox2.Checked == true) && (comboBox7.Text != "") && (textBox12.Text != ""))
                        m += dnN[1] * dchN[1];
                    m += dnV[2] * dchV[2];
                    if ((checkBox3.Checked == true) && (comboBox8.Text != "") && (textBox13.Text != ""))
                        m += dnN[2] * dchN[2];
                    m += dnV[3] * dchV[3];
                    if ((checkBox4.Checked == true) && (comboBox9.Text != "") && (textBox14.Text != ""))
                        m += dnN[3] * dchN[3];
                    m += dnV[4] * dchV[4];
                    if ((checkBox5.Checked == true) && (comboBox10.Text != "") && (textBox15.Text != ""))
                        m += dnN[4] * dchN[4];
                    chch = m * n;
                    textBox19.AppendText(chch + " ч/ч");
                }
                else
                    MessageBox.Show("Количество недель в месяц не может быть больше 5-и!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                textBox19.Clear();
            //для посещаемости
            if ((chch != 0) && (textBox17.Text != ""))
            {
                if (2 * vpr <= chch)
                {
                    textBox20.Clear();
                    ovpr = Math.Ceiling((chch - 2 * vpr) * 1000 / chch) / 10;
                    textBox20.AppendText(ovpr + "%");
                }
                else
                    MessageBox.Show("Количество пропусков превышает количество часов!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                textBox20.Clear();
            //для прогулов 
            if ((chch != 0) && (textBox18.Text != ""))
            {
                if (2 * prby <= chch)
                {
                    if (textBox17.Text != "")
                    {
                        if (prby <= vpr)
                        {
                            textBox21.Clear();
                            oprby = Math.Ceiling(2 * prby * 1000 / chch) / 10;
                            textBox21.AppendText(oprby + "%");
                        }
                        else
                            MessageBox.Show("Количество пропусков без уважительной причины превышает общее количество пропусков!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        textBox21.Clear();
                        oprby = Math.Ceiling(2 * prby * 1000 / chch) / 10;
                        textBox21.AppendText(oprby + "%");
                    }
                }
                else
                    MessageBox.Show("Количество пропусков без уважительной причины превышает количество часов!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                textBox21.Clear();
            //для результатов успеваемости
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (tr <= n)
                {
                    textBox4.Clear();
                    ysp = Math.Ceiling(tr * 1000.0 / n) / 10;
                    textBox4.AppendText(ysp + "%");
                }
                else
                {
                    MessageBox.Show("Количество студентов, учащихся на оценки 3, 4, 5 не может превышать общее количество студентов!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox2.Focus();
                }
            }
            else
                textBox4.Clear();
            //для результатов качества
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                if (hr <= n)
                {
                    if (textBox2.Text != "")
                    {
                        if (hr <= tr)
                        {
                            textBox5.Clear();
                            kz = Math.Ceiling(hr * 1000.0 / n) / 10;
                            textBox5.AppendText(kz + "%");
                        }
                        else
                        {
                            MessageBox.Show("Количество студентов, учащихся на оценки 4, 5 не может превышать количество студентов, учащихся на оценки 3, 4, 5!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox3.Focus();
                        }
                    }
                    else
                    {
                        textBox5.Clear();
                        kz = Math.Ceiling(hr * 1000.0 / n) / 10;
                        textBox5.AppendText(kz + "%");
                    }
                }
                else
                {
                    MessageBox.Show("Количество студентов, учащихся на оценки 4, 5 не может превышать общее количество студентов!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Focus();
                }
            }
            else
                textBox5.Clear();
            Array.Clear(dnV, 0, dnV.Length);
            Array.Clear(dnN, 0, dnN.Length);
            Array.Clear(dchV, 0, dchV.Length);
            Array.Clear(dchN, 0, dchN.Length);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox6.Items.Clear();
                comboBox6.Enabled = true;
                textBox11.Enabled = true;
                comboBox1.Items.Add("2");
                comboBox1.Items.Add("3");
                comboBox6.Items.Add("2");
                comboBox6.Items.Add("3");
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox6.Items.Clear();
                comboBox6.Enabled = false;
                textBox11.Enabled = false;
                textBox11.Clear();
                comboBox1.Items.Add("4");
                comboBox1.Items.Add("5");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox2.Items.Clear();
                comboBox7.Items.Clear();
                comboBox7.Enabled = true;
                textBox12.Enabled = true;
                comboBox2.Items.Add("2");
                comboBox2.Items.Add("3");
                comboBox7.Items.Add("2");
                comboBox7.Items.Add("3");
            }
            else
            {
                comboBox2.Items.Clear();
                comboBox7.Items.Clear();
                comboBox7.Enabled = false;
                textBox12.Enabled = false;
                textBox12.Clear();
                comboBox2.Items.Add("4");
                comboBox2.Items.Add("5");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                comboBox3.Items.Clear();
                comboBox8.Items.Clear();
                comboBox8.Enabled = true;
                textBox13.Enabled = true;
                comboBox3.Items.Add("2");
                comboBox3.Items.Add("3");
                comboBox8.Items.Add("2");
                comboBox8.Items.Add("3");
            }
            else
            {
                comboBox3.Items.Clear();
                comboBox8.Items.Clear();
                comboBox8.Enabled = false;
                textBox13.Enabled = false;
                textBox13.Clear();
                comboBox3.Items.Add("4");
                comboBox3.Items.Add("5");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                comboBox4.Items.Clear();
                comboBox9.Items.Clear();
                comboBox9.Enabled = true;
                textBox14.Enabled = true;
                comboBox4.Items.Add("2");
                comboBox4.Items.Add("3");
                comboBox9.Items.Add("2");
                comboBox9.Items.Add("3");
            }
            else
            {
                comboBox4.Items.Clear();
                comboBox9.Items.Clear();
                comboBox9.Enabled = false;
                textBox14.Enabled = false;
                textBox14.Clear();
                comboBox4.Items.Add("4");
                comboBox4.Items.Add("5");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                comboBox5.Items.Clear();
                comboBox10.Items.Clear();
                comboBox10.Enabled = true;
                textBox15.Enabled = true;
                comboBox5.Items.Add("2");
                comboBox5.Items.Add("3");
                comboBox10.Items.Add("2");
                comboBox10.Items.Add("3");
            }
            else
            {
                comboBox5.Items.Clear();
                comboBox10.Items.Clear();
                comboBox10.Enabled = false;
                textBox15.Enabled = false;
                textBox15.Clear();
                comboBox5.Items.Add("4");
                comboBox5.Items.Add("5");
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            Calendar c = new Calendar(sender as Button);
            c.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            Reference r = new Reference((pictureBox1));
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            About_the_program a = new About_the_program();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text != "")
            //    n_1.Value = Convert.ToInt32(textBox1.Text);
            //if (textBox17.Text != "")
            //    n_2.Value = Convert.ToInt32(textBox17.Text);
            //if (textBox18.Text != "")
            //    n_3.Value = Convert.ToInt32(textBox18.Text);
            //if (textBox20.Text != "")
            //    n_4.Value = Convert.ToInt32(textBox20.Text);
            //if (textBox21.Text != "")
            //    n_5.Value = Convert.ToInt32(textBox21.Text);
            //if (textBox2.Text != "")
            //    n_6.Value = Convert.ToInt32(textBox2.Text);
            //if (textBox3.Text != "")
            //    n_7.Value = Convert.ToInt32(textBox3.Text);
            //if (textBox4.Text != "")
            //    n_8.Value = Convert.ToInt32(textBox4.Text);
            //if (textBox5.Text != "")
            //    n_9.Value = Convert.ToInt32(textBox5.Text);
            //Output O = new Output();
            //this.Hide();
            //O.ShowDialog();
            //this.Show();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
