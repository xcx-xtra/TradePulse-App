using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


[ApiController]
[Route("api/[controller]")]
public class MarketController : ControllerBase
{
    private readonly IHubContext<MarketHub> _hubContext;

    public MarketController(IHubContext<MarketHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateMarket([FromBody] MarketEvent data)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMarketEvent", data);
        return Ok(new { Message = "Market event sent" });
    }
}

public class MarketEvent
{
    public required string Symbol { get; set; }
    public decimal Price { get; set; }
    public DateTime? Timestamp { get; set; }
}
