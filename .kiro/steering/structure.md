# Project Structure & Organization

## Repository Layout

```
TradePulse-App/
├── TradePulse/
│   ├── TradePulse.sln              # Solution file
│   ├── _imports.razor              # Global Blazor imports
│   └── TradePulse.Server/          # Main Blazor Server project
└── README.md
```

## Main Project Structure (TradePulse.Server/)

```
TradePulse.Server/
├── Controllers/                    # Web API controllers
│   └── MarketController.cs        # Market data API endpoints
├── Pages/                         # Blazor pages and components
│   ├── _Host.cshtml              # Blazor Server host page
│   ├── Index.razor               # Main dashboard page
│   └── LiveMarketChart.razor     # Chart component
├── Shared/                        # Shared Blazor components
├── wwwroot/                       # Static web assets
│   └── js/                       # Client-side JavaScript
│       └── signalr-client.js     # SignalR client connection
├── Properties/                    # Project properties
├── App.razor                      # Root Blazor component
├── Program.cs                     # Application startup and configuration
├── MarketHub.cs                   # SignalR hub for real-time communication
├── TradePulse.Server.csproj      # Project file with dependencies
└── appsettings.json              # Application configuration
```

## Naming Conventions

- **Controllers**: `[Entity]Controller.cs` (e.g., `MarketController.cs`)
- **SignalR Hubs**: `[Entity]Hub.cs` (e.g., `MarketHub.cs`)
- **Blazor Pages**: `[PageName].razor` (e.g., `Index.razor`)
- **API Routes**: `/api/[controller]/[action]` (e.g., `/api/market/update`)
- **SignalR Endpoints**: `/[entity]hub` (e.g., `/markethub`)

## Code Organization Patterns

- **API Controllers**: Located in `Controllers/` folder, inherit from `ControllerBase`
- **SignalR Hubs**: Root level files, inherit from `Hub`
- **Blazor Components**: Organized in `Pages/` for routable pages, `Shared/` for reusable components
- **Models**: Defined inline with controllers or as separate classes when shared
- **Static Assets**: All client-side files in `wwwroot/`

## Configuration Files

- `appsettings.json` - Production configuration
- `appsettings.Development.json` - Development-specific settings
- `TradePulse.Server.csproj` - NuGet package references and build settings
- `_imports.razor` - Global using statements for Blazor components

## Key Architectural Patterns

- **Hub-based real-time communication** via SignalR
- **Server-side Blazor** with component-based UI
- **RESTful API design** for external integrations
- **Dependency injection** for service management
- **Separation of concerns** between API, SignalR, and UI layers
