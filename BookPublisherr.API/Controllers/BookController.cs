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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,ILogger<BookController>logger,IMapper mapper)
        {
            _bookService = bookService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooks();
                var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
                return Ok(booksDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting all books");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting all books");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }

                var bookDto = _mapper.Map<BookDto>(book);
                return Ok(bookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting book by id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting book by id");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDto bookDto)
        {
            try
            {
                var book = _mapper.Map<Book>(bookDto);
                var createdBook = await _bookService.CreateBook(book);
                var createdBookDto = _mapper.Map<BookDto>(createdBook);
                return CreatedAtAction(nameof(GetBookById), new { id = createdBookDto.Id }, createdBookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating book");
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto bookDto)
        {
            try
            {
                var book = _mapper.Map<Book>(bookDto);
                var updatedBook = await _bookService.UpdateBook(book);
                var updatedBookDto = _mapper.Map<BookDto>(updatedBook);
                return Ok(updatedBookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating book");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating book");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var deletedBook = await _bookService.DeleteBook(id);
                var deletedBookDto = _mapper.Map<BookDto>(deletedBook);
                return Ok(deletedBookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting book");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting book");
            }
        }

        [HttpGet("publisher/{bookId}")]
        public async Task<IActionResult> GetPublisherByBook(int bookId)
        {
            try
            {
                var publisher = await _bookService.GetPublisherByBook(bookId);
                if (publisher == null)
                {
                    return NotFound();
                }

                var publisherDto = _mapper.Map<PublisherDto>(publisher);
                return Ok(publisherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting publisher by book");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting publisher by book");
            }
        }


    }
}
