
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiService;
using Web.DTOs;
using Web.Filters;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public CategoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {

            _categoryApiService = categoryApiService;

            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            await _categoryApiService.AddAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            await _categoryApiService.Update(categoryDTO);
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
