using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryGradeBook : Book, IBook
    {
        public override event GradeAddedDelegate GradeAdded;
        private readonly List<double> _grades;

        public InMemoryGradeBook(string name) : base(name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
        }

        public override GradeBookStatistic GetGradeBookStatistics()
        {
            var stats = new GradeBookStatistic();
            foreach (var grade in _grades)
                stats.Add(grade);

            return stats;
        }
    }
}