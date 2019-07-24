using System;
using Xunit;

namespace GradeBook.Tests
{
    // Run tests by changing into the directory for the test project
    // In the cli type "dotnet test" 
    // If a sln exists, make that the directory
    public class StringTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Ransford";
            var upperName = MakeUpperCase(name);

            Assert.Equal("RANSFORD", upperName);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
    }
}
