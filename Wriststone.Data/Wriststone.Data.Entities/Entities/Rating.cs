using System;

namespace Wriststone.Data.Entities.Entities
{
    public class Rating
    {
        public long Id { get; set; }

        public int Rate { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public long? UserId { get; set; }

        public long ProductId { get; set; }
    }
}
