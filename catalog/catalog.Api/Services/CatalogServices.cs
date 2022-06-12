using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Api.Entities;
using catalog.Api.Repo;
using MongoDB.Driver;

namespace catalog.Api.Services
{
    public class CatalogServices : ICatalogContext
    {
        public CatalogServices(IConfiguration i_configuration)
        {
            var client = new MongoClient(i_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var dataBase = client.GetDatabase(i_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = dataBase.GetCollection<Product>(i_configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogDataSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products {get;}
    }
    
}