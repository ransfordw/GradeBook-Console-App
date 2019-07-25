using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class GradeBook
    {
        private readonly List<double> _grades;
        public string Name;
        private GradeBookStatistic _stats;

        public GradeBook(string name)
        {
            Name = name;
            _stats = new GradeBookStatistic();
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
                _grades.Add(grade);
                else
                Console.WriteLine("The grade could not be added.");
        }

        public GradeBookStatistic GetGradeBookStatistics()
        {
            var result = 0.0;
            foreach (var grade in _grades)
            {
                _stats.High = Math.Max(grade, _stats.High);
                _stats.Low = Math.Min(grade, _stats.Low);
                result += grade;
            }
            _stats.Average = result / _grades.Count;
            return _stats;
        }

        public double GetAverageGrade()
        {
            return _stats.Average;
        }
    }
}