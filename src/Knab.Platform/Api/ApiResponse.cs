using System.Net;

namespace Knab.Platform.Api;

public class ApiResponse
{
    public string? Error { get; set; }

    public bool IsSuccess { get; set; }

    public object? Data { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public ApiResponse(string? error, bool isSuccess, object? data, HttpStatusCode statusCode)
    {
        Error = error;
        IsSuccess = isSuccess;
        Data = data;
        StatusCode = statusCode;    
    }

    public static ApiResponse Create(HttpStatusCode statusCode, object? body, string? error)
    {
        return new ApiResponse(error, string.IsNullOrWhiteSpace(error), body, statusCode);
    }
}