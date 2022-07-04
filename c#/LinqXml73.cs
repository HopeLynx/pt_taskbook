// File: "LinqXml73"
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
            Task("LinqXml73");
            var s = GetString();
            var d = XDocument.Load(s);
            var ns = d.Root.Name.Namespace;

            var et = d.Root.Elements().SelectMany(e =>e.Elements().Select(
                    ee=> (st: e.Name.LocalName,comp:ee.Attribute("name").Value,
                    br:ee.Element(ns +"brand").Value,pr:ee.Element(ns+"price").Value)
                    )
                ).Show();

            var mb_ans = et.GroupBy(e=> (st: e.st,comp: e.comp)).Select(e=> (
                st: e.Key.st, comp: e.Key.comp, brC:e.GroupBy(e=>e.br).Count(),
                brpr: e.Select(e=> (br:e.br,pr:e.pr)).OrderBy(e=>e.br)
            )).Show();

            var mb_res = mb_ans.Where(e=>e.brC>1).Show();

            var res = mb_res.OrderBy(e=>e.comp).ThenBy(e=>e.st).Select(
                e => new XElement(
                    ns+e.comp+"_"+e.st,new XAttribute("brand-count",e.brC.ToString()),
                    e.brpr.Select(e=>new XElement(ns+$"b{e.br}",new XAttribute("price",e.pr.ToString())))
                )
            ).Show();
            
            d.Root.ReplaceNodes(res);d.Save(s);
        }
    }
}
