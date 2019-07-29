using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            var book = new GradeBook("Ransford's GradeBook");
            Console.WriteLine("Enter your grades: \n Enter \"q\" to exit.");
            var input = "continue";
            while (input.ToLower() != "q")
            {
                input = Console.ReadLine();
                double grade;
                var isValid = double.TryParse(input, out grade);
                
                if (isValid)
                    book.AddGrade(grade);
                else
                    Console.WriteLine("Please enter a valid option.");
            }

            var stats = book.GetGradeBookStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}.");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The letter grade is {stats.LetterGrade}.");
        }
    }
}
