﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DynamicLinqCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + @"WorkSheets.json";
            string json = File.ReadAllText(filePath);
            var playerList = JsonConvert.DeserializeObject<List<WorkSheet>>(json);


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
                    expando[item.FormatValueAsProperty(false)] = ws.Fields.GetPropertyValue(item.Replace(" desc",""));
                }
                expando["ws"] = ws;
                dynamic d = expando;
                return d;
            }).AsQueryable().OrderBy(ordeByString).Select("ws").ToDynamicList<WorkSheet>();

            foreach (var item in wsOrdered)
            {
                Console.WriteLine("Item Protocol: " + item.Protocol);
            }

            Console.ReadLine();
        }
    }
}
