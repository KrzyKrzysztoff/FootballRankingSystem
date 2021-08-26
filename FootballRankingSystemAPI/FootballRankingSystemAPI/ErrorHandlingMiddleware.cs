using FootballRankingSystemAPI.Exceptions;
using Microsoft.AspNetCore.Http;
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
                context.Response.StatusCode = 404;
                throw new NotFoundException(notFoundException.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }
    }
}
