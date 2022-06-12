using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Api.Entities;
using MongoDB.Driver;

namespace catalog.Api.Repo
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products{get; }
    }
}