using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly BookService _bookService;
        private readonly ILogger<BooksController> _logger = null;
        public BooksController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            BookService bookService)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BooksController>();
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks(int take, int skip, string category)
        {
            try
            {
                return await _bookService.GetBooks(take, skip, category);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetBooks()");
                return Failure();
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            try
            {
                return await _bookService.GetBook(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetBook()");
                return Failure();
            }
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPrice([FromRoute] int id, [FromBody] decimal price)
        {
            try
            {
                return await _bookService.EditPrice(id, price);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EditPrice()");
                return Failure();
            }
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody]JObject book)
        {
            try
            {
                return await _bookService.AddBook(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddBook()");
                return Failure();
            }
        }

        // DELETE: api/Books/5
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                return await _bookService.DeleteBook(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteBook()");
                return Failure();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTopBooks()
        {
            try
            {
                return await _bookService.GetTopBooks();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetTopBooks()");
                return Failure();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddTopBooks()
        {
            try
            {
                return await _bookService.AddTopBooks();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddTopBooks()");
                return Failure();
            }
        }
    }
}
