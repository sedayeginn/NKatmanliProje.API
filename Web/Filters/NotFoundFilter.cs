
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiService;
using Web.DTOs;

namespace Web.Filters
{
    
    public class NotFoundFilter :ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;
        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryApiService.GetByIdAsync(id);
            if(product!=null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı.");
                context.Result = new RedirectToActionResult("Error", "Home", errorDTO);
                context.Result = new NotFoundObjectResult(errorDTO);
            }
        }

    }
}
