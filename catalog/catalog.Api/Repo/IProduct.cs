using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Api.Entities;

namespace catalog.Api.Repo
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}