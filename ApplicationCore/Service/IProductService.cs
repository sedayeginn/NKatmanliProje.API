using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Service
{
   public interface IProductService:IService<Product>
    {
        Task<Product> GetCategoryByIdAsync(int productId);
    }
}
