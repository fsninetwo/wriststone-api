using System.Collections.Generic;

namespace Wriststone.Wriststone.Data.Models.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public List<RatingDTO> Ratings { get; set; }
    }
}
