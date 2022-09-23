using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Entities.Entities
{
    public class OrderDetails
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }
    }
}
