using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoVendasAPI.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Query.TryGetValue(Configuration.ApiKeyName, out var ExtractedApiKey))
        {
            context.Result = new ContentResult()
            {
                StatusCode = 401,
                Content = "Api nao encontrada"
            };
            return;
        }

        if (!Configuration.ApiKey.Equals(ExtractedApiKey))
        {
            context.Result = new ContentResult()
            {
                StatusCode = 403,
                Content = "Acesso nao autorizado"
            };
            return;
        }
        
        await next();
    }
}