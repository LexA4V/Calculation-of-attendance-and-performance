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

            cBCountDayOfMounthUpWeek.DataSource = CountDayOfMounth["oneWeek"];

            tBCountHoursOfTheDayDownWeek.Enabled = false;
            cBCountDayOfMounthDownWeek.Enabled = false;
        }

        private Dictionary<string, string[]> CountDayOfMounth = new Dictionary<string, string[]>
        {
            ["oneWeek"] = new string[] { "4", "5"},
            ["twoWeek"] = new string[] { "2", "3"}
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
                int countDayOfMounthUpWeek = Convert.ToInt32(cBCountDayOfMounthUpWeek.SelectedItem);
                double countHoursOfTheDayUpWeek = double.Parse(tBCountHoursOfTheDayUpWeek.Text);

                int countDayOfMounthDownWeek = 0;
                double countHoursOfTheDayDownWeek = 0;

                if (checkBWeeklyDivision.Checked)
                {
                    countDayOfMounthDownWeek = Convert.ToInt32(cBCountDayOfMounthDownWeek.SelectedItem);
                    countHoursOfTheDayDownWeek = double.Parse(tBCountHoursOfTheDayDownWeek.Text);
                }

                if (countDayOfMounthUpWeek + countDayOfMounthDownWeek > 5)
                    throw new ArgumentException("Количество дней в месяце не может быть больше 5!!");

                if (countHoursOfTheDayUpWeek > 24 || countHoursOfTheDayDownWeek > 24)
                    throw new ArgumentException("В сутках не больше 24 часов!");

                double totalHours = 0.0;

                totalHours = countDayOfMounthUpWeek * countHoursOfTheDayUpWeek;

                if (checkBWeeklyDivision.Checked)
                    totalHours += countDayOfMounthDownWeek * countHoursOfTheDayDownWeek / 2;

                return totalHours;
            }
        }

        private void checkBWeeklyDivision_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBWeeklyDivision.Checked)
            {
                cBCountDayOfMounthUpWeek.DataSource = CountDayOfMounth["twoWeek"];
                cBCountDayOfMounthDownWeek.DataSource = CountDayOfMounth["twoWeek"];

                tBCountHoursOfTheDayDownWeek.Enabled = true;
                cBCountDayOfMounthDownWeek.Enabled = true;

            }
            else
            {
                cBCountDayOfMounthUpWeek.DataSource = CountDayOfMounth["oneWeek"];
                cBCountDayOfMounthDownWeek.DataSource = null;

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
