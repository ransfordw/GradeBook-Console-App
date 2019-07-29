using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class GradeBook
    {
        private readonly List<double> _grades;
        public string Name { get; private set; }
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
                throw new ArgumentException($"Invalid {nameof(grade)}");
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

            switch (_stats.Average)
            {
                case var d when d > 90.0:
                    _stats.LetterGrade = 'A';
                    break;
                case var d when d > 80.0:
                    _stats.LetterGrade = 'B';
                    break;
                case var d when d > 70.0:
                    _stats.LetterGrade = 'C';
                    break;
                case var d when d > 60.0:
                    _stats.LetterGrade = 'D';
                    break;
                case var d when d > 50.0:
                    _stats.LetterGrade = 'E';
                    break;
                default:
                    _stats.LetterGrade = 'F';
                    break;

            }

            return _stats;
        }

        public double GetAverageGrade()
        {
            return _stats.Average;
        }
    }
}