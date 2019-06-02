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
    public class CategoriesController : BaseController
    {
        private readonly CategoriesService _categoriesService;
        private readonly ILogger<PublishingHousesController> _logger = null;

        public CategoriesController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            CategoriesService categoriesService)
            : base(signInManager, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PublishingHousesController>();
            _categoriesService = categoriesService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return await _categoriesService.GetCategories();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetCategories()");
                return Failure();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] JObject category)
        {
            try
            {
                return await _categoriesService.AddCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddCategory()");
                return Failure();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] int id)
        {
            try
            {
                return await _categoriesService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteCategory()");
                return Failure();
            }
        }

    }
}
