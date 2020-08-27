using Newtonsoft.Json;

namespace Auto.Pay.Transversal.Common
{
    public static class Util
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static string ConvertJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


    }
}
