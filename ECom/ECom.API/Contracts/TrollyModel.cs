using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.API.Contracts
{
    public class TrolleyModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<SpecialModel> Specials { get; set; }
        public IEnumerable<QuantityModel> Quantities { get; set; }
    }
}