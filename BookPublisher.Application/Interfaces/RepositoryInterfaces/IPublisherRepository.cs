using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Application.Interfaces.RepositoryInterfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(int id);
        Task<IEnumerable<Book>> GetBooksByPublisher(int publisherId);

    }
}
