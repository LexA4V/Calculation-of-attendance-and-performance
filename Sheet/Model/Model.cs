namespace Sheet
{
    class Model
    {
        int CountStudents;

        WeekManager _weeks = new WeekManager();

		public WeekManager Weeks { get{return _weeks;}}
		
        public double GetHourOfMounth()
        {
            double Sum = 0;
            for (DayOfWeek i = DayOfWeek.Monday; i <= DayOfWeek.Friday; i++)
                Sum += _weeks[i];
            return Sum;
        }
		
		public double Посещаемость(double chch, double posechaemost)
		{
			if(chch - 2 * posechaemost<0) return -1;
			
			return (chch - 2 * posechaemost) * 100.0 / chch;
		}
		
		
		public double Успеваемость(int countStudets, int countStudents345)
		{
			if(countStudets < countStudents345) return -1;
			
			return countStudents345*100.0/countStudets;
		}	

		public double Качество(int countStudets, int countStudents45)
		{
			return Успеваемость(countStudets, countStudents45);
		}


    }

    



}
