using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "";
            Console.WriteLine("Who do you want to say hello to?");
            text = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", text);
        }
    }
}
