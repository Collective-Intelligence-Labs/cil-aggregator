using Microsoft.AspNetCore.Mvc;

namespace cil_aggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ItemsController> _logger;

    public ItemsController(ILogger<ItemsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllItems")]
    public IEnumerable<ItemDto> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ItemDto
        {
            Hash = DateOnly.FromDateTime(DateTime.Now.AddDays(index)).ToShortDateString(),
            Owner = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

public class ItemDto
{
    public string Hash { get; set; }
    
    public string Owner { get; set; }
}
