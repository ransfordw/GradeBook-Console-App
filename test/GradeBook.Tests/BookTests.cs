using System;
using Xunit;

namespace GradeBook.Tests
{
    // Run tests by changing into the directory for the test project
    // In the cli type "dotnet test" 
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            Book book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var result = book.GetGradeBookStatistics();

            // Assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
