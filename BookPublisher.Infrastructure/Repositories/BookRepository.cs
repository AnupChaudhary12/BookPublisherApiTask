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

namespace BookPublisher.Infrastructure.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookPublisherDbContext _context;
        public BookRepository(BookPublisherDbContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            List<Book> books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task<Book> CreateBook(Book book)
        {
            var existingISBNbooks = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == book.ISBN);
            if (existingISBNbooks != null)
            {
                throw new InvalidOperationException("Book already exist with same ISBN");
            }
            else
            {
                var existingBook = await _context.Books.FirstOrDefaultAsync(b =>
                    b.Title == book.Title &&
                    b.Author == book.Author &&
                    b.ISBN == book.ISBN &&
                    b.PublishedDate == book.PublishedDate &&
                    b.PublisherId == book.PublisherId);
                if (existingBook != null)
                {
                    throw new InvalidOperationException(
                        "Book already exist with same Title, Author, PublishedDate, Edition, PublisherId");
                }
                else
                {
                    var differentBook = await _context.Books.FirstOrDefaultAsync(b =>
                        b.PublishedDate != book.PublishedDate ||
                        b.Edition != book.Edition ||
                        b.ISBN != book.ISBN ||
                        b.PublisherId != book.PublisherId);
                    if (differentBook != null)
                    {
                        var bookEntity = await _context.Books.AddAsync(book);
                        await _context.SaveChangesAsync();
                        return bookEntity.Entity;

                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "Book already exist with same Title, Author but different Edition, ISBN, PublisherId, PublishedDate");
                    }
                }

            }
            

        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public async Task<Publisher> GetPublisherByBook(int bookId)
        {
            var publisher = await _context.Publishers.Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Books.Any(b => b.Id == bookId));
            return publisher;
        }

    }
}
