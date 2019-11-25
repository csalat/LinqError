using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LinqError
{
    public class ReturnValueDemonstration
    {
        public FunctionResponse Get()
        {
            return Add(GetOneValue(), GetTwoValue()); 
            // here i would like to see the return value by default!
        }

        private FunctionResponse Add(in int one, in int two)
        {
            return new FunctionResponse(one, two);
        }

        private int GetOneValue()
        {
            return 1;
        }

        private int GetTwoValue()
        {
            return 2;
        }
    }

    public class FunctionResponse
    {
        public int One { get; }
        public int Two { get; }

        public FunctionResponse(in int one, in int two)
        {
            One = one;
            Two = two;
        }
    }
}
