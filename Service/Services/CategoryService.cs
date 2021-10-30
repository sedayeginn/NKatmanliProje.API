using ApplicationCore.Entities;
using ApplicationCore.Repository;
using ApplicationCore.Service;
using ApplicationCore.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository): base(unitOfWork, repository)
        {

        }
        public async Task<Category> GetWithProductsIdAsync(int categoryId)
        {
            return await _unitOfWork.categories.GetWithProductsIdAsync(categoryId);
        }
    }
}
