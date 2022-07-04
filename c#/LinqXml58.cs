// File: "LinqXml58"
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
            Task("LinqXml58");
            string name = GetString(), s1 = GetString();
            XDocument d = XDocument.Load(name);
            d.Root.Add(new XAttribute(XNamespace.Xmlns + "node", s1));
            XNamespace ns1 = (XNamespace)s1;
            XNamespace ns2 = XNamespace.Xml;
            
            foreach (var e in d.Root.Elements()){
                e.Add(new XAttribute(ns1 +"count",e.DescendantNodes().Count()));
                e.Add(new XAttribute(ns2 +"count",e.Descendants().Count()));
            }
            //d.Descendants().Attributes("xmlns").Remove();
            d.Save(name);
        }
    }
}
