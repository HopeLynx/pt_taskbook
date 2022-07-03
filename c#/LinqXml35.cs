// File: "LinqXml35"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqXml35");
            string tmp = GetString();XDocument d = XDocument.Load(tmp);
            foreach(var el in d.Root.Elements().Elements()) {
                el.Add(new XAttribute("child-count", el.Nodes().Count()));}
            d.Save(tmp);
        }
    }
}
