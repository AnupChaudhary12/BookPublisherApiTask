using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisher.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        async Task<Dto.BookDto> IBookService.GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        async Task<Dto.BookDto> IBookService.CreateBookAsync(BookCreateDto bookCreateDto)
        {
            return await _bookRepository.CreateBookAsync(bookCreateDto);
        }

        public async Task<Dto.BookDto> UpdateBookAsync(int id, Dto.BookDto bookDto)
        {
            return await _bookRepository.UpdateBookAsync(id, bookDto);
        }

        async Task<Dto.BookDto> IBookService.DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<PublisherDto> GetPublisherByBookAsync(int bookId)
        {
            return await _bookRepository.GetPublisherByBookAsync(bookId);
        }

        async Task<IEnumerable<Dto.BookDto>> IBookService.GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }
    }
}
