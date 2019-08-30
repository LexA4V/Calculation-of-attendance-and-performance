using System;

namespace Sheet
{
    class Model
    {
        public double Performance(int countStudets, int countStudents345)
        {
            if (countStudets < 0 || countStudents345 < 0) throw new System.ArgumentException("Количество учеников должно быть больше нуля!");

            if (countStudets < countStudents345) throw new System.ArgumentException("Количество учеников учащихся на 3, 4, 5 должно быть меньше общего количества студентов!");

            return countStudents345 * 100.0 / countStudets;
        }

        public double KnowledgeQuality(int countStudets, int countStudents45)
        {
            if (countStudets < 0 || countStudents45 < 0) throw new System.ArgumentException("Количество учеников должно быть больше нуля!");

            if (countStudets < countStudents45) throw new System.ArgumentException("Количество учеников учащихся на 4, 5 должно быть меньше общего количества учеников!");

            return countStudents45 * 100.0 / countStudets;
        }



        public double GetHourOfMounth(int countStudents, params double[] arr)
        {
            double Sum = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= 0 || arr[i] > 120)
                    throw new ArgumentOutOfRangeException("Вышло за рамки возможных значений!");
                Sum += arr[i];
            }

            return Sum * countStudents;
        }

        public double Attendance(double menHours, double countAttendance)
		{
            if (menHours < 0 || countAttendance < 0) throw new ArgumentException("Количество пропусков и количество часов должны быть больше нуля!");
            if (menHours - 2 * countAttendance < 0) throw new ArgumentException("Количество пропусков превышает количество часов!");

            return (menHours - 2 * countAttendance) * 100.0 / menHours;
		}

        public double Omissions(double menHours, double countOmissions)
        {
            if (menHours < 0 || countOmissions < 0) throw new ArgumentException("Количество проогулов и количество часов должны быть больше нуля!");
            if (menHours - 2 * countOmissions < 0) throw new ArgumentException("Количество проогулов превышает количество часов!");

            return (menHours - 2 * countOmissions) * 100.0 / menHours;
        }
    }
}
