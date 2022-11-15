using Microsoft.AspNetCore.Mvc;

namespace Knab.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RatesController : ControllerBase
{
    [HttpGet("{symbol}")]
    public Task GetAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}