using Newtonsoft.Json;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
=======
using System.IO;
using System.Linq;
>>>>>>> bb8c64620c7ba8e76e6688df6ab6424a60f5d42d

namespace DynamicLinqCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + @"WorkSheets.json";
            string json = File.ReadAllText(filePath);
            var playerList = JsonConvert.DeserializeObject<List<WorkSheet>>(json);

<<<<<<< HEAD
            List<string> orderProperties = new List<string>
            {
                "Indirizzo - Provincia" + " desc",
                "Indirizzo - Città"
            };
            string ordeByString = string.Join(",", orderProperties.GetFormattedValueAsAPropertyList());

            var wsOrdered = playerList.Select(ws =>
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (var item in orderProperties)
                {
                    expando[item.FormatValueAsProperty(false)] = ws.Fields.GetPropertyValue(item);
                }
                expando["ws"] = ws;
                dynamic d = expando;
                return d;
            }).AsQueryable().OrderBy(ordeByString).Select("ws").ToDynamicList<WorkSheet>();
=======
            var wsOrdered = playerList.AsQueryable()
                    .Select(ws => new
                    {
                        provincia = ws.Fields.GetPropertyValue("Indirizzo - Provincia"),
                        citta = ws.Fields.GetPropertyValue("Indirizzo - Città"),
                        workSheet = ws
                    })
                    .OrderBy(x => x.provincia).ThenBy(x => x.citta).Select(x => x.workSheet).ToList();
>>>>>>> bb8c64620c7ba8e76e6688df6ab6424a60f5d42d

            foreach (var item in wsOrdered)
            {
                Console.WriteLine("Item Protocol: " + item.Protocol);
            }

            Console.ReadLine();
        }
    }
}
