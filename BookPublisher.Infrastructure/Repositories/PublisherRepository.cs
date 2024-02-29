using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Infrastructure.Repositories
{
    public class PublisherRepository: IPublisherRepository
    {
        private readonly BookPublisherDbContext _context;

        public PublisherRepository(BookPublisherDbContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            List<Publisher> publishers = await _context.Publishers.ToListAsync();
            return publishers;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            var publisher = await _context.Publishers.Where(p => p.Id == id).FirstOrDefaultAsync();
            return publisher;
        }

        public async Task<Publisher> CreatePublisher(Publisher publisher)
        {
            var publishers = await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publishers.Entity;
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            //_context.Publishers.Update(publisher);
            _context.Entry(publisher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }

            return publisher;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByPublisher(int publisherId)
        {
            var books = await _context.Books.Where(b => b.PublisherId == publisherId).ToListAsync();
            return books;
        }
    }
}
