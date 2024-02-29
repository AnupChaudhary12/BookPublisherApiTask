using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisher.Infrastructure.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookPublisherDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(BookPublisherDbContext context, IMapper mapper, ILogger<BookRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<Application.Dto.BookDto>> GetAllBooksAsync()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return _mapper.Map<IEnumerable<Application.Dto.BookDto>>(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting all books");
                throw;
            }
        }

        public async Task<Application.Dto.BookDto> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                return _mapper.Map<Application.Dto.BookDto>(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting book by id");
                throw;
            }
        }

        public async Task<Application.Dto.BookDto> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            try
            {
                var existingISBNbooks = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == bookCreateDto.ISBN);
                if (existingISBNbooks != null)
                {
                    throw new InvalidOperationException("BookDto already exist with same ISBN");
                }

                var existingBook = await _context.Books.FirstOrDefaultAsync(b =>
                    b.Title == bookCreateDto.Title &&
                    b.Author == bookCreateDto.Author &&
                    b.ISBN == bookCreateDto.ISBN &&
                    b.PublishedDate == bookCreateDto.PublishedDate &&
                    b.PublisherId == bookCreateDto.PublisherId);
                if (existingBook != null)
                {
                    throw new InvalidOperationException(
                        "BookDto already exist with same Title, Author, PublishedDate, Edition, PublisherId");
                }

                var differentBook = await _context.Books.FirstOrDefaultAsync(b =>
                    b.PublishedDate != bookCreateDto.PublishedDate ||
                    b.Edition != bookCreateDto.Edition ||
                    b.ISBN != bookCreateDto.ISBN ||
                    b.PublisherId != bookCreateDto.PublisherId);
                if (differentBook != null)
                {
                    var book = _mapper.Map<BookDto>(bookCreateDto);
                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<Application.Dto.BookDto>(book);
                }
                else
                {
                    throw new InvalidOperationException(
                        "BookDto already exist with same Title, Author but different Edition, ISBN, PublisherId, PublishedDate");
                }
            }
            catch
            {
                _logger.LogError("Error while creating book");
                throw;
            }
        }

        public async Task<Application.Dto.BookDto> UpdateBookAsync(int id,Application.Dto.BookDto bookDto)
        {
            try
            {
                if (id != bookDto.Id)
                {
                    _logger.LogInformation("Id does not match!");
                    return null;
                }

                if (!_context.Books.Any(b => b.Id == id))
                    return null;

                var book = _mapper.Map<BookDto>(bookDto);

                _context.Entry(book).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return _mapper.Map<Application.Dto.BookDto>(book);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, nameof(UpdateBookAsync));
                return null;
            }

        }

        public async Task<Application.Dto.BookDto> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book is null)
                    return null;
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return _mapper.Map<Application.Dto.BookDto>(book);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, nameof(DeleteBookAsync));
                return null;
            }
        }

        public async Task<PublisherDto> GetPublisherByBookAsync(int bookId)
        {
            try
            {
                var publisher = await _context.Publishers.Include(p => p.Books)
                    .FirstOrDefaultAsync(p => p.Books.Any(b => b.Id == bookId));
                return _mapper.Map<PublisherDto>(publisher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting publisher by book");
                throw;
            }
        }

    }
}
