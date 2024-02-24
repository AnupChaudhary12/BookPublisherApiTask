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
            var bookCreated = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return bookCreated.Entity;
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
