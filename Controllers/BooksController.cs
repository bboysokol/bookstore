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

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<BooksController> _logger = null;
        public BooksController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            BookstoreDbContext context)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BooksController>();
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks(int take, int skip, string category)
        {
            var booksQuery = _context.Books
                .Include(a => a.BookAuthors).ThenInclude(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.PublishingHouse)
                .Where(a => !a.IsDeleted);

            if (category != null)
                booksQuery = booksQuery.Where(b => b.Category.Title == category);

            var books = await booksQuery
                .Skip(1)
                .Select(row => new BookVM()
                {
                    ISBN = row.ISBN,
                    Title = row.Title,
                    Category = row.Category,
                    Price = row.Price,
                    PublishmentYear = row.PublishmentYear,
                    PublishingHouse = row.PublishingHouse,
                    Authors = row.BookAuthors.Select(row2 => row2.Author).ToList()
                }).ToListAsync();


            return Success(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            var book = await _context.Books
                .Include(a => a.BookAuthors).ThenInclude(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.PublishingHouse)
                .Where(a => !a.IsDeleted && a.ISBN == id)
                .Select(row => new BookVM()
                {
                    ISBN = row.ISBN,
                    Title = row.Title,
                    Category = row.Category,
                    Price = row.Price,
                    PublishmentYear = row.PublishmentYear,
                    PublishingHouse = row.PublishingHouse,
                    Authors = row.BookAuthors.Select(row2 => row2.Author).ToList()
                }).FirstOrDefaultAsync();


            return Success(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook([FromRoute] int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody]JObject book)
        {

            var category = await _context.Categories.Where(i => i.Id == book.GetValue("category").Value<int>()).FirstOrDefaultAsync();

            var pubhouse = await _context.PublishingHouses.Where(i => i.Id == book.GetValue("publishinghouse").Value<int>()).FirstOrDefaultAsync();
            var book2 = new Book()
            {
                Title = book.GetValue("title").Value<string>(),
                Category = category,
                PublishmentYear = book.GetValue("publishmentYear").Value<string>(),
                Price = book.GetValue("price").Value<decimal>(),
                PublishingHouse = pubhouse

            };
            
            
            var result = _context.Books.Add(book2);
            await _context.SaveChangesAsync();

            var result2 = await _context.Books.Where(i => i.Title == book2.Title).FirstOrDefaultAsync();

            var bookauthor = new BookAuthor()
            {
                BookId = result2.ISBN,
                AuthorId = book.GetValue("authors").Value<int>(),

            };

            _context.BookAuthors.Add(bookauthor);
            await _context.SaveChangesAsync();
            return Success();
            
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Success();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ISBN == id);
        }
    }
}
