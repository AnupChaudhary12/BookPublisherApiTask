using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;
using BookDto = BookPublisher.Application.Dto.BookDto;

namespace BookPublisher.Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(BookCreateDto book);
        Task<BookDto> UpdateBookAsync(int id,BookDto book);
        Task<BookDto> DeleteBookAsync(int id);

        Task<PublisherDto> GetPublisherByBookAsync(int bookId);

    }
}
