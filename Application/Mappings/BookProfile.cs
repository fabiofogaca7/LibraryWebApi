using AutoMapper;
using LibraryApi.Application.Dtos;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<BookDto, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
    }
}
