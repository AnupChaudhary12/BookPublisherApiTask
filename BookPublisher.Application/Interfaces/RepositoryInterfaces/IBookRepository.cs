﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);

        Task<Publisher> GetPublisherByBook(int bookId);

    }
}
