using ApplicationCore.Entities;
using AutoMapper;
using Katmalnli.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryWithProductDTO>();
            CreateMap<CategoryWithProductDTO, Category>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<ProductWithCategoryDTO, Product>();
        }
    }
}
