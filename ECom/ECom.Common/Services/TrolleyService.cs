namespace ECom.Common.Services
{
    public class TrolleyService : ITrolleyService
    {
        public decimal CalculateTotal(Trolley trolley)
        {
            return trolley.Total;
        }
    }
}