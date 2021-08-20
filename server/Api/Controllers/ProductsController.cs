using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Data.Interfaces;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace Webshop.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))] 
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IUserRepository _userRepository;
        private readonly IFavoriteProductRepository _favoriteProductRepo;
        public ProductsController(IProductRepository context,IUserRepository userRepository, IFavoriteProductRepository favoriteProductRepository)
        {
            _productRepo = context;
            _userRepository = userRepository;
            _favoriteProductRepo = favoriteProductRepository;
        }

        // GET: api/Products
        /// <summary>
        /// Get all the products ordered by productname 
        /// </summary>
        /// <param name="productname"></param>
        /// <returns>Array of products</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Product> GetProductsByProductName(string productname = null)
        {
            //when nothing is given as a parameter, all products are returned
            if (string.IsNullOrEmpty(productname))
            {
                return _productRepo.GetAll();
            }
            return _productRepo.GetByProductName(productname);
        }

        //GET: api/Products/5
        /// <summary>
        /// Get products by id
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>The product</returns>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product product = _productRepo.GetById(id);
            if (product == null) return NotFound();
            return product;
        }

        //POST: api/Products
        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">New product</param>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Product> PostProduct(ProductDTO product)
        {

            User user = _userRepository.GetByEmail(User.Identity.Name);
            Product newProduct = new Product(product.ProductName, product.ProductClass, product.UnitPrice, product.Description
                //product.Amount
                )
           
           ;// { ProductClass = newProductClass}; //{ ProductName = product.ProductName, UnitPrice = product.UnitPrice, ProductClass = product.ProductClass };
            newProduct.AddProductsAvailable(product.Availability);
            _productRepo.Add(newProduct);
            _productRepo.SaveChanges();
            //creates a response
            return CreatedAtAction
                //string actionname
                (nameof(GetProduct), new { id = newProduct.ProductId }, newProduct);
        }
        //PUT: api/Products/5
        /// <summary>
        /// Modifying a product
        /// </summary>
        /// <param name="product">The product we want to modify</param>
        /// <param name="id">Id of the product</param>
        [HttpPut("{id}")]
        public ActionResult PutProduct(int id, Product product)
        {
            if(product.ProductId != id)
            {
                return BadRequest();
            }
            _productRepo.Update(product);
            _productRepo.SaveChanges();
            return NoContent();
        }

        //DELETE: api/Products/5
        /// <summary>
        /// Deleting a product
        /// </summary>
        /// <param name="id">The productid of the product that needs to be deleted</param>
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product productNeedsDeleting = _productRepo.GetById(id);
            if(productNeedsDeleting == null)
            {
                return BadRequest();
            }
            _productRepo.Delete(productNeedsDeleting);
            _productRepo.SaveChanges();
            return NoContent();
        }
    
        /// <summary>
        /// Get favorite products of current user
        /// </summary>
        [HttpGet("Favorites")]
        public IEnumerable<FavoriteProduct> GetFavorites()
        {
            User user = _userRepository.GetByEmail(User.Identity.Name);
            return user.Favorites;
        }

        /// <summary>
        /// Adding a product to the favorites of the current user given the productId
        /// <paramref name="productId"/>
        /// </summary>
        [HttpPut("AddingFavorite")]
        public ActionResult AddProductToFavorite(int productId)
        {
            Product productNeedsAdding = _productRepo.GetById(productId);
            User userThatNeedsAdding = _userRepository.GetByEmail(User.Identity.Name);
            FavoriteProduct favoriteProduct = new FavoriteProduct() { Product = productNeedsAdding, User = userThatNeedsAdding };
            try
            {
                userThatNeedsAdding.AddFavoriteProduct(favoriteProduct);
                _favoriteProductRepo.Add(new FavoriteProduct(userThatNeedsAdding, productNeedsAdding));
                _favoriteProductRepo.SaveChanges();
                _userRepository.SaveChanges();
                _productRepo.SaveChanges();
                return Ok(productNeedsAdding);
            }
            catch(Exception)
            {
                return BadRequest();
            }        


        }
    }
}