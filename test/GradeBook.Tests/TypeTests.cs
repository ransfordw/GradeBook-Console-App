using System;
using Xunit;

namespace GradeBook.Tests
{
    // Run tests by changing into the directory for the test project
    // In the cli type "dotnet test" 
    // If a sln exists, make that the directory
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoCanPassByRef()
        {
            var x = GetInt();
            SetInt(out x);
            Assert.Equal(42, x);
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void TypeTests_GetGradeBook_ReturnsDifferentObjects()
        {
            // Arrange
            var book = GetGradeBook("Book 1");
            var book2 = GetGradeBook("Book 2");

            // Act

            // Assert
            Assert.Equal("Book 1", book.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book, book2);
        }

        // [Fact]
        // public void CanSetNameFromReference()
        // {
        //     // Arrange
        //     var book = GetGradeBook("Book 1");

        //     // Act
        //     SetName(book, "New Name");

        //     // Assert
        //     Assert.Equal("New Name", book.Name);
        // }

        // private void SetName(GradeBook book, string newName)
        // {
        //     book.Name = newName;
        // }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book = GetGradeBook("Book 1");

            // Act
            GetBookAndSetName(ref book, "New Name");

            // Assert
            Assert.Equal("New Name", book.Name);
        }

        private void GetBookAndSetName(ref GradeBook book, string newName)
        {
            book = new GradeBook(newName);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book = GetGradeBook("Book 1");

            // Act
            GetBookAndSetName(book, "New Name");

            // Assert
            Assert.Equal("Book 1", book.Name);
        }

        private void GetBookAndSetName(GradeBook book, string newName)
        {
            book = new GradeBook(newName);
        }

        [Fact]
        public void TypeTests_TwoVarsCanReferenceSameObject_ReturnsSameObject()
        {
            // Arrange
            var book = GetGradeBook("Book 1");
            var book2 = book;

            // Act

            // Assert
            Assert.Same(book, book2);
            Assert.True(Object.ReferenceEquals(book, book2));
        }

        private GradeBook GetGradeBook(string bookName)
        {
            return new GradeBook(bookName);
        }
    }
}
