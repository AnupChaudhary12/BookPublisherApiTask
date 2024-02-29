using System;
using System.Collections.Generic;
using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisher.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, Application.Dto.BookDto>().ReverseMap();
            CreateMap<BookCreateDto, BookDto>();

            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<PublisherCreateDto, Publisher>();


        }
    }
}