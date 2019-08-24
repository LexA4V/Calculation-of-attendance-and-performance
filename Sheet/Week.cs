using System;

namespace Sheet
{
    abstract class Week
    {
        public enum DayOfWeek
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4
            //Saturday = 5,
            //Sunday = 6
        }

        double[] dn = new double[5]; //дней в месяце
        double[] dch = new double[5]; //количество часов в этот день

        public virtual double this[DayOfWeek day]
        {
            get
            {
                if ((int)day < 0 || (int)day > 4) throw new Exception("Week - double this[int index]");
                return dn[(int)day] * dch[(int)day];
            }
        }


    }

    class UpWeek : Week
    {
    }

    class DownWeek : Week
    {
    }
}
