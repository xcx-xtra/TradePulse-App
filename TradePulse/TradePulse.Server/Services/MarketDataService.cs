using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using TradePulse.Server.Models;

namespace TradePulse.Server.Services
{
    public interface IMarketDataService : IAsyncDisposable
    {
        event Func<MarketEvent, Task>? MarketEventReceived;
        event Func<HubConnectionState, Task>? ConnectionStateChanged;
        
        Task StartAsync();
        Task StopAsync();
        HubConnectionState ConnectionState { get; }
        bool IsConnected { get; }
    }

    public class MarketDataService : IMarketDataService
    {
        private readonly ILogger<MarketDataService> _logger;
        private readonly NavigationManager _navigationManager;
        private HubConnection? _connection;
        private bool _disposed = false;

        public event Func<MarketEvent, Task>? MarketEventReceived;
        public event Func<HubConnectionState, Task>? ConnectionStateChanged;

        public HubConnectionState ConnectionState => _connection?.State ?? HubConnectionState.Disconnected;
        public bool IsConnected => ConnectionState == HubConnectionState.Connected;

        public MarketDataService(ILogger<MarketDataService> logger, NavigationManager navigationManager)
        {
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public async Task StartAsync()
        {
            if (_disposed) return;

            try
            {
                _connection = new HubConnectionBuilder()
                    .WithUrl(_navigationManager.ToAbsoluteUri("/markethub"))
                    .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) })
                    .Build();

                // Subscribe to connection state changes
                _connection.Closed += OnConnectionClosed;
                _connection.Reconnecting += OnReconnecting;
                _connection.Reconnected += OnReconnected;

                // Subscribe to market events
                _connection.On<MarketEvent>("ReceiveMarketEvent", async marketEvent =>
                {
                    try
                    {
                        if (MarketEventReceived != null)
                        {
                            await MarketEventReceived.Invoke(marketEvent);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing market event: {Symbol} - {Price}", marketEvent.Symbol, marketEvent.Price);
                    }
                });

                await _connection.StartAsync();
                _logger.LogInformation("SignalR connection started successfully");
                
                // Notify connection state change
                await NotifyConnectionStateChanged();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start SignalR connection");
                await NotifyConnectionStateChanged();
            }
        }

        public async Task StopAsync()
        {
            if (_connection != null)
            {
                try
                {
                    await _connection.StopAsync();
                    _logger.LogInformation("SignalR connection stopped");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error stopping SignalR connection");
                }
            }
        }

        private async Task OnConnectionClosed(Exception? exception)
        {
            _logger.LogWarning("SignalR connection closed. Exception: {Exception}", exception?.Message);
            await NotifyConnectionStateChanged();
        }

        private async Task OnReconnecting(Exception? exception)
        {
            _logger.LogInformation("SignalR connection reconnecting...");
            await NotifyConnectionStateChanged();
        }

        private async Task OnReconnected(string? connectionId)
        {
            _logger.LogInformation("SignalR connection reconnected with ID: {ConnectionId}", connectionId);
            await NotifyConnectionStateChanged();
        }

        private async Task NotifyConnectionStateChanged()
        {
            try
            {
                if (ConnectionStateChanged != null)
                {
                    await ConnectionStateChanged.Invoke(ConnectionState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error notifying connection state change");
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed) return;
            _disposed = true;

            if (_connection != null)
            {
                _connection.Closed -= OnConnectionClosed;
                _connection.Reconnecting -= OnReconnecting;
                _connection.Reconnected -= OnReconnected;
                
                await _connection.DisposeAsync();
            }
        }
    }
}
