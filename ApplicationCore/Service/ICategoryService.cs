using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Service
{
   public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsIdAsync(int categoryId);
    }
}
