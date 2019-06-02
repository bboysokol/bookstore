using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Bookstore.Services
{

    public class PublishingHouseService : ServiceBase
    {
        private readonly BookstoreDbContext _context;
        public PublishingHouseService(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetPublishingHouses()
        {
            var publishHouses = await _context.PublishingHouses
                           .Select(row => new PublishingHouseVM()
                           {
                               Id = row.Id,
                               Title = row.Title,
                           }).ToListAsync();
            ;
            return Success(publishHouses);
        }
        public async Task<IActionResult> AddPublishingHouse(JObject publishingHouse)
        {
            var category = new PublishingHouse()
            {
                Title = publishingHouse.GetValue("NewTitle").ToString()
            };
            _context.PublishingHouses.Add(category);
            await _context.SaveChangesAsync();

            return Success();
        }
        public async Task<IActionResult> DeletePublishingHouse(int id)
        {
            var publishingHouse = await _context.PublishingHouses.FirstOrDefaultAsync(i => i.Id == id);
            _context.PublishingHouses.Remove(publishingHouse);
            await _context.SaveChangesAsync();
            return Success();
        }

    }
}
