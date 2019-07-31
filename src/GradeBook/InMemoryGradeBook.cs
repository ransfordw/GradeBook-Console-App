using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryGradeBook : Book, IBook
    {
        public override event GradeAddedDelegate GradeAdded;
        private readonly List<double> _grades;
        private GradeBookStatistic _stats;

        public InMemoryGradeBook(string name) : base(name)
        {
            Name = name;
            _stats = new GradeBookStatistic();
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