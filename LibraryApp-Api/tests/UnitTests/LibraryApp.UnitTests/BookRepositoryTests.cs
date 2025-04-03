using FluentAssertions;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.UnitTests;

public class BookRepositoryTests
{
[Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("Clean Code", "Robert C. Martin", 2008),
                new Book("Clean Architecture", "Robert C. Martin", 2017)
            };

            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new LibraryDbContext(options);
            context.Books.AddRange(books);
            context.SaveChanges();

            var repository = new BookRepository(context);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().ContainEquivalentOf(books[0]);
            result.Should().ContainEquivalentOf(books[1]);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBookById()
        {
            // Arrange
            var book = new Book("Clean Code", "Robert C. Martin", 2008);

            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new LibraryDbContext(options);
            context.Books.Add(book);
            context.SaveChanges();

            var repository = new BookRepository(context);

            // Act
            var result = await repository.GetByIdAsync(book.Id);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be("Clean Code");
        }
}