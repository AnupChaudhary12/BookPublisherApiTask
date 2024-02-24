using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Application.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book =await _bookRepository.GetBookById(id);
            return book;
        }

        public async Task<Book> CreateBook(Book book)
        {
            var createdBook = await _bookRepository.CreateBook(book);
            return createdBook;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var updatedBook = await _bookRepository.UpdateBook(book);
            return updatedBook;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var deletedBook =await _bookRepository.DeleteBook(id);
            return deletedBook;

        }

        public async Task<Publisher> GetPublisherByBook(int bookId)
        {
            var publisher = await _bookRepository.GetPublisherByBook(bookId);
            return publisher;
        }
    }
}
