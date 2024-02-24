using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, List<BookDto>>();
            CreateMap<BookDto, List<Book>>();
            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.Select(b => b.Id)));
        }
    }
}
