namespace LogItLikeItsHot.Shared.Features
{
    public class PlaceOrderResponse
    {
        public Guid OrderReference { get; set; }
        public string Customer { get; set; } = string.Empty;
        public int TotalCoffees { get; set; }
        public decimal Total { get; set; }
    }
}
