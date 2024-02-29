using BookPublisher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookDto = BookPublisher.Application.Dto.BookDto;

namespace BookPublisher.Application.Interfaces.ServiceInterfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(BookCreateDto bookCreateDto);
        Task<BookDto> UpdateBookAsync(int id, BookDto bookDto);
        Task<BookDto> DeleteBookAsync(int id);
        Task<PublisherDto> GetPublisherByBookAsync(int bookId);
    }
}
