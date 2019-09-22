using System.Collections.Generic;
using System.Linq;

namespace ECom.Common
{
    public class Trolley
    {
        public List<TrolleyItem> Items { get; set; } = new List<TrolleyItem>();
        public List<TrolleySpecial> Specials { get; set; } = new List<TrolleySpecial>();

        public decimal Total => Items.Sum(i => i.Total) + Specials.Sum(s => s.Total);

        public void AddSpecial(TrolleySpecial special)
        {
            Specials.Add(special);
        }

        public void AddItem(ProductRef product, double quantity, bool isSpecial = false)
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