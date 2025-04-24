# 📈 TradePulse

**Real-Time Market Events Dashboard** built with **Blazor Server** and **SignalR**.

## 🚀 Overview

TradePulse is a web-based application that displays live financial market updates in real-time. It uses **SignalR** for pushing live data and updates the UI instantly via a **Blazor Server** front-end.

## 🛠️ Features

- ✅ Blazor Server project setup
- ✅ Responsive layout with Bootstrap
- ✅ Live market ticker using SignalR
- ✅ Frontend updates automatically on market event triggers
- ✅ SignalR events can be triggered via Postman or other HTTP tools

## 📷 UI Preview



## 🧪 How to Test Live Updates

1. Launch the app (`dotnet run`)
2. Use **Postman** to send a POST request:

```http
POST http://localhost:5007/api/market/update
Content-Type: application/json

{
  "symbol": "AAPL",
  "price": 192.35,
  "timestamp": "2025-04-23T18:00:00Z"
}
The UI will instantly reflect this new market event.

📂 Project Structure
Pages/Index.razor: Displays live ticker

Controllers/MarketController.cs: API endpoint for event triggering

MarketHub.cs: SignalR Hub

wwwroot/js/signalr-client.js: Client-side connection to SignalR

🐞 Known Issues
Occasional Render Errors on SignalR Updates
You may see console errors like:

javascript
Copy code
Error: Cannot read properties of null (reading 'removeChild')
This occurs when SignalR attempts to update the UI after the Blazor component has been disposed or unmounted. While this does not break core functionality, it can be noisy in development mode. This will be addressed in a future sprint by improving lifecycle and connection cleanup logic.



💻 Tech Stack
Blazor Server (.NET)

SignalR

Bootstrap

Postman (for testing)

📌 Future Plans
Add user authentication

Save market events to database

Deploy to Azure or Vercel

Made with ❤️ by Webster Boeing
