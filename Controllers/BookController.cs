using LibraryApi.Application.Dtos;
using LibraryApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookDto>> GetAll()
    {
        var books = _bookService.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<BookDto> GetById(int id)
    {
        var book = _bookService.GetById(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public ActionResult<BookDto> Add([FromBody] BookDto livroDto)
    {
        _bookService.Add(livroDto);
        return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] BookDto livroDto)
    {
        _bookService.Update(id, livroDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return NoContent();
    }

    [HttpGet("SearchByName")]
    public ActionResult<IEnumerable<BookDto>> SerachByName(string bookName)
    {
        var result = _bookService.SearchByName(bookName);
        return Ok(result);
    }

    [HttpGet("SearchByAuthor")]
    public ActionResult<IEnumerable<BookDto>> SearchByAuthor(string bookAuthor)
    {
        var result = _bookService.SearchByAuthor(bookAuthor);
        return Ok(result);
    }
}
