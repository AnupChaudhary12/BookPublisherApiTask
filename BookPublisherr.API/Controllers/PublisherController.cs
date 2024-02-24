using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisherr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly ILogger<PublisherController> _logger;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherService publisherService, ILogger<PublisherController> logger, IMapper mapper)
        {
            _publisherService = publisherService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublisher()
        {
            try
            {
                var publishers = await _publisherService.GetAllPublishers();
                var publishersDto = _mapper.Map<IEnumerable<PublisherDto>>(publishers);
                return Ok(publishersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in getting publishers");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in getting publishers");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            try
            {
                var publisher = await _publisherService.GetPublisherById(id);
                if (publisher == null)
                {
                    return NotFound();
                }

                var publisherDto = _mapper.Map<PublisherDto>(publisher);
                return Ok(publisherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in getting publisher by id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in getting publisher by id");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody]PublisherDto publisherDto)
        {
            try
            {
                var publisher = _mapper.Map<Publisher>(publisherDto);
                var createdPublisher = await _publisherService.CreatePublisher(publisher);
                var createdPublisherDto = _mapper.Map<PublisherDto>(createdPublisher);
                return CreatedAtAction(nameof(GetPublisherById), new { id = createdPublisherDto.Id },
                    createdPublisherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in creating publisher");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in creating publisher");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublisher(PublisherDto publisherDto)
        {
            try
            {
                var publisher = _mapper.Map<Publisher>(publisherDto);
                var updatedPublisher = await _publisherService.UpdatePublisher(publisher);
                var updatedPublisherDto = _mapper.Map<PublisherDto>(updatedPublisher);
                return Ok(updatedPublisherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in updating publisher");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in updating publisher");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            try
            {
                var deletedPublisher = await _publisherService.DeletePublisher(id);
                var deletedPublisherDto = _mapper.Map<PublisherDto>(deletedPublisher);
                return Ok(deletedPublisherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in deleting publisher");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in deleting publisher");
            }
        }

        [HttpGet("{publisherId}/books")]
        public async Task<IActionResult> GetBooksByPublisher(int publisherId)
        {
            try
            {
                var books = await _publisherService.GetBooksByPublisher(publisherId);
                var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
                return Ok(booksDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in getting books by publisher");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in getting books by publisher");
            }
        }
    }
}
