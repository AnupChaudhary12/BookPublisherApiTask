using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;

namespace BookPublisher.Application.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository= publisherRepository;
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishers();
            return publishers;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            return publisher;
        }

        public async Task<Publisher> CreatePublisher(Publisher publisher)
        {
            var createdPublisher = await _publisherRepository.CreatePublisher(publisher);
            return createdPublisher;
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            await _publisherRepository.UpdatePublisher(publisher);
            return publisher;
        }

        public async  Task<Publisher> DeletePublisher(int id)
        {
            var deletedPublisher = await _publisherRepository.DeletePublisher(id);
            return deletedPublisher;
        }


        public async Task<IEnumerable<Book>> GetBooksByPublisher(int publisherId)
        {
            var books = await _publisherRepository.GetBooksByPublisher(publisherId);
            return books;
        }
    }
}
