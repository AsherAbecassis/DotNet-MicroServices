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

        
        
        public async Task CreateProduct(Product product)
        {
            await _catalogServices.Products.InsertOneAsync(product);
        }

        
        
        public async Task<bool> DeleteProduct(string id)
        {
           FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _catalogServices
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        
        
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _catalogServices.Products.Find(p => true).ToListAsync();
        }

        
        
        public async Task<Product> GetProduct(string id)
        {
            return await _catalogServices.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        
        
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _catalogServices
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        
        
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
             FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _catalogServices
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        
        
        public async Task<bool> UpdateProduct(Product product)
        {
             var updateResult = await _catalogServices
                                        .Products
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}