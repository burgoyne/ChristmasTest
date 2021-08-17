using System;
using System.Collections.Generic;

namespace ChristmasTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameList = new List<string>(){
                "Andre",
                "Kasey",
                "Jordan",
                "Rachel",
                "Jeni",
                "Greg",
                "Nathan",
                "Lacey",
                "Chad",
                "Allie",
            };

            HashSet<(string name1, string name2)> notAllowed = new HashSet<(string, string)>()
            {
                ("Andre", "Kasey"),
                ("Chad", "Allie"),
                ("Lacey", "Nathan"),
                ("Jeni", "Greg")
            };

            HashSet<(string name1, string name2)> matches = new HashSet<(string, string)>();
            Random rnd = new Random();
            int attempts = 0;
            while (true)
            {
                if (matches.Count == 10)
                {
                    Console.WriteLine($"{attempts} iterations.");
                    break;
                }
                var r1 = rnd.Next(0, nameList.Count);
                var r2 = rnd.Next(0, nameList.Count);

                //Make sure these are allowed...
                if (r1 != r2 && !notAllowed.Contains((nameList[r1], nameList[r2])) && !notAllowed.Contains((nameList[r2], nameList[r1])))
                {
                    matches.Add((nameList[r1], nameList[r2]));
                    nameList.RemoveAll(x => x == nameList[r1] || x == nameList[r2]);
                }
                //We tried too hard
                if (attempts == 10000)
                {
                    Console.WriteLine("Tried too hard");
                    foreach (var n in nameList)
                    {
                        Console.WriteLine($"{n} remains.");
                    }
                    break;
                }
                attempts++;
            }

            var count = 1;
            foreach (var (name1, name2) in matches)
            {
                Console.WriteLine($"{count}: {name1} has {name2}");
                count++;
            }
            Console.ReadLine();
        }
    }
}
