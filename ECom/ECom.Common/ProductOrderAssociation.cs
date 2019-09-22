using System.Collections.Generic;

namespace ECom.Common
{
    public class ProductCustomerAssociation
    {
        public Product Product { get; set; }
        public Dictionary<int, double> CustomerQuantities { get; set; } = new Dictionary<int, double>();
        public double TotalQuantity { get; set; }

        public ProductCustomerAssociation(Product product, Order order)
        {
            this.Product = product;
            this.CustomerQuantities.Add(order.CustomerId, product.Quantity);
            this.TotalQuantity = product.Quantity;
        }

        public void AddAssociation(Product product, Order order)
        {
            if (CustomerQuantities.ContainsKey(order.CustomerId))
            {
                CustomerQuantities[order.CustomerId] += product.Quantity;
            }
            else
            {
                CustomerQuantities.Add(order.CustomerId, product.Quantity);
            }
            TotalQuantity += product.Quantity;
        }

        //public int Popularity => CustomerIds.Count;
        public double Popularity => TotalQuantity;
    }
}
