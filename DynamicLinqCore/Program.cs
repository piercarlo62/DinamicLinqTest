using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamicLinqCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + @"WorkSheets.json";
            string json = File.ReadAllText(filePath);
            var playerList = JsonConvert.DeserializeObject<List<WorkSheet>>(json);

            var wsOrdered = playerList.AsQueryable()
                    .Select(ws => new
                    {
                        provincia = ws.Fields.GetPropertyValue("Indirizzo - Provincia"),
                        citta = ws.Fields.GetPropertyValue("Indirizzo - Città"),
                        workSheet = ws
                    })
                    .OrderBy(x => x.provincia).ThenBy(x => x.citta).Select(x => x.workSheet).ToList();

            foreach (var item in wsOrdered)
            {
                Console.WriteLine("Item Protocol: " + item.Protocol);
            }

            Console.ReadLine();
        }
    }
}
