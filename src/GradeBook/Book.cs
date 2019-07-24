using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private readonly List<double> _grades;
        private readonly string _name;
        private GradeBookStatistic _stats;

        public Book(string name)
        {
            this._name = name;
            _stats = new GradeBookStatistic();
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
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
            _stats.Average = result/_grades.Count;
            return _stats;
        }

        public double GetAverageGrade()
        {
            return _stats.Average;
        }
    }
}