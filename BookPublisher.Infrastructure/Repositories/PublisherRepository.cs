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

        public void CreatePublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            //_context.Publishers.Update(publisher);
            _context.Entry(publisher).State = EntityState.Modified;
        }

        public void DeletePublisher(int id)
        {
            _context.Publishers.Remove(_context.Publishers.Find(id));
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisher(int publisherId)
        {
            var books = await _context.Books.Where(b => b.PublisherId == publisherId).ToListAsync();
            return books;
        }
    }
}
