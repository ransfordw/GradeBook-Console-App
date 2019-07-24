namespace GradeBook
{
    public class GradeBookStatistic
    {
        public double Average { get; set; }  
        public double High { get; set; }
        public double Low { get; set; }

        public GradeBookStatistic()
        {
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}