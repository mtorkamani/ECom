using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.API.Contracts
{
    public class SpecialModel
    {
        public IEnumerable<QuantityModel> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}