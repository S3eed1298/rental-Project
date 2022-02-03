using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rental_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "customers.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
