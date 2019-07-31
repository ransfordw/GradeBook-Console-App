using System;

namespace GradeBook
{
    public class GradeBookStatistic
    {
        public double Average { get => Sum / Count; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Sum { get; set; }
        public int Count { get; set; }
        public char LetterGrade
        {
            get
            {
                switch (Average)
                {
                    case var d when d > 90.0:
                        return 'A';
                    case var d when d > 80.0:
                        return 'B';
                    case var d when d > 70.0:
                        return 'C';
                    case var d when d > 60.0:
                        return 'D';
                    case var d when d > 50.0:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }
        
        public GradeBookStatistic()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
    }
}