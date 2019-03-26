using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.Controllers
{

    public class BaseController : ControllerBase
    {
        protected readonly SignInManager<Client> signInManager = null;
        protected readonly UserManager<Client> userManager = null;
        protected readonly ILoggerFactory loggerFactory = null;

        public BaseController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory
        )

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loggerFactory = loggerFactory;
        }

        protected IActionResult Success()
        {

            return new JsonResult(new Result.Response() { Successful = true });
        }

        protected IActionResult Failure()
        {
            return new JsonResult(new Result.Response() { Successful = false, Errors = new Dictionary<string, List<string>>() });
        }

        protected IActionResult Failure(Dictionary<string, List<string>> errors = null)
        {
            return new JsonResult(new Result.Response() { Successful = false, Errors = errors });
        }

        protected IActionResult Success<T>(T payload)
        {
            return new JsonResult(new Result.Result<T>() { Successful = true, Payload = payload });
        }

        protected IActionResult Failure<T>(Dictionary<string, List<string>> errors = null)
        {
            return new JsonResult(new Result.Result<T>() { Successful = false, Errors = errors });
        }

        protected Dictionary<string, List<string>> GetModelStateErrors()
        {
            if (!ModelState.IsValid)
            {
                var result = ModelState.ToDictionary(i => i.Key, i => i.Value.Errors.Select(j => j.ErrorMessage).ToList());
                return result;
            }
            else
                return new Dictionary<string, List<string>>();
        }
    }
}


