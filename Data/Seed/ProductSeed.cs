using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Seed
{
   public class ProductSeed :IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "pilot kalem", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, ProductName = "kurşun kalem", Price = 4.50m, Stock = 80, CategoryId = _ids[0] },
                new Product { Id = 3, ProductName = "tükenmez kalem", Price = 2.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 4, ProductName = "defter kalem", Price = 12.75m, Stock = 10, CategoryId = _ids[1]});
        }
    }
}
