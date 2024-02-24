using System;
using System.Collections.Generic;
using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            

            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<PublisherDto, Publisher>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}