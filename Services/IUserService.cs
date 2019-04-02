using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Services
{
    public interface IUserService
    {
        Client Authenticate(string UserName);
    }
}
