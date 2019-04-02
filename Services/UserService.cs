using Bookstore.Database;
using Bookstore.Helpers;
using Bookstore.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Services
{
   
    public class UserService : IUserService
    {
        private readonly BookstoreDbContext _context;
        private readonly AppSettings _appSettings;


        public UserService(IOptions<AppSettings> appSettings, BookstoreDbContext context)
        {
            _appSettings = appSettings.Value;
            this._context = context;

        }

        public Client Authenticate(string username)
        {
            Client user = _context.Users.SingleOrDefault(i => i.UserName == username);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);


            user.PasswordHash = null;

            return user;
        }

    }
}
