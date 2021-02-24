using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>    {

        public StackOfStrings()
        {

        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (string element in collection)
            {
                Push(element);
            }

            return this;
        }
    }
}
