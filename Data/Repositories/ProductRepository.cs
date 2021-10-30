using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext appDbContext { get => _context as ApplicationDbContext; }
        public ProductRepository(ApplicationDbContext context) :base(context)
        {
          
        }
        public async Task<Product> GetCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);  //ilgili kategorisini de product a ekle dedik
        }
    }
}
