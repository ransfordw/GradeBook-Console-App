using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private readonly List<double> _grades;
        private readonly string _name;
        private double _highGrade;
        private double _lowGrade;
        private double _avgGrade;
        public Book(string name)
        {
            this._name = name;
            _avgGrade = 0.0;
            _lowGrade = double.MaxValue;
            _highGrade = double.MinValue;
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public void ShowStatistics()
        {
            CalculateStatistics();
            Console.WriteLine($"The average grade is {_avgGrade}.");
            Console.WriteLine($"The lowest grade is {_highGrade}.");
            Console.WriteLine($"The highest grade is {_lowGrade}.");
        }

        private void CalculateStatistics()
        {
            var result = 0.0;
            foreach (var grade in _grades)
            {
                _highGrade = Math.Max(grade, _highGrade);
                _lowGrade = Math.Min(grade, _lowGrade);
                result += grade;
            }
            _avgGrade = result/_grades.Count;
        }

        public double GetAverageGrade()
        {
            return _avgGrade;
        }
    }
}