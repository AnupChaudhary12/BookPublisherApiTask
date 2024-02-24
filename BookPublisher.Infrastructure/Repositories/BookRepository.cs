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

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void DeleteBook(int id)
        {
            if(_context.Books.Find(id) != null)
                _context.Books.Remove(_context.Books.Find(id));
        }

        public async Task<Publisher> GetPublisherByBook(int bookId)
        {
            var publisher = await _context.Publishers.Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Books.Any(b => b.Id == bookId));
            return publisher;
        }
    }
}
