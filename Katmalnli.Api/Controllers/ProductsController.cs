using ApplicationCore.Entities;
using ApplicationCore.Service;
using AutoMapper;
using Katmalnli.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var product = await _productService.GetCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDTO>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDTO));
            return Created(String.Empty, _mapper.Map<CategoryDTO>(newProduct));

        }

        [HttpPut]
        public IActionResult Update(ProductDTO productDTO)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDTO));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
    }
}
