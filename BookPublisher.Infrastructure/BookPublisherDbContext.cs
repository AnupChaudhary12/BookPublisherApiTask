using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Infrastructure
{
    public class BookPublisherDbContext: DbContext
    {
        public BookPublisherDbContext(DbContextOptions<BookPublisherDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
