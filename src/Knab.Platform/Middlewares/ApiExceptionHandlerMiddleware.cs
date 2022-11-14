using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Knab.Platform.Middlewares;

public class ApiExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger = Log.ForContext<ExceptionHandlerMiddleware>();

    public ApiExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            httpContext.Items.Add("exception", ex);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            _logger.Error(ex, ex.Message);
        }
    }
}