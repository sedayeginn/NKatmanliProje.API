using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using ApplicationCore.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext appDbContext { get => _context as ApplicationDbContext; }
        public CategoryRepository(ApplicationDbContext context) :base(context)
        {

        }
        public async Task<Category> GetWithProductsIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x=>x.Id==categoryId);
        }
    }
}
