// File: "LinqXml16"
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
            Task("LinqXml16");

            XDocument d = XDocument.Load(GetString());

            var res = new (string, int)[10];
            int count = 0;
            foreach (var e1 in d.Root.Elements())
            {
                string p = e1.Name.LocalName;
                int num = e1.Elements().Select(e => e.Elements().Attributes().Count()).Sum();
                (string, int) tt = (p, num);
                res[count++] = tt;
            } 
            
            var rr = res.Take(count).OrderByDescending(a => a.Item2).ThenBy(a => a.Item1);
            foreach(var el in rr) {
                Put(el.Item2);
                Put(el.Item1);
            }

        }
    }
}
