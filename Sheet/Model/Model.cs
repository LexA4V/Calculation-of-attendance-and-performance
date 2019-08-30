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
		
		
		public double Performance(int countStudets, int countStudents345)
		{
            if (countStudets < 0 || countStudents345 < 0) throw new System.ArgumentException("Количество учеников должно быть больше нуля!");

            if (countStudets < countStudents345) throw new System.ArgumentException("Количество учеников учащихся на 3, 4, 5 должно быть меньше общего количества студентов!");
			
			return countStudents345*100.0/countStudets;
		}	

		public double KnowledgeQuality(int countStudets, int countStudents45)
		{
            if (countStudets<0 || countStudents45<0) throw new System.ArgumentException("Количество учеников должно быть больше нуля!");

            if (countStudets < countStudents45) throw new System.ArgumentException("Количество учеников учащихся на 4, 5 должно быть меньше общего количества учеников!");

            return countStudents45 * 100.0 / countStudets;
        }
    }
}
