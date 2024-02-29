using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookDto = BookPublisher.Application.Dto.BookDto;

namespace BookPublisherr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublisher()
        {
            return Ok(await _publisherService.GetAllPublishersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            return Ok(await _publisherService.GetPublisherByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody]PublisherCreateDto publisherCreateDto)
        {
            return Ok(await _publisherService.CreatePublisherAsync(publisherCreateDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, PublisherDto publisherDto)
        {
            return Ok(await _publisherService.UpdatePublisherAsync(id, publisherDto));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            return Ok(await _publisherService.DeletePublisherAsync(id));
        }

        [HttpGet("{publisherId}/books")]
        public async Task<IActionResult> GetBooksByPublisher(int publisherId)
        {
            return Ok(await _publisherService.GetBooksByPublisherAsync(publisherId));
        }
    }
}
