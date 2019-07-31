using System;
using Xunit;

namespace GradeBook.Tests
{
    // Run tests by changing into the directory for the test project
    // In the cli type "dotnet test" 
    // If a sln exists, make that the directory
    public class GradeBookTests
    {
        [Fact]
        public void GradeBook_GetGradeBookStatistics_CalculatesStatsFromGradeBookList()
        {
            // Arrange
            InMemoryGradeBook book = new InMemoryGradeBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var result = book.GetGradeBookStatistics();

            // Assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B',result.LetterGrade);
        }

        [Fact]
        public void GradeBook_AddGrade_AddsGradeToGradesList()
        {
            var book = new InMemoryGradeBook("test");
            book.AddGrade(30.0);

            var expected = 30.0;
            var actual = book.GetGradeBookStatistics().Average;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GradeBook_AddGrade_ThrowsErrorIfValueNotBetween0And100()
        {
            var book = new InMemoryGradeBook("test");

            ArgumentException ex = Assert.Throws<ArgumentException>(() => book.AddGrade(130.0));

            Assert.Equal("Invalid grade",ex.Message);
        }
    }
}
