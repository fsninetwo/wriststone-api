﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Entities.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string Payment { get; set; }

        public Guid Guid { get; set; }

        public bool IsCompleted { get; set; }

        public long UserId { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
