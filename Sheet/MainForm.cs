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


        private void ClearResultPerformance()
        {
            tBAcademicPerformance.Clear();
            tBKnowledgeQuality.Clear();
        }

        //вычисление успеваемости
        private void CalculatePerformance()
        {
            ClearResultPerformance();
            try
            {
                int countStudents = 0;
                if (int.TryParse(tBCountStudens.Text, out countStudents) && countStudents>0)
                {
                    //троечники
                    int CountStudents345 = 0;
                    if (int.TryParse(tBCountStudens345.Text, out CountStudents345) && CountStudents345 > 0)
                    {
                        tBAcademicPerformance.Text = string.Format("{0}%", Math.Round(calc.Performance(countStudents, CountStudents345), 2));
                    }

                    //хорошисты
                    int CountStudents45 = 0;
                    if (int.TryParse(tBCountStudens45.Text, out CountStudents45) && CountStudents45 > 0)
                    {
                        if (CountStudents45 > CountStudents345)
                            throw new ArgumentException("Хорошистов должно быть меньше чем хорошистов+троечников!");

                        tBKnowledgeQuality.Text = string.Format("{0}%", Math.Round(calc.KnowledgeQuality(countStudents, CountStudents45), 2));
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


        private void ClearResultAttendance()
        {
            tBCountManHours.Clear();
            tBAttendance.Clear();
            tBAbsenteeism.Clear();
        }

        //вычисление посещяемости
        private void CalculateAttendance()
        {
            ClearResultAttendance();
            try
            {
                int countStudents = 0;
                int countPass = 0;
                int countOmissions = 0;

                if (int.TryParse(tBCountStudens2.Text, out countStudents) && countStudents > 0)
                {
                    double totalMenHours = 0;
                    double attendance = 0;
                    double omissions = 0;

                    try
                    {
                        //человеко-часы
                        totalMenHours = calc.GetHourOfMounth(countStudents, yy.Select(x => x.TotalCountHours).ToArray());
                        tBCountManHours.Text = string.Format("{0}ч/ч", Math.Round(totalMenHours, 2));
                    }
                    catch
                    { return; }

                    //пропуски
                    if (int.TryParse(tBCountPass.Text, out countPass) && countPass > 0)
                    {
                        attendance = calc.Attendance(totalMenHours, countPass);
                        tBAttendance.Text = string.Format("{0}%", Math.Round(attendance, 2));
                    }

                    //прогулы
                    if (int.TryParse(tBCountOmissions.Text, out countOmissions) && countOmissions > 0)
                    {
                        if (countOmissions < countPass)
                        {
                            omissions = calc.Omissions(totalMenHours, countOmissions);
                            tBCountOmissions.Text = string.Format("{0}%", Math.Round(omissions, 2));
                        }
                        else
                            throw new ArgumentException("Количество пропусков без уважительной причины превышает общее количество пропусков!");
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
