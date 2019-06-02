using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        private readonly AuthorService _authorService;
        private readonly ILogger<AuthorsController> _logger = null;
        public AuthorsController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            AuthorService authorService)
            : base(signInManager, userManager, loggerFactory)
        {
            _authorService = authorService;
            _logger = loggerFactory.CreateLogger<AuthorsController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                return await _authorService.GetAuthors();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAuthors()");
                return Failure();
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            try
            {
                return await _authorService.GetAuthor(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error in GetAuthor()");
                return Failure();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            try {
            return await _authorService.AddAuthor(author);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error in AddAuthor()");
                return Failure();
            }

        }

        // DELETE: api/Authors/5
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            try
            {
                return await _authorService.DeleteAuthor(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteAuthor()");
                return Failure();
            }
        }
    }
}
