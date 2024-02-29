using AutoMapper;
using BookPublisher.Application.Dto;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookDto = BookPublisher.Domain.Entities.BookDto;

namespace BookPublisherr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
           return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _bookService.GetBookByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            return Ok(await _bookService.CreateBookAsync(bookCreateDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id,[FromBody] BookPublisher.Application.Dto.BookDto bookDto)
        {
            return Ok(await _bookService.UpdateBookAsync(id, bookDto));
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
        //{
        //    try
        //    {
        //        bookDto.Id = id;

        //        var book = _mapper.Map<BookDto>(bookDto);
        //        var updatedBook = await _bookService.UpdateBook(book);
        //        var updatedBookDto = _mapper.Map<BookDto>(updatedBook);

        //        return Ok(updatedBookDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error while updating book");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating book");
        //    }
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _bookService.DeleteBookAsync(id));
        }

        [HttpGet("publisher/{bookId}")]
        public async Task<IActionResult> GetPublisherByBook(int bookId)
        {
            return Ok(await _bookService.GetPublisherByBookAsync(bookId));
        }


    }
}
