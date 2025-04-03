using LibraryApp.Application.Commands;
using LibraryApp.Application.Handlers;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using Moq;

namespace LibraryApp.UnitTests;

public class AddBookCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallAddAsyncOnRepository()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        var handler = new AddBookCommandHandler(mockRepo.Object);
        var command = new AddBookCommand
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Year = 2008
        };

        // Act
        await handler.Handle(command);

        // Assert
        mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Book>()), Times.Once);
    }
}
