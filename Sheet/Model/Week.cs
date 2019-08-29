using System;
using System.Linq;
using System.Collections.Generic;

namespace Sheet
{
	public enum DayOfWeek
    {
		Monday = 0,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
    }    
		
    internal class Week
    {
        private double[] dn = new double[7]; //дней в месяце
        private double[] dch = new double[7]; //количество часов в этот день

        internal double this[DayOfWeek day]
        {
            get
            {
                if (day < DayOfWeek.Monday || day > DayOfWeek.Sunday) throw new Exception("Week - double this[int index]");
                return dn[(int)day] * dch[(int)day];
            }
        }
		
		internal void SetWeek(IEnumerable<int> DayOfMonth, IEnumerable<int> HoursOfDay)
		{
			if(DayOfMonth.Count()>dn.Length) throw new Exception("SetWeek >>>");
			if(HoursOfDay.Count()>dch.Length) throw new Exception("SetWeek >>>");
			int i = 0;
			foreach(int a in DayOfMonth)
				dn[i++] = a;
			i=0;
			foreach(int a in HoursOfDay)
				dch[i++] = a;	
		}
    }

	
	public class WeekManager
	{
		private Week _upWeek;
		private Week _downWeek;
			
		public double this[DayOfWeek day]
        {
            get
            {
                if (day < DayOfWeek.Monday || day > DayOfWeek.Sunday) throw new Exception("WeekManager - double this[int index]");
                return _upWeek[day] + _downWeek[day];
            }
        }	

		public void SetUpWeek(IEnumerable<int> DayOfMonth, IEnumerable<int> HoursOfDay)
		{
            _upWeek.SetWeek(DayOfMonth, HoursOfDay);
		}
		
		public void SetDownWeek(IEnumerable<int> DayOfMonth, IEnumerable<int> HoursOfDay)
		{
            _downWeek.SetWeek(DayOfMonth, HoursOfDay);
		}
	}
}
