using LibraryApi.Application.Dtos;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Domain.Interfaces.Services;

public interface IBookService
{
    IEnumerable<BookDto> GetAll();

    BookDto GetById(int id);

    void Add(BookDto livroDto);

    void Update(int id, BookDto livroDto);

    void Delete(int id);

    IEnumerable<BookDto> SearchByName(string bookName);

    IEnumerable<BookDto> SearchByAuthor(string bookAuthor);
}
