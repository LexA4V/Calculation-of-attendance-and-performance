using System;
using System.Windows.Forms;
using System.Linq;

using ControlWeekS;

namespace Sheet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            yy = new ControlDayOfWeek[5]
            {
                cDWMonday,
                cDWThuesday,
                cDWWednesday,
                cDWThursday,
                cDWFriday
            };
        }

        Model calc = new Model();

        private ControlDayOfWeek[] yy;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tBCountStudens2.Text = tBCountStudens.Text;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            tBCountStudens.Text = tBCountStudens2.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["StartForm"].Close();
            Application.Exit();
        }


        private void ClearCalculatePerformance()
        {
            tBAcademicPerformance.Clear();
            tBKnowledgeQuality.Clear();
        }

        //вычисление успеваемости
        private void CalculatePerformance()
        {
            ClearCalculatePerformance();
            try
            {
                if (tBCountStudens.Text != "")
                {
                    int CountStudents = int.Parse(tBCountStudens.Text);

                    int CountStudents345 = 0;
                    if (tBCountStudens345.Text != "")
                    {
                        CountStudents345 = int.Parse(tBCountStudens345.Text);

                        tBAcademicPerformance.Text = string.Format("{0}%", Math.Round(calc.Performance(CountStudents, CountStudents345), 2));
                    }

                    int CountStudents45 = 0;
                    if (tBCountStudens45.Text != "")
                    {
                        CountStudents45 = int.Parse(tBCountStudens45.Text);

                        if (CountStudents45 < CountStudents345)
                            tBKnowledgeQuality.Text = string.Format("{0}%", Math.Round(calc.KnowledgeQuality(CountStudents, CountStudents45), 2));
                        else
                            throw new ArgumentException("Хорошистов меньше чем хорошистов+троечников!");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ClearCalculateAttendance()
        {
            tBCountManHours.Clear();
            tBAttendance.Clear();
            tBAbsenteeism.Clear();
        }

        private void CalculateAttendance()
        {
            ClearCalculateAttendance();
            try
            {
                int countStudents = 0;
                int CountPass = 0;
                int CountOmissions = 0;

                if (tBCountStudens2.Text != "")
                    countStudents = int.Parse(tBCountPass.Text);

                if (tBCountPass.Text != "")
                    CountPass = int.Parse(tBCountPass.Text);

                if (tBCountOmissions.Text != "")
                    CountOmissions = int.Parse(tBCountOmissions.Text);



                double totalMenHours = 0;
                double attendance = 0;
                double omissions = 0;


                if (countStudents <= 0) return;

                totalMenHours = calc.GetHourOfMounth(countStudents, yy.Select(x => x.TotalCountHours).ToArray());
                tBCountManHours.Text = totalMenHours.ToString();



                if (CountPass > 0)
                {
                    attendance = calc.Attendance(totalMenHours, CountPass);
                    tBAttendance.Text = attendance.ToString();
                }



                if (CountOmissions > 0)
                {
                    if (CountOmissions < CountPass)
                    {
                        omissions = calc.Omissions(totalMenHours, CountOmissions);
                    }
                    else
                        throw new ArgumentException("Количество пропусков без уважительной причины превышает общее количество пропусков!");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculatePerformance();

            CalculateAttendance();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            Reference r = new Reference((pictureBox1));
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AboutTheProgram a = new AboutTheProgram();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void textBoxINT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
