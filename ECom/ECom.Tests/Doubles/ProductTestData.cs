using ECom.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECom.Tests.Doubles
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { SortOption.Ascending, products.OrderBy(p => p.Name) };
            yield return new object[] { SortOption.Descending, products.OrderByDescending(p => p.Name) };
            yield return new object[] { SortOption.Low, products.OrderBy(p => p.Price) };
            yield return new object[] { SortOption.High, products.OrderByDescending(p => p.Price) };
            yield return new object[] { SortOption.Recommended, new Product[] { products[2], products[0], products[1] } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Product[] products = new Product[]
        {
            new Product
            {
                Name = "P A",
                Price=1.0m,
                Quantity=1.0
            },
            new Product
            {
                Name = "P C",
                Price=3.0m,
                Quantity=3.0
            },
            new Product
            {
                Name = "P B",
                Price=2.0m,
                Quantity=2.0
            },
        };

        public static ShopperHistory shopperHistory = new ShopperHistory
        {
            Orders = new Order[] {
                new Order
                {
                    CustomerId = 1,
                    Products = new Product[] { products[0], products[2] }
                },
                new Order
                {
                    CustomerId = 2,
                    Products = new Product[] { products[0], products[2] }
                },
                new Order
                {
                    CustomerId = 3,
                    Products = new Product[] { products[0], products[1]}
                },
            }
        };
    }
}
