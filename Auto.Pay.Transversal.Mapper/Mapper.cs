using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auto.Pay.Transversal.Mapper
{
    public static class Mapper
    {
        public static T MapTo<T>(this object value)
        {
            return JsonConvert.DeserializeObject<T>(
                JsonConvert.SerializeObject(value)
                );
        }


        public static T MapTo<T>(this IEnumerable<object> value)
        {
            return JsonConvert.DeserializeObject<T>(
                JsonConvert.SerializeObject(value)
                );
        }
    }
}
