// File: "LinqXml51"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqXml51");
            string tmp = GetString();XDocument d = XDocument.Load(tmp);
            //DateTime dt = Convert.ToDateTime("2013-05-02T11:25:35-06:00");
            foreach (var e1 in d.Root.Descendants())
            {
                if (e1.Nodes().OfType<XText>().Count() == 1){
                    //Show(e1.Nodes().OfType<XText>().First().ToString());
                    string test = e1.Nodes().OfType<XText>().First().ToString();
                    if(test.Length < 4) continue;
                    var lul = (test).Split(' ');
                    var lul2 = lul[0];
                    ShowLine(lul2);
                    DateTime tst = Convert.ToDateTime(lul2);
                    ShowLine(lul2);
                    //DateTime tst =Convert.ToDateTime((test).Split(' ').First());
                    e1.Add(new XAttribute("year",tst.Year));
                    var one = e1.Nodes().OfType<XText>().First();
                    one.Remove();//------точно лажа
                    ShowLine(lul2);
                    var i = tst.Day;
                    Show(i);
                    var kek = i.ToString();
                    e1.Add(new XElement("day",new XText(kek)));//------почему-то создаёт фантомный show, при отправке задания никак не регистрирует date
                    ShowLine(lul2);
                    //tst = Convert.ToDateTime(lul2);
                }
            }// это количество show только чтобы пытаться понять почему одна строка  всё ломает

            d.Save(tmp);
        }
    }
}
