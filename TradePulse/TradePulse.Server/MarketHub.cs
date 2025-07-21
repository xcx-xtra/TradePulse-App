using Microsoft.AspNetCore.SignalR;

public class MarketHub : Hub
{
    public async Task SendMarketEvent(MarketEvent marketEvent)
    {
        await Clients.All.SendAsync("ReceiveMarketEvent", marketEvent);
    }
}