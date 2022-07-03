// File: "LinqXml17"
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
            Task("LinqXml17");
            XDocument d = XDocument.Load(GetString());
            var pair = new {part1="",part2=""};
            var PairList =  (new[]{pair}).ToList();
            PairList.RemoveAll(e=> e.part1 =="");
            foreach (var e1 in d.Root.Descendants())
            {
                if (e1.Nodes().OfType<XText>().Count() == 1){
                    PairList.Add(new {part1 = e1.Name.LocalName,part2 =e1.Nodes().OfType<XText>().First().ToString()});
                }
            }
            PairList.OrderBy(e=>e.part1)/*.Show()*/;
                var last = "";
            foreach(var e in PairList.OrderBy(e=>e.part1)){
                if (e.part1 != last) {Put(e.part1);Show(e.part1);}
                Put(e.part2);Show(e.part2);
                last = e.part1;
            }

        }
    }
}
