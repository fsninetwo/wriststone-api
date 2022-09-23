using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.Models
{
    public class UserUpdateDTO
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserGroup UserGroup { get; set; }
    }
}
