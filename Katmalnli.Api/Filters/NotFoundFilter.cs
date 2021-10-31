using ApplicationCore.Service;
using Katmalnli.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.Filters
{
    
    public class NotFoundFilter :ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if(product!=null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Status = 404;
                errorDTO.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı.");
                context.Result = new NotFoundObjectResult(errorDTO);
            }
        }

    }
}
