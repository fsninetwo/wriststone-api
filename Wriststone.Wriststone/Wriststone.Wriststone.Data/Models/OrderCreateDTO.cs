using System.Collections.Generic;

namespace Wriststone.Wriststone.Data.Models
{
    public class OrderCreateDTO
    {
        public string Payment { get; set; }

        public List<OrderDetailsCreateDTO> OrderDetails { get; set; }
    }
}
