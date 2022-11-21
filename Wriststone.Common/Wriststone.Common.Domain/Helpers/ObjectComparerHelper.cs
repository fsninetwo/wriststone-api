using Newtonsoft.Json;

namespace Wriststone.Common.Domain.Helpers
{
    public static class ObjectComparerHelper
    {
        public static bool JsonCompare(this object expected, object actual)
        {
            if (ReferenceEquals(expected, actual))
            {
                return true;
            }

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            return expectedJson == actualJson;
        }

    }
}
