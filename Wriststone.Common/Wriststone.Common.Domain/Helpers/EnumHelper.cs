using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Exceptions;

namespace Wriststone.Common.Domain.Helpers
{
    public static class EnumHelper<TEnum> where TEnum : Enum
    {
        public static string ConvertToString(long value)
        {
            if(!Enum.IsDefined(typeof(TEnum), (int)value))
            {
                throw new InternalException($"This object is not exist in {typeof(TEnum)} enum.");
            }

            var data = (TEnum)Enum.ToObject(typeof(TEnum), (int)value);

            return data.ToString();
        }

        public static long ConvertToLong(string stringValue)
        {
            if (!Enum.IsDefined(typeof(TEnum), stringValue))
            {
                throw new InternalException($"This object is not exist in {typeof(TEnum)} enum.");
            }

            var data = (TEnum)Enum.Parse(typeof(TEnum), stringValue, true);

            return Convert.ToInt64(data);

        }
    }
}
