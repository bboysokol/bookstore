using System;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private IUserService _userService;
        private readonly ILogger<AuthenticationController> logger = null;
        public AuthenticationController(
            SignInManager<Client> signInManager,
            UserManager<Client> userManager,
            ILoggerFactory loggerFactory,
            IUserService userService)
            : base(signInManager, userManager, loggerFactory)
        {
            _userService = userService;
        }
        //[Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Failure();
                }

                if (registerRequest.Password != registerRequest.ConfirmedPassword)
                {
                    return Failure();
                }

                var user = new Client()
                {
                    Email = registerRequest.Email,
                    UserName = registerRequest.UserName
                };

                var registerResult = await userManager.CreateAsync(user, registerRequest.Password);

                if (!registerResult.Succeeded)
                {
                    return Failure();
                }

                return Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Register()!");
                return Failure();
            }
        }
        //[Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LoginRequest loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Failure();
                }

                var result = await signInManager.PasswordSignInAsync(
                    loginRequest.UserName, loginRequest.Password, true, false);

                if (!result.Succeeded)
                {
                    return Failure();
                }

                var user = _userService.Authenticate(loginRequest.UserName);
                if (user == null)
                {
                    return BadRequest("User doesn't exist");
                }
                return Success(user);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error in LogIn()");
                return Failure();
            }



        }

        //[Route("Logout")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "ERROR!, Unexcepted error in LogOut()");
                return Failure();
            }
        }
        [HttpPost]
        public async Task<IActionResult> IsLoggedIn()
        {
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await userManager.GetUserAsync(HttpContext.User);
                    if (user != null)
                    {
                        return Success(new { Email = HttpContext.User.Identity.Name });
                    }

                    await signInManager.SignOutAsync();
                    return Failure();
                }
                else
                {
                    return Failure();
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in IsLoggedIn()");
                return Failure();
            }
        }

    }
}
