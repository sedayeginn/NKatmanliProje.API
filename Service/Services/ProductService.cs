using ApplicationCore.Entities;
using ApplicationCore.Repository;
using ApplicationCore.Service;
using ApplicationCore.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository):base(unitOfWork, repository)
        {

        }
        public async Task<Product> GetCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetCategoryByIdAsync(productId);
        }
    }
}
