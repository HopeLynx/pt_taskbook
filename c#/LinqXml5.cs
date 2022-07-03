// File: "LinqXml5"
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
        // When solving tasks of the LinqXml group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqXml5");
            var a = File.ReadAllLines(GetString(), Encoding.Default);
            XDocument d = new XDocument(
                new XDeclaration(null, "us-ascii", null),
                new XElement("root",
                    a.Select(e => new XElement("line"/* new XAttribute("num",e.Count()),*/
                        //new XElement("word",e)
                        )
                    )
                )
            );
            var f=1;
            foreach(var el in d.Root.Elements()) {
                var tmp = a[f-1].Split();
                el.Add(new XAttribute("num", f++));
                var cnt = 1;
                foreach (var g in tmp){
                    el.Add(new XElement("word",new XAttribute("num",cnt++), g));
                
                }
                cnt =1;
                Show(tmp);
                
            }
            f=1;
            d.Save(GetString());
        }
    }
}
