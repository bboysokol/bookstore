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

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<AuthorsController> _logger = null;
        public AuthorsController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            BookstoreDbContext context)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AuthorsController>();
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();
                return Success(authors);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == id);

                if (author == null)
                {
                    return NotFound();
                }

                return Success(author);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error in GetAuthor()");
                return Failure();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAuthor([FromRoute] int id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                return Success();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error in AddAuthor()");
                return Failure();
            }

        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            try
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteAuthor()");
                return Failure();
            }
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
