using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Webshop.Data.Interfaces;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace WebshopApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
       

        public UserController(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            
        }

        /// <summary>
        /// Get the details of the authenticated customer
        /// </summary>
        /// <returns>the customer</returns>
        [HttpGet()]
        public ActionResult<UserDTO> GetUser()
        {
            
            User user = _userRepository.GetByEmail(User.Identity.Name);
           
          
            return new UserDTO(user) { Orders = user.OrderListOfUser};
        }
    }
}
