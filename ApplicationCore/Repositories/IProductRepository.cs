using ApplicationCore.Entities;
using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetCategoryByIdAsync(int productId);
    }
}
