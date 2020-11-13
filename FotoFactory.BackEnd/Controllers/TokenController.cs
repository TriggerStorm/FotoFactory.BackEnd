using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;

namespace FotoFactory.BackEnd.Controllers
{
    public class TokenController : Controller
    {
        private IAuthenticationHelper authenticationHelper;
        private IUserRepository repository;

        public TokenController(IUserRepository repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
              var user = repository.ReadAllUsers().FirstOrDefault(u => u.Username == model.Username);
            
            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }
        
    }
}
