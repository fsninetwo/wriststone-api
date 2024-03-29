﻿using System.Collections.Generic;

namespace Wriststone.Data.Entities.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
