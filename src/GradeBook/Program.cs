using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double> { 12.7, 34.1, 73.2 ,45.5, 23.3};
            var result = 0.0;

            foreach (var grade in grades)
                result += grade;

            var avg = result / grades.Count;

            Console.WriteLine($"The average grade is {avg:N1}.");

            if (args.Length > 0)
                Console.WriteLine($"Hello, {args[0]}!");
            else
                Console.WriteLine("Hello!");
        }
    }
}
