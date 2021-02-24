using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackStrings = new StackOfStrings();

            List<string> strings = new List<string>();

            strings.Add("abc");
            strings.Add("def");
            strings.Add("xyz");
            strings.Add("qwerty");
            strings.Add("123");
            strings.Add("0987");

            Stack<string> result = stackStrings.AddRange(strings);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
