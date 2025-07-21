# 📈 TradePulse

**Professional Real-Time Market Dashboard** built with **Blazor Server**, **SignalR**, and modern UI components.

## 🚀 Overview

TradePulse is a comprehensive web-based market monitoring application that provides real-time financial market updates through an intuitive, professional dashboard interface. Built with Blazor Server and SignalR, it delivers instant market data visualization with modern UI/UX design principles.

## ✨ Features

### Core Functionality

- ✅ **Real-time market data streaming** via SignalR
- ✅ **Professional dashboard interface** with modern design system
- ✅ **Live market chart visualization** with Chart.js integration
- ✅ **Market summary cards** showing key metrics and trends
- ✅ **Market events feed** with real-time updates and filtering
- ✅ **Connection status monitoring** with automatic reconnection
- ✅ **Responsive design** optimized for desktop, tablet, and mobile

### UI/UX Enhancements

- ✅ **Modern glass-morphism design** with CSS custom properties
- ✅ **Dark/light theme support** with smooth transitions
- ✅ **Professional navigation** with branded header
- ✅ **Loading states and skeleton loaders** for better UX
- ✅ **Error boundaries** with user-friendly error handling
- ✅ **Performance monitoring** with real-time metrics
- ✅ **Accessibility features** with ARIA labels and keyboard navigation

### Technical Features

- ✅ **Component-based architecture** with reusable UI components
- ✅ **Memory leak prevention** with proper resource cleanup
- ✅ **Performance optimization** with throttled updates
- ✅ **Toast notifications** for system feedback
- ✅ **Search and filtering** capabilities for market events

## 🧪 How to Test Live Updates

1. **Launch the application:**

   ```bash
   cd TradePulse/TradePulse.Server
   dotnet run
   ```

2. **Send market updates via API:**

   ```http
   POST http://localhost:5007/api/market/update
   Content-Type: application/json

   {
     "symbol": "AAPL",
     "price": 192.35,
     "volume": 1000000,
     "timestamp": "2025-01-21T18:00:00Z"
   }
   ```

3. **Watch real-time updates:**
   - Market summary cards update instantly
   - Live chart displays new data points
   - Events feed shows the latest market activity
   - Connection status indicates live data flow

## 📂 Project Architecture

```
TradePulse/TradePulse.Server/
├── Controllers/
│   └── MarketController.cs          # REST API endpoints
├── Models/
│   └── MarketEvent.cs              # Data models
├── Services/
│   └── MarketDataService.cs        # Business logic
├── Pages/
│   ├── Dashboard.razor             # Main dashboard page
│   ├── Index.razor                 # Entry point (redirects to dashboard)
│   └── LiveMarketChart.razor       # Chart component
├── Shared/
│   ├── MainLayout.razor            # Application layout
│   ├── Header.razor                # Navigation header
│   ├── NavMenu.razor               # Navigation menu
│   ├── MarketSummaryCards.razor    # Summary metrics
│   ├── MarketEventsList.razor      # Events feed
│   ├── ConnectionStatus.razor      # Connection indicator
│   ├── LoadingSpinner.razor        # Loading states
│   ├── SkeletonLoader.razor        # Skeleton loading
│   └── ToastNotifications.razor    # Toast messages
├── wwwroot/
│   ├── css/design-system.css       # Design system variables
│   └── js/                         # Client-side scripts
├── MarketHub.cs                    # SignalR hub
└── Program.cs                      # Application startup
```

## 💻 Tech Stack

### Backend

- **.NET 9.0** - Target framework
- **Blazor Server** - Server-side rendering with real-time UI updates
- **SignalR** - Real-time bidirectional communication
- **ASP.NET Core** - Web API and hosting framework

### Frontend & UI

- **Blazorise 1.7.6** - Blazor component library
- **Bootstrap** - CSS framework for responsive design
- **Chart.js** - Interactive chart visualization
- **FontAwesome** - Icon library
- **CSS Custom Properties** - Modern design system

### Development Tools

- **Visual Studio Code** with Kiro AI assistant
- **Postman** - API testing
- **Browser DevTools** - Debugging and performance monitoring

## 🎨 Design System

The application uses a comprehensive design system with:

- **CSS Custom Properties** for consistent theming
- **Glass-morphism effects** with backdrop filters
- **Responsive breakpoints** for all device sizes
- **Accessibility-first approach** with ARIA labels
- **Performance-optimized animations** and transitions

## 🔧 Development Commands

```bash
# Run in development mode
dotnet run

# Build the project
dotnet build

# Restore packages
dotnet restore

# Clean build artifacts
dotnet clean

# Test market updates (Windows CMD)
curl -X POST http://localhost:5007/api/market/update ^
  -H "Content-Type: application/json" ^
  -d "{\"symbol\":\"AAPL\",\"price\":192.35,\"volume\":1000000,\"timestamp\":\"2025-01-21T18:00:00Z\"}"
```

## 🚀 Recent Improvements

### UI/UX Enhancements (v2.0)

- **Professional dashboard redesign** with modern components
- **Enhanced chart visualization** with smooth animations
- **Improved responsive design** for all screen sizes
- **Better error handling** and user feedback
- **Performance optimizations** and memory leak fixes
- **Accessibility improvements** with ARIA support

## 📌 Future Roadmap

- [ ] **User authentication** and personalized dashboards
- [ ] **Data persistence** with database integration
- [ ] **Advanced charting** with multiple timeframes
- [ ] **Portfolio tracking** and watchlist features
- [ ] **Real market data integration** (Alpha Vantage, Yahoo Finance)
- [ ] **Mobile app** with React Native or MAUI
- [ ] **Cloud deployment** to Azure or AWS

## 🐞 Known Limitations

- **In-memory data storage** - Data resets on application restart
- **Simulated market data** - Uses test API endpoints for demonstration
- **Single-user experience** - No multi-user support yet

---

**Made with ❤️ by Webster Boeing** | _Powered by Blazor Server & SignalR_
