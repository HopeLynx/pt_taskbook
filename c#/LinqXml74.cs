// File: "LinqXml74"
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
            Task("LinqXml74");
            var s = GetString();
            var d = XDocument.Load(s);
            var ns = d.Root.Name.Namespace;

            var stats = d.Root.Elements().Select(
                e=> {
                    var sp = e.Element(ns+"company").Attribute("station").Value.Split('_');
                    var comp = e.Element(ns+"company");
                    return (br:e.Name.LocalName,comp:sp[2],st:sp[0]+"_"+sp[1],pr:(int)(e.Element(ns+"company").Attribute("price")));
                }
            ).Show();

            var strt = stats.Select(e=>e.st).Distinct().Show();

            var el = stats.GroupBy(e=>e.comp).Select(e=>(comp:e.Key,locs:strt.GroupJoin(e,strt=>strt,e=>e.st,(strt,e)=>(strt:strt,
            b92:e.Where(e=>e.br == "brand92").Select(e=>e.pr).FirstOrDefault(),
            b95:e.Where(e=>e.br == "brand95").Select(e=>e.pr).FirstOrDefault(),
            b98:e.Where(e=>e.br == "brand98").Select(e=>e.pr).FirstOrDefault()
            )))).Show();

            var res = el.OrderBy(e=>e.comp).Select(e=>(comp:e.comp,locs:e.locs.OrderBy(e=>e.strt)))
            .Select(e => new XElement(
                ns+e.comp,e.locs.Select(e=> new XElement(
                    ns+e.strt,new XAttribute("brand92",e.b92),new XAttribute("brand95",e.b95),new XAttribute("brand98",e.b98)
                ))
            )).Show();
            
            d.Root.ReplaceNodes(res);d.Save(s);
        }
    }
}
