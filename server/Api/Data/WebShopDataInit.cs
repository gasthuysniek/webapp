using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace Webshop.Data
{
    public class WebShopDataInit
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public WebShopDataInit(ApplicationDbContext dbContext,ILogger<ApplicationDbContext> logger,
            UserManager<IdentityUser> userManager
            )
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }
        public async Task InititalizeData()
        {
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
             /*   using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Webshop].[dbo].[User] ON; INSERT INTO[Webshop].[dbo].[User](UserId, Email, FirstName, LastName) VALUES(2, 'niek.gasthuys2@gmail.com', 'Niek', 'Gasthuys'");

                    transaction.Commit();
                }*/
                    Product product = new Product("Strix rog", "Laptop", 300, "Good laptop"
                        // ,1
                        );
                    //{ ProductClass = productClass};//  public Product(string productclass, string productname,int unitPrice,string description, int? amount=null):this();
                    _dbContext.Product.Add(product);

                    User customer = new User { Email = "amber.vlerick@gmail.com", FirstName = "Amber", LastName = "Vlerick" };

                    _dbContext.User.Add(customer);
                    // await CreateUser(user.Email, "Niek@12345");
                    await CreateUser(customer.Email, "Amber@12345");

                    User customer2 = new User { Email = "niek.gasthuys.y9891@student.hogent.be", FirstName = "Niek", LastName = "Gasthuys" };
                    _dbContext.User.Add(customer2);
                    await CreateUser(customer2.Email, "Nieker@12345");
                    _dbContext.SaveChanges();

                
            }
            else
            {
                throw new Exception("The database could not be created");
            }
        }
       private async Task CreateUser(string email, string password)
        {
          
            var user = new IdentityUser { UserName = email, Email=email} ;// { Email = email, UserName = firstname + lastname ,FirstName = firstname, LastName=lastname};
          
            await _userManager.CreateAsync(user, password);
               
          
        }   
        
    
    }
}
