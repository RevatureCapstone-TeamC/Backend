using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using ECommerce.Models;
using ECommerce.Data;

namespace ECommerce.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        /* private readonly IRepository _repo; */
        private readonly CommerceContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(CommerceContext context, ILogger<AuthController> logger)
        {
            /* this._repo = repo; */
            this._context = context;
            this._logger = logger;
        }

        // * Create a user, returns either BadRequest (400) or CreatedAtAction (201) response
        [Route("auth/register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] User newUser)
        {
            _logger.LogInformation("auth/register triggered");
            try
            {
                /* return Ok(await _repo.CreateNewUserAndReturnUserIdAsync(newUser)); */
                // TODO : Context create user async
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("auth/register completed successfully");
                return CreatedAtAction("GetUser", new User {UserId = newUser.UserId}, newUser);
            }
            catch
            {
                _logger.LogWarning("auth/register completed with errors");
                return BadRequest();
            }
        }


        [Route("auth/login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromBody] User LR)
        {
            _logger.LogInformation("auth/login triggered");
            
            /* return Ok(await _repo.GetUserLoginAsync(LR.password, LR.email)); */
            // TODO : Context get user async, return User, produce status
            var response = _context.Users.Where(u => u.UserEmail==LR.UserEmail 
                && u.UserPassword == LR.UserPassword).FirstOrDefault();
            if (response is null) {
                _logger.LogInformation("auth/login returned with an error");
                return BadRequest("Invalid credentials");
            }

            _logger.LogInformation("auth/login completed successfully");
            return response;
        }

        [Route("auth/logout")]
        [HttpPost]
        public ActionResult Logout()
        { 
            _logger.LogInformation("auth/logout triggered");
            _logger.LogInformation("auth/logout completed successfully");
            return Ok();
        }

        private bool UserExists(int id){
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
