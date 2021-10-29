using ApplicationCore.Entities;
using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    interface ICategoryRepository :IRepository<Category>
    {
        Task<Category> GetWithProductsIdAsync(int categoryId);
    }
}
