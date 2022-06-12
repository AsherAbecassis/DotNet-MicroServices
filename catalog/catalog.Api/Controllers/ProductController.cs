using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using catalog.Api.Entities;
using catalog.Api.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace catalog.Api.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProduct _iproduct;

        public ProductController(IProduct iproduct)
        {
            _iproduct = iproduct;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>>  GetProducts()
        {
            var products = await _iproduct.GetAllProducts();
            if(products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }

       
    }
}