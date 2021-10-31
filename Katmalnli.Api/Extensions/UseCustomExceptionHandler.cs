﻿using Katmalnli.Api.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.Extensions
{
    public static class UseCustomExceptionHandler
    {
        //var olan objelerin üzerine ekstra yazdığımız methotlardır
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDTO errorDTO = new ErrorDTO();
                        errorDTO.Status = 500;
                        errorDTO.Errors.Add(ex.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDTO));
                    }
                });
            });
        }
    }
}
