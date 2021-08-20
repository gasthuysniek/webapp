using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Webshop.Data;
using Webshop.Data.Interfaces;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _customerRepository;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(
          SignInManager<IdentityUser> signInManager,
          UserManager<IdentityUser> userManager,
          IUserRepository customerRepository,
          IConfiguration config,
          ApplicationDbContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _dbContext = dbContext;
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model">the user details</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            //implement a generator for userid


            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            User customer = new User { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
            var result = await _userManager.CreateAsync(user, model.PassWord);
           
            if (result.Succeeded)
            {
              
                _customerRepository.Add(customer);
                _customerRepository.SaveChanges();
                string token = GetToken(user);
                return Created("", token);
                _customerRepository.SaveChanges();
                /* _dbContext.User.Add(user2);
                 _dbContext.SaveChanges();*/
                Console.WriteLine("helllllooooo");

            /* await _dbContext.Database.ExecuteSqlRawAsync(sqlstring);
             transaction.Commit();*/
            /*   string token = GetToken(user);
               return Created("", token);*/
           }
            /* using (var transaction = _dbContext.Database.BeginTransaction())
             {
                 var userid = _customerRepository.GetAll().Count + 1;
                 var sqlstring = "SET IDENTITY_INSERT [Webshop].[dbo].[User] ON; INSERT INTO[Webshop].[dbo].[User](UserId, Email, FirstName, LastName) VALUES(" + userid + ",'" + model.Email + "','" + model.FirstName + "','" + model.LastName + "');";
                 User user2 = new User { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                 await _dbContext.Database.ExecuteSqlRawAsync(sqlstring);
                 transaction.Commit();
         */
            //}

            //return BadRequest(result);
            return BadRequest();
    
           
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">the login details</param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.PassWord, false);

                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }
        
        private String GetToken(IdentityUser user)
        {
            // Create the token
            var claims = new[]
            { 
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Checks if an email is available as username
        /// </summary>
        /// <returns>true if the email is not registered yet</returns>
        /// <param name="email">Email.</param>/
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null;
        }

        
    }

}
