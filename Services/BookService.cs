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

    public class BookService : ServiceBase
    {
        private readonly BookstoreDbContext _context;
        public BookService(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
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
                .Skip(skip)
                .Take(take)
                .Select(row => new BookVM()
                {
                    ISBN = row.ISBN,
                    Title = row.Title,
                    Category = row.Category,
                    Price = row.Price,
                    PublishmentYear = row.PublishmentYear,
                    PublishingHouse = row.PublishingHouse,
                    Img = row.Img,
                    Authors = row.BookAuthors.Select(row2 => row2.Author).ToList()
                }).ToListAsync();


            return Success(books);
        }
        public async Task<IActionResult> GetBook(int id)
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
                    Img = row.Img,
                    Authors = row.BookAuthors.Select(row2 => row2.Author).ToList()
                }).FirstOrDefaultAsync();

            return Success(book);
        }

        public async Task<IActionResult> EditPrice(int id, decimal price)
        {
            var book = _context.Books.FirstOrDefaultAsync(i => i.ISBN == id);
            book.Result.Price = price;
            await _context.SaveChangesAsync();
            return Success();
        }

        public async Task<IActionResult> AddBook(JObject book)
        {
            var category = await _context.Categories.Where(i => i.Id == book.GetValue("category").Value<int>()).FirstOrDefaultAsync();
            var pubhouse = await _context.PublishingHouses.Where(i => i.Id == book.GetValue("publishinghouse").Value<int>()).FirstOrDefaultAsync();
            var _book = new Book()
            {
                Title = book.GetValue("title").Value<string>(),
                Category = category,
                PublishmentYear = book.GetValue("publishmentYear").Value<string>(),
                Price = book.GetValue("price").Value<decimal>(),
                PublishingHouse = pubhouse,
                Img = book.GetValue("img").Value<string>(),
            };
            if (_book.Img.Equals("")) _book.Img = "avatar_ac27_6d49";
             var result = _context.Books.Add(_book);
            await _context.SaveChangesAsync();

            var result2 = await _context.Books.Where(i => i.Title == _book.Title).FirstOrDefaultAsync();

            var bookauthor = new BookAuthor()
            {
                BookId = result2.ISBN,
                AuthorId = book.GetValue("authors").Value<int>(),
            };

            _context.BookAuthors.Add(bookauthor);
            await _context.SaveChangesAsync();
            return Success();
        }
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(i => i.ISBN == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Success();
        }
        public async Task<IActionResult> GetTopBooks()
        {

            var topBooks = _context.TopBooks.Select(i=>i.Book);
            var booksQuery = topBooks
                .Include(a => a.BookAuthors).ThenInclude(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.PublishingHouse)
                .Where(a => !a.IsDeleted);

            var books = await booksQuery
                .Select(row => new BookVM()
                {
                    ISBN = row.ISBN,
                    Title = row.Title,
                    Category = row.Category,
                    Price = row.Price,
                    PublishmentYear = row.PublishmentYear,
                    PublishingHouse = row.PublishingHouse,
                    Img = row.Img,
                    Authors = row.BookAuthors.Select(row2 => row2.Author).ToList()
                }).ToListAsync();

            return Success(books);
        }
        public async Task<IActionResult> AddTopBooks()
        {
            _context.TopBooks.RemoveRange(_context.TopBooks);

            var IdList = _context.ShopingCarts.GroupBy(p => p.ISBN)
                   .Select(g => new { Id = g.Key, count = g.Count() }).OrderByDescending(i => i.count).Take(4).ToList();

            foreach (var item in IdList)
            {
                _context.TopBooks.Add(new TopBook()
                {
                    BookId = item.Id
                }
                );
            }
            await _context.SaveChangesAsync();
            return Success();
        }

    }
}
