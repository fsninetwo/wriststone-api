﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Wriststone.Data.Models.Users
{
    public class UserAuthResponseDTO
    {
        public bool IsAuthSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public string Token { get; set; }
    }
}
