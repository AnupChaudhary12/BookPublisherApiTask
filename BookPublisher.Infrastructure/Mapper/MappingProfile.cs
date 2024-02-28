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
            CreateMap<BookCreateDto, Book>();

            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<PublisherCreateDto, Publisher>();

        }
    }
}