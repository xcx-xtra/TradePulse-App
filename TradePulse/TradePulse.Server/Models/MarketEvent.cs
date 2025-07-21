namespace TradePulse.Server.Models
{
    public class MarketEvent
    {
        public string? Symbol { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Timestamp { get; set; }
        public decimal? Volume { get; set; }
        public string? Description { get; set; }
        
        // Additional properties for enhanced functionality
        public decimal? PreviousPrice { get; set; }
        public decimal? Change => Price.HasValue && PreviousPrice.HasValue ? Price - PreviousPrice : null;
        public decimal? ChangePercent => PreviousPrice.HasValue && PreviousPrice != 0 && Change.HasValue ? (Change / PreviousPrice) * 100 : null;
        public string Trend { get; set; } = "neutral";
    }
}
