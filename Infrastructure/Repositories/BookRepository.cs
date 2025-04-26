using LibraryApi.Domain.Entities;
using LibraryApi.Domain.Repositories.Interfaces;
using LibraryApi.Infrastructure.Data;

namespace LibraryApi.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;
    private int _nextId = 1;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Book.Add(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.Book.Find(id);
        if (book != null) 
        {
            _context.Book.Remove(book);
            _context.SaveChanges();
        }        
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Book.ToList();
    }

    public Book GetById(int id)
    {
        return _context.Book.Find(id);
    }

    public void Update(Book book)
    {
        var existingBook = _context.Book.Find(book.Id);
        if (existingBook != null)
        {
            _context.Book.Update(existingBook);
            _context.SaveChanges();
        }
    }
}
