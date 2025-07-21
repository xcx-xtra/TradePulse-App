# Technology Stack & Build System

## Core Technologies

- **.NET 9.0** - Target framework
- **Blazor Server** - Web UI framework with server-side rendering
- **SignalR** - Real-time communication between server and clients
- **ASP.NET Core** - Web API and hosting framework

## UI Libraries & Frameworks

- **Bootstrap** - CSS framework for responsive design
- **Blazorise** - Blazor component library with Bootstrap provider
- **Blazor.Bootstrap** - Additional Bootstrap components for Blazor
- **FontAwesome** - Icon library via Blazorise.Icons.FontAwesome
- **Chart.js** - Charting library via Blazorise.Charts

## Project Configuration

- **Nullable reference types enabled**
- **Implicit usings enabled**
- **Blazorise immediate mode enabled** for better performance

## Common Commands

### Development

```bash
# Run the application in development mode
dotnet run

# Build the project
dotnet build

# Restore NuGet packages
dotnet restore

# Clean build artifacts
dotnet clean
```

### Testing Real-time Features

```bash
# Test market updates via curl (Windows cmd)
curl -X POST http://localhost:5007/api/market/update ^
  -H "Content-Type: application/json" ^
  -d "{\"symbol\":\"AAPL\",\"price\":192.35,\"timestamp\":\"2025-04-23T18:00:00Z\"}"
```

## Development Server

- Default port: `5007`
- SignalR hub endpoint: `/markethub`
- API base path: `/api`

## Build Output

- Build artifacts: `bin/` and `obj/` folders
- Static files served from: `wwwroot/`
