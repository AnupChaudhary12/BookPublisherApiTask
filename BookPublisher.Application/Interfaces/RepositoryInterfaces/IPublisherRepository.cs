using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisher.Application.Interfaces.RepositoryInterfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<PublisherDto>> GetAllPublishersAsync();
        Task<PublisherDto> GetPublisherByIdAsync(int id);
         Task<PublisherDto> CreatePublisherAsync(PublisherCreateDto publisherCreateDto);
         Task<PublisherDto> UpdatePublisherAsync(int id,PublisherDto publisherDto);
         Task<PublisherDto> DeletePublisherAsync(int id);
         Task<IEnumerable<BookDto>> GetBooksByPublisherAsync(int publisherId);

    }
}
