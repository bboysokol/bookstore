using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Database;
using Bookstore.Models;
using Bookstore.Services;
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
        private readonly PublishingHouseService _publishingHouseService;
        private readonly ILogger<PublishingHousesController> _logger = null;

        public PublishingHousesController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            PublishingHouseService publishingHouseService)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PublishingHousesController>();
            _publishingHouseService = publishingHouseService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetPublishingHouses()
        {
            try
            {
                return await _publishingHouseService.GetPublishingHouses();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetPublishingHouses()");
                return Failure();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPublishingHouse([FromBody] JObject publishingHouse)
        {
            try
            {
                return await _publishingHouseService.AddPublishingHouse(publishingHouse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddPublishingHouse()");
                return Failure();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeletePublishingHouse([FromRoute] int id)
        {
            try
            {
                return await _publishingHouseService.DeletePublishingHouse(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeletePublishingHouse()");
                return Failure();
            }
        }

    }
}
