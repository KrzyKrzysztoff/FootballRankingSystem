using FootballRankingSystemAPI.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundException)
            {
             

                var result = JsonConvert.SerializeObject(new { error = notFoundException.Message });
                context.Response.ContentType = "application/json";
               

                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(notFoundException.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
