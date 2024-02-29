using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisher.Application.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository= publisherRepository;
        }

        public async  Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
        {
            return await _publisherRepository.GetAllPublishersAsync();
        }

        public async Task<PublisherDto> GetPublisherByIdAsync(int id)
        {
            return await _publisherRepository.GetPublisherByIdAsync(id);
        }

        public async Task<PublisherDto> CreatePublisherAsync(PublisherCreateDto publisherCreateDto)
        {
            return await _publisherRepository.CreatePublisherAsync(publisherCreateDto);
        }

        public async Task<PublisherDto> UpdatePublisherAsync(int id, PublisherDto publisherDto)
        {
            return await _publisherRepository.UpdatePublisherAsync(id, publisherDto);
        }

        public async Task<PublisherDto> DeletePublisherAsync(int id)
        {
           return await _publisherRepository.DeletePublisherAsync(id);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByPublisherAsync(int publisherId)
        {
            return await _publisherRepository.GetBooksByPublisherAsync(publisherId);
        }
    }
}
