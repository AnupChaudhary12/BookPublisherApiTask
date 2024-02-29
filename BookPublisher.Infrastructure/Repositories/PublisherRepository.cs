using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookPublisher.Infrastructure.Repositories
{
    public class PublisherRepository: IPublisherRepository
    {
        private readonly BookPublisherDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PublisherRepository> _logger;

        public PublisherRepository(BookPublisherDbContext context, IMapper mapper,
            ILogger<PublisherRepository> logger)
        {
            _context= context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
        {
            try
            {
                var publishers = await _context.Publishers.ToListAsync();
                return _mapper.Map<IEnumerable<PublisherDto>>(publishers);               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<PublisherDto> GetPublisherByIdAsync(int id)
        {
            try
            {
                var book = await _context.Publishers.FindAsync(id);
                return _mapper.Map<PublisherDto>(book);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PublisherDto> CreatePublisherAsync(PublisherCreateDto publisherCreateDto)
        {
            try
            {
                var publisher = _mapper.Map<Publisher>(publisherCreateDto);
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();
                return _mapper.Map<PublisherDto>(publisher);
            }
            catch
            {
                _logger.LogError("Error while creating publisher");
                throw;
            }
        }

        public async Task<PublisherDto> UpdatePublisherAsync(int id, PublisherDto publisherDto)
        {
            try
            {
                var existingPublisher = await _context.Publishers.FindAsync(id);
                if (existingPublisher == null)
                {
                    throw new InvalidOperationException("Publisher not found");
                }
                _mapper.Map(publisherDto, existingPublisher);
                await _context.SaveChangesAsync();
                return _mapper.Map<PublisherDto>(existingPublisher);
            }
            catch
            {
                _logger.LogError("Error while updating publisher");
                throw;
            }
        }

        public async Task<PublisherDto> DeletePublisherAsync(int id)
        { 
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                throw new InvalidOperationException("Publisher not found");
            }
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return _mapper.Map<PublisherDto>(publisher);
        }
         async Task<IEnumerable<Application.Dto.BookDto>> IPublisherRepository.GetBooksByPublisherAsync(int publisherId)
        {
            try
            {
                var books = await _context.Books.Where(b => b.PublisherId == publisherId).ToListAsync();
                return _mapper.Map<IEnumerable<Application.Dto.BookDto>>(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
