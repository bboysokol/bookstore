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

    public class CategoriesService : ServiceBase
    {
        private readonly BookstoreDbContext _context;
        public CategoriesService(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                            .Select(row => new Category()
                            {
                                Id = row.Id,
                                Title = row.Title,
                            }).ToListAsync();
            return Success(categories);
        }
        public async Task<IActionResult> AddCategory(JObject category)
        {
            var _category = new Category()
            {
                Title = category.GetValue("NewTitle").ToString()
            };
            _context.Categories.Add(_category);
            await _context.SaveChangesAsync();

            return Success();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Success();
        }

    }
}
