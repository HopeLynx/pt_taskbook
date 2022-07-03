// File: "LinqXml29"
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
            Task("LinqXml29");
            string tmp = GetString();
            XDocument d = XDocument.Load(tmp);
            foreach(var el in d.Root.Elements()) {
                if(el.DescendantNodes().Count()==0)el.Remove();
            }
            foreach(var el in d.Root.Elements().Elements()) {
                if(el.DescendantNodes().Count()==0)el.Remove();
            }

            d.Save(tmp);
        }
    }
}
