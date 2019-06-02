using Bookstore.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Services
{
    public class ServiceBase
    {
        protected readonly BookstoreDbContext context;
        public ServiceBase(BookstoreDbContext context)
        {
            this.context = context;
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
    }
}
