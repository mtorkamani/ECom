namespace ECom.Common
{
    public class TrolleyItem
    {
        public ProductRef Product { get; set; }
        public double Quantity { get; set; }
        public decimal Total => Product.Price * (decimal)Quantity;
    }
}