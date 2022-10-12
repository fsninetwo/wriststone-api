using System;

namespace Wriststone.Wriststone.Data.Models
{
    public class RatingUpdateDTO
    {
        public long Id { get; set; }

        public int Rate { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public long ProductId { get; set; }
    }
}
