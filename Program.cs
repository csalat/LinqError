using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace LinqError
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = TestClass.Test();
            // second feature the return value evaluation
            // ignore the previous linq error stuff for now
            var r = new ReturnValueDemonstration();
            var functionResponse = r.Get();
            var testValue = functionResponse;

            // fp:
            var match = FunctionalProgramming.Get(true).Match(x => $"success: {x}", error => error);
            var testmatch = match;
        }
    }

    public static class FunctionalProgramming
    {

        public static Either<string, int> Get(bool error)
        {
            return error ? (Either<string, int>) "error" : 42;
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
