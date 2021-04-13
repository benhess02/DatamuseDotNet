using System;
using DatamuseDotNet;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DatamuseClient client = new DatamuseClient();
            DatamuseResultItem[] results = client.Words(
                new SpelledLikeModifier("")
            );
            for(int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i].word);
            }
            Console.ReadLine();
        }
    }
}