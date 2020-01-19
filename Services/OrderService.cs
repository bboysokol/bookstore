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

    public class OrderService : ServiceBase
    {
        private readonly BookstoreDbContext _context;
        public OrderService(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetOrders(int take, int skip)
        {
            var ordersQuery = _context.Orders
                .Include(a => a.Client)
                .Include(a => a.ShoppingCarts).ThenInclude(b=> b.Book);

            var orders = await ordersQuery
                .Skip(skip)
                .Take(take)
                .Select(row => new OrderVM()
                {
                    Id = row.Id,
                    Client = new ClientVM()
                    {
                        Id = row.Client.Id,
                        Email = row.Client.Email,
                        Name = row.Client.Name,
                        Surname = row.Client.Surname,
                        PostCode = row.Client.PostCode,
                        Street = row.Client.Street,
                        ApartamentNumber = row.Client.ApartamentNumber,
                        HouseNumber = row.Client.HouseNumber
                    },
                    IsDone = row.IsDone,
                    Date = row.Date,
                    Price = row.Price,
                    ShoppingCarts = row.ShoppingCarts.Select(row2 => row2.Book).ToList()
                }).ToListAsync();

            return Success(orders);
        }

        public async Task<IActionResult> AddOrder(JObject order)
        {
            var _order = new Order()
            {
                ClientId = order.GetValue("clientId").Value<string>(),
                IsDone = true,

            };
            _context.Orders.Add(_order);
            await _context.SaveChangesAsync();
            var orderId = _order.Id;
            var books = order.GetValue("list").Value<JArray>();
            foreach(var book in books)
            {
                var cart = new ShoppingCart()
                {
                    ISBN = book.Value<int>("isbn"),
                    OrderId = orderId
                };
                _context.ShopingCarts.Add(cart);
            }
            await _context.SaveChangesAsync();

            return Success();
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Success();
        }
        public async Task<IActionResult> ChangeState(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);
            order.IsDone = !order.IsDone;
            await _context.SaveChangesAsync();
            return Success();
        }

    }
}
