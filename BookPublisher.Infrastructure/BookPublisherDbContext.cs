using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Infrastructure
{
    public class BookPublisherDbContext: DbContext
    {
        public BookPublisherDbContext(DbContextOptions<BookPublisherDbContext> options) : base(options)
        {
        }
    }
}
