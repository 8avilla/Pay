using System;
using System.Collections.Generic;

namespace Auto.Pay.Transversal.Common
{
    public static class ExceptionExtensions
    {
        public static List<string> GetList(this Exception e) {

            return new List<string>
            {
                e.Message
            };
        }
    }
}
