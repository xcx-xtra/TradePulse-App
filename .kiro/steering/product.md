# TradePulse Product Overview

TradePulse is a real-time market events dashboard that displays live financial market updates. The application provides instant market data visualization through a web-based interface.

## Core Features

- Real-time market ticker displaying live financial data
- Instant UI updates via SignalR push notifications
- REST API endpoints for triggering market events
- Responsive Bootstrap-based UI design
- Live market data visualization with charts

## Key Use Cases

- Monitor live market events and price changes
- Test real-time data flows via API endpoints
- Display financial market data in a dashboard format
- Demonstrate real-time web application capabilities

## Testing Approach

Market events can be triggered via HTTP POST requests to `/api/market/update` endpoint, making it easy to test real-time functionality using tools like Postman.

## Known Limitations

- Occasional render errors during SignalR updates when components are disposed
- Currently no data persistence (in-memory only)
- No user authentication system implemented yet
