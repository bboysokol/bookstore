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
    public class PublishingHousesController : BaseController
    {

        private readonly BookstoreDbContext _context;
        private readonly ILogger<PublishingHousesController> _logger = null;

        public PublishingHousesController(
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
        public async Task<IActionResult> GetAll()
        {
            var publishHouses = await _context.PublishingHouses
                           .Select(row => new PublishingHouse()
                           {
                               Id = row.Id,
                               Title = row.Title,
                           }).ToListAsync();
                ;
            return Success(publishHouses);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JObject NewTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = new PublishingHouse()
            {
                Title = NewTitle.GetValue("NewTitle").ToString()
            };
            _context.PublishingHouses.Add(category);
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
            var publishHouse = _context.PublishingHouses.FirstOrDefault(i => i.Id == id);

            _context.PublishingHouses.Remove(publishHouse);
            await _context.SaveChangesAsync();

            return Success();
        }

    }
}
