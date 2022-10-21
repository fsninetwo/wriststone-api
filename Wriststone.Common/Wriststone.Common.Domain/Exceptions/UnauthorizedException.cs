﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Common.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message, Exception innerException): base(message, innerException)
        {

        }

        public UnauthorizedException(string message): base(message)
        {

        }

        public UnauthorizedException()
        {

        }
    }
}
