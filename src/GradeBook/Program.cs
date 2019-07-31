using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryGradeBook("Ransford's GradeBook");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetGradeBookStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}.");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The letter grade is {stats.LetterGrade}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter your grades: \n Enter \"q\" to exit.");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                    break;

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*This happens regardless of exceptions or successes.*");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was successfully added.");
        }
    }
}
