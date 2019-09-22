using System.Collections.Generic;

namespace ECom.Common
{
    public class TrolleySpecial
    {
        public List<TrolleyItem> Items { get; set; } = new List<TrolleyItem>();
        public decimal Total { get; set; }

        public void AddItem(ProductRef product, double quantity)
        {
            var item = new TrolleyItem
            {
                Product = product,
                Quantity = quantity,
            };
            Items.Add(item);
        }
    }
}