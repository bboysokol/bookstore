using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{

    public class AuthorService : ServiceBase
    {
        private readonly BookstoreDbContext _context;
        public AuthorService(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _context.Authors
                    .Select(row => new AuthorVM()
                    {
                        Id = row.Id,
                        Name = row.Name + " " + row.Surname
                    }).ToListAsync();
            return Success(authors);
        }
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == id);
            var authors = await _context.Authors
                    .Where(i => i.Id == id)
                    .Select(row => new AuthorVM()
                    {
                        Id = row.Id,
                        Name = row.Name + " " + row.Surname
                    }).FirstOrDefaultAsync();
            return Success(authors);
        }
        public async Task<IActionResult> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return Success();
        }
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return Success();
        }

    }
}
