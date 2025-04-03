using FluentAssertions;
using LibraryApp.Domain.Entities;

namespace LibraryApp.UnitTests;

public class BookTest
{
    [Fact]
        public void Book_ShouldBeCreated_WithValidProperties()
        {
            // Arrange & Act
            var book = new Book("Clean Code", "Robert C. Martin", 2008);

            // Assert
            book.Title.Should().Be("Clean Code");
            book.Author.Should().Be("Robert C. Martin");
            book.Year.Should().Be(2008);
        }

        [Fact]
        public void Book_ShouldThrowException_WhenTitleIsEmpty()
        {
            // Arrange & Act
            Action act = () => new Book("", "Robert C. Martin", 2008);

            // Assert
            act.Should().Throw<ArgumentException>()
                .Where(ex => ex.Message.Contains("Title cannot be empty"));
        }
}