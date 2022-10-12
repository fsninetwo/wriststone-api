using System.Collections.Generic;

namespace Wriststone.Data.Entities.Entities
{
    public class Currency
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
