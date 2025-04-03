using LibraryApp.Application.Commands;
using LibraryApp.Application.Handlers;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AddBookCommandHandler _addBookCommandHandler;
    private readonly IBookRepository _bookRepository;

    public BookController(AddBookCommandHandler addBookCommandHandler, IBookRepository bookRepository)
    {
        _addBookCommandHandler = addBookCommandHandler;
        _bookRepository = bookRepository;
    }

    // GET: api/Book
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
    {
        var books = await _bookRepository.GetAllAsync();
        return Ok(books);
    }

    // GET: api/Book/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return NotFound();
        return Ok(book);
    }

    // POST: api/Book
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _addBookCommandHandler.Handle(command);
        return CreatedAtAction(nameof(GetBookById), new { id = command.Title }, command);
    }

    // PUT: api/Book/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
    {
        if (id != updatedBook.Id)
            return BadRequest("ID mismatch");

        var existingBook = await _bookRepository.GetByIdAsync(id);
        if (existingBook is null)
            return NotFound();

        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Year = updatedBook.Year;

        await _bookRepository.UpdateAsync(existingBook);
        return NoContent();
    }

    // DELETE: api/Book/{id}
    [HttpDelete("id")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return NotFound();

        await _bookRepository.DeleteAsync(id);
        return NoContent();
    }
}