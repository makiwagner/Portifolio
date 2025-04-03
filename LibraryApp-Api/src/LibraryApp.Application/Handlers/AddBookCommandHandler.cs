using LibraryApp.Application.Commands;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Handlers;

public class AddBookCommandHandler
{
    private readonly IBookRepository _bookRepository;

    public AddBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task Handle(AddBookCommand command)
    {
        var book = new Book(command.Title, command.Author, command.Year);
        await _bookRepository.AddAsync(book);
    }
}