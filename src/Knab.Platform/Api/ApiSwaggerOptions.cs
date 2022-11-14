using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Knab.Platform.Api;

public class ApiSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    
    public ApiSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var apiVersionDescription in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                apiVersionDescription.GroupName, 
                CreateVersionInfo(apiVersionDescription));
        }
    }

    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    
    private OpenApiInfo CreateVersionInfo(
        ApiVersionDescription description)
    {
        var assemblyName = Assembly.GetEntryAssembly().GetName().Name; 
        var info = new OpenApiInfo()
        {
            Title = assemblyName,
            Description = "Api Documentation",
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " is deprecated.";
        }

        return info;
    }
}