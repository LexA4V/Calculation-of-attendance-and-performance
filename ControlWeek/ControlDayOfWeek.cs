using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlWeekS
{
    public partial class ControlDayOfWeek : UserControl
    {
        public ControlDayOfWeek()
        {
            InitializeComponent();

            cBCountDayOfMounthUpWeek.DataSource = hh[1];

            tBCountHoursOfTheDayDownWeek.Enabled = false;
            cBCountDayOfMounthDownWeek.Enabled = false;
        }

        private List<string[]> hh = new List<string[]>
        {
            new string[] { "2", "3" },
            new string[] { "4", "5" }
        };

        [Category("Behavior")]
        [Description("Указывает, включено ли разделение на недели.")]
        public bool DivisionEnabled { get { return checkBWeeklyDivision.Checked; } }

        [Category("Data")]
        [Description("Общее количество часов для этого дня в месяц.")]
        public double TotalCountHours
        {
            get
            {
                if (checkBWeeklyDivision.Checked)
                    if (Convert.ToInt32(cBCountDayOfMounthUpWeek.SelectedItem) + Convert.ToInt32(cBCountDayOfMounthDownWeek.SelectedItem) > 5)
                        throw new Exception("Количество дней в месяце не может быть больше 5!!");

                double totalHours = 0.0;

                totalHours += Convert.ToInt32(cBCountDayOfMounthUpWeek.SelectedItem) *
                                double.Parse(tBCountHoursOfTheDayUpWeek.Text);

                if (checkBWeeklyDivision.Checked)
                    totalHours += Convert.ToInt32(cBCountDayOfMounthDownWeek.SelectedItem) *
                                double.Parse(tBCountHoursOfTheDayDownWeek.Text);

                return totalHours;
            }
        }

        private void checkBWeeklyDivision_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBWeeklyDivision.Checked)
            {
                cBCountDayOfMounthUpWeek.DataSource = hh[0];

                tBCountHoursOfTheDayDownWeek.Enabled = true;
                cBCountDayOfMounthDownWeek.Enabled = true;

            }
            else
            {
                cBCountDayOfMounthUpWeek.DataSource = hh[1];

                tBCountHoursOfTheDayDownWeek.Text = "";
                tBCountHoursOfTheDayDownWeek.Enabled = false;
                cBCountDayOfMounthDownWeek.Enabled = false;
            }
        }

        private void tBCountHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
