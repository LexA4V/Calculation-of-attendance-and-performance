namespace Sheet
{
    class Model
    {
        int CountStudents;

        UpWeek u = null;
        DownWeek d = null;

        public virtual double GetHourOfMounth()
        {
            double Sum = 0;
            for (Week.DayOfWeek i = Week.DayOfWeek.Monday; i <= Week.DayOfWeek.Friday; i++)
                Sum += u[i];
            if(d != null)
                for (Week.DayOfWeek i = Week.DayOfWeek.Monday; i <= Week.DayOfWeek.Friday; i++)
                    Sum += d[i];
            return Sum;
        }

    }

    



}
