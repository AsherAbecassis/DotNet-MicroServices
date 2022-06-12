using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Api.Entities;
using catalog.Api.Repo;
using MongoDB.Driver;

namespace catalog.Api.Services
{
    public class ProductServices : IProduct
    {
        private readonly ICatalogContext _catalogServices;
        public ProductServices(ICatalogContext i_catalogServices)
        {
            _catalogServices = i_catalogServices ;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _catalogServices.Products.Find(p => true).ToListAsync();
        }
    }
}