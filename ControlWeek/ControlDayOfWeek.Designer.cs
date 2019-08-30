namespace ControlWeekS
{
    partial class ControlDayOfWeek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cBCountDayOfMounthDownWeek = new System.Windows.Forms.ComboBox();
            this.tBCountHoursOfTheDayDownWeek = new System.Windows.Forms.TextBox();
            this.tBCountHoursOfTheDayUpWeek = new System.Windows.Forms.TextBox();
            this.cBCountDayOfMounthUpWeek = new System.Windows.Forms.ComboBox();
            this.checkBWeeklyDivision = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cBCountDayOfMounthDownWeek
            // 
            this.cBCountDayOfMounthDownWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCountDayOfMounthDownWeek.Enabled = false;
            this.cBCountDayOfMounthDownWeek.FormattingEnabled = true;
            this.cBCountDayOfMounthDownWeek.Location = new System.Drawing.Point(4, 111);
            this.cBCountDayOfMounthDownWeek.Margin = new System.Windows.Forms.Padding(4);
            this.cBCountDayOfMounthDownWeek.Name = "cBCountDayOfMounthDownWeek";
            this.cBCountDayOfMounthDownWeek.Size = new System.Drawing.Size(26, 21);
            this.cBCountDayOfMounthDownWeek.TabIndex = 61;
            // 
            // tBCountHoursOfTheDayDownWeek
            // 
            this.tBCountHoursOfTheDayDownWeek.Enabled = false;
            this.tBCountHoursOfTheDayDownWeek.Location = new System.Drawing.Point(4, 83);
            this.tBCountHoursOfTheDayDownWeek.Margin = new System.Windows.Forms.Padding(4);
            this.tBCountHoursOfTheDayDownWeek.MaxLength = 2;
            this.tBCountHoursOfTheDayDownWeek.Name = "tBCountHoursOfTheDayDownWeek";
            this.tBCountHoursOfTheDayDownWeek.Size = new System.Drawing.Size(26, 20);
            this.tBCountHoursOfTheDayDownWeek.TabIndex = 59;
            this.tBCountHoursOfTheDayDownWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBCountHoursOfTheDayDownWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBCountHours_KeyPress);
            // 
            // tBCountHoursOfTheDayUpWeek
            // 
            this.tBCountHoursOfTheDayUpWeek.Location = new System.Drawing.Point(4, 33);
            this.tBCountHoursOfTheDayUpWeek.Margin = new System.Windows.Forms.Padding(4);
            this.tBCountHoursOfTheDayUpWeek.MaxLength = 2;
            this.tBCountHoursOfTheDayUpWeek.Name = "tBCountHoursOfTheDayUpWeek";
            this.tBCountHoursOfTheDayUpWeek.Size = new System.Drawing.Size(26, 20);
            this.tBCountHoursOfTheDayUpWeek.TabIndex = 58;
            this.tBCountHoursOfTheDayUpWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBCountHoursOfTheDayUpWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBCountHours_KeyPress);
            // 
            // cBCountDayOfMounthUpWeek
            // 
            this.cBCountDayOfMounthUpWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCountDayOfMounthUpWeek.FormattingEnabled = true;
            this.cBCountDayOfMounthUpWeek.Location = new System.Drawing.Point(4, 4);
            this.cBCountDayOfMounthUpWeek.Margin = new System.Windows.Forms.Padding(4);
            this.cBCountDayOfMounthUpWeek.Name = "cBCountDayOfMounthUpWeek";
            this.cBCountDayOfMounthUpWeek.Size = new System.Drawing.Size(26, 21);
            this.cBCountDayOfMounthUpWeek.TabIndex = 57;
            // 
            // checkBWeeklyDivision
            // 
            this.checkBWeeklyDivision.AutoSize = true;
            this.checkBWeeklyDivision.Location = new System.Drawing.Point(11, 61);
            this.checkBWeeklyDivision.Margin = new System.Windows.Forms.Padding(4);
            this.checkBWeeklyDivision.Name = "checkBWeeklyDivision";
            this.checkBWeeklyDivision.Size = new System.Drawing.Size(15, 14);
            this.checkBWeeklyDivision.TabIndex = 60;
            this.checkBWeeklyDivision.UseVisualStyleBackColor = true;
            this.checkBWeeklyDivision.CheckedChanged += new System.EventHandler(this.checkBWeeklyDivision_CheckedChanged);
            // 
            // ControlDayOfWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cBCountDayOfMounthDownWeek);
            this.Controls.Add(this.checkBWeeklyDivision);
            this.Controls.Add(this.tBCountHoursOfTheDayDownWeek);
            this.Controls.Add(this.tBCountHoursOfTheDayUpWeek);
            this.Controls.Add(this.cBCountDayOfMounthUpWeek);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlDayOfWeek";
            this.Size = new System.Drawing.Size(34, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cBCountDayOfMounthDownWeek;
        private System.Windows.Forms.TextBox tBCountHoursOfTheDayDownWeek;
        private System.Windows.Forms.TextBox tBCountHoursOfTheDayUpWeek;
        private System.Windows.Forms.ComboBox cBCountDayOfMounthUpWeek;
        private System.Windows.Forms.CheckBox checkBWeeklyDivision;
    }
}
