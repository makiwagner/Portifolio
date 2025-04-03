using FluentAssertions;
using LibraryApp.Api.Controllers;
using LibraryApp.Application.Commands;
using LibraryApp.Application.Handlers;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryApp.UnitTests;

public class BooksControllerTests
{
    [Fact]
    public async Task AddBook_ShouldReturnCreatedAtAction()
    {
        // Arrange
        var mockHandler = new Mock<AddBookCommandHandler>(Mock.Of<IBookRepository>());
        var controller = new BookController(mockHandler.Object, Mock.Of<IBookRepository>());

        var command = new AddBookCommand
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Year = 2008
        };

        // Act
        var result = await controller.AddBook(command);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();
        var createdAtResult = result as CreatedAtActionResult;
        createdAtResult.Value.Should().Be(command);
    }

    [Fact]
    public async Task GetBookById_ShouldReturnNotFound_WhenBookDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Book)null);

        // Crie uma instância do handler manualmente, passando o mock do repositório
        var handler = new AddBookCommandHandler(mockRepo.Object);
        var controller = new BookController(handler, mockRepo.Object);

        // Act
        var result = await controller.GetBookById(999);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }
}