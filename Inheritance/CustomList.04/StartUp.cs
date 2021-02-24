using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("abc");
            randomList.Add("xyz");
            randomList.Add("qwerty");
            randomList.Add("123");
            randomList.Add("456");
            randomList.Add("789");

            string randomString = randomList.RandomString();

            Console.WriteLine(randomString);
        }
    }
}
