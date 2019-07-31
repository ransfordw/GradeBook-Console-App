using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override GradeBookStatistic GetGradeBookStatistics()
        {
            var stats = new GradeBookStatistic();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                while(!reader.EndOfStream)
                stats.Add(double.Parse(reader.ReadLine()));
            }
            return stats;
        }
    }
}