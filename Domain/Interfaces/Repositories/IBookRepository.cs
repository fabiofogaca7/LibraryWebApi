using LibraryApi.Domain.Entities;

namespace LibraryApi.Domain.Repositories.Interfaces;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();

    Book GetById(int id);

    void Add(Book book);

    void Update(Book book);

    void Delete(int id);

    IEnumerable<Book> SearchByName(string bookName);

    IEnumerable<Book> SearchByAuthor(string bookAuthor);
}
