using AutoMapper;
using LibraryApi.Application.Dtos;
using LibraryApi.Domain.Entities;
using LibraryApi.Domain.Interfaces.Services;
using LibraryApi.Domain.Repositories.Interfaces;

namespace LibraryApi.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public void Add(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        book.CreatedDate = DateTime.Now;
        _bookRepository.Add(book);
    }

    public void Delete(int id)
    {
        _bookRepository.Delete(id);
    }

    public IEnumerable<BookDto> GetAll()
    {
        var books = _bookRepository.GetAll();
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }

    public BookDto GetById(int id)
    {
        var book = _bookRepository.GetById(id);
        return _mapper.Map<BookDto>(book);
    }

    public void Update(int id, BookDto bookDto)
    {
        var existingBook = _bookRepository.GetById(id);
        if (existingBook != null)
        {
            _mapper.Map(bookDto, existingBook);
            existingBook.Id = id;
            _bookRepository.Update(existingBook);
        }
    }

    public IEnumerable<BookDto> SearchByName(string bookName)
    {
        var books = _bookRepository.SearchByName(bookName);
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }

    public IEnumerable<BookDto> SearchByAuthor(string bookAuthor)
    {
        var books = _bookRepository.SearchByAuthor(bookAuthor);
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }
}
