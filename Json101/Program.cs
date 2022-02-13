using System;
using System.IO;
using Json101.Models;
using Newtonsoft.Json;

namespace Json101
{
    internal static class Program
    {
        public static void Main()
        {
            var fileName = "Data.json";
            string json = File.ReadAllText(fileName);
            var root = JsonConvert.DeserializeObject<Root>(json);
            root.Persons[0].Address.City = "ISPARTA";
            string json2 = JsonConvert.SerializeObject(root, Formatting.Indented);
            Console.WriteLine(json2);
        }
    }
}