using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqError
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = TestClass.Test();
        }
    }


    public static class TestClass
    {
        public static string Test()
        {
            IEnumerable<string> list = new List<string>() {"one"};
            var preData = GetData();
            Dictionary<string, object> data = preData.Pick(list);
            return data.Any() ? GoodCase(data) : null;
        }

        private static string GoodCase(Dictionary<string, object> identity)
        {
            return "good";
        }

        private static Dictionary<string, object> GetData()
        {
            ;
          return new Dictionary<string, object> {{"one", "two"}};
        }
    }

    public static class Ext
    {
        public static Dictionary<string, object> Pick(this Dictionary<string, object> source, IEnumerable<string> keys)
        {
            IEnumerable<KeyValuePair<string, object>> query =
                from f in source
                where keys.Any(name => name == f.Key)
                select f;
            return query.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }

}
