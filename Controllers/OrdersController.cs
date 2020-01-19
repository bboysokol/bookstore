using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Database;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrdersController> _logger = null;
        public OrdersController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            OrderService orderService)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<OrdersController>();
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> GetOrders(int take, int skip)
        {
            try
            {
                return await _orderService.GetOrders(take, skip);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOrders()");
                return Failure();
            }
        }


        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody]JObject order)
        {
            try
            {
                return await _orderService.AddOrder(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddOrder()");
                return Failure();
            }
        }

        // DELETE: api/Orders/5
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            try
            {
                return await _orderService.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteOrder()");
                return Failure();
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> ChangeState([FromRoute] int id)
        {
            try
            {
                return await _orderService.ChangeState(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ChangeState()");
                return Failure();
            }
        }
    }
}
