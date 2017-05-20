
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Utils
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        context.Result = new JsonResult(new
        {
            Message = exception.Message,
            StatusCode = (int?)HttpStatusCode.InternalServerError 
        });
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    }
}
}