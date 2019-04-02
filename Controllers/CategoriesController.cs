using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        private readonly BookstoreDbContext _context;
        private readonly ILogger<PublishingHousesController> _logger = null;

        public CategoriesController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            BookstoreDbContext context)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PublishingHousesController>();
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                           .Select(row => new Category()
                           {
                               Id = row.Id,
                               Title = row.Title,
                           }).ToListAsync();
                ;
            return Success(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JObject NewTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = new Category()
            {
                Title = NewTitle.GetValue("NewTitle").ToString()
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Success();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _context.Categories.FirstOrDefault(i => i.Id == id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Success();
        }

    }
}
