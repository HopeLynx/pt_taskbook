// File: "LinqObj88"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj88");

            var a = File.ReadLines(GetString(), Encoding.Default)
            .Select(e => e.Split(' '))
            // .Show()
            ;

            var d = File.ReadLines(GetString(), Encoding.Default)
            .Select(e => e.Split(' '))
            // .Show()
            ;

            var e = File.ReadLines(GetString(), Encoding.Default)
            .Select(e => e.Split(' '))
            // .Show()
            ;

            var ae = a.Join(e, a1 => a1[2], e2 => e2[2], (a3, e3) => new {
                year = a3[1],
                id = a3[2],
                name = e3[1],
                shop = e3[0]
            })
            // .Show()
            ;

            var res = ae.Join(d, ae1 => ae1.name + ae1.shop, d1 => d1[0] + d1[2], (ae3, d3) => new {
                ae3.name,
                ae3.id,
                ae3.shop,
                ae3.year,
                price = d3[1]
            })
            .GroupBy(a => a.year + a.name, (k ,nn) => new {
                year = nn.Select(a => a.year).First(),
                name = nn.Select(a => a.name).First(),
                avg = nn.Select(a => Convert.ToInt32(a.price)).Sum()
            })
            .OrderByDescending(a => a.year).ThenBy(a => a.name)
            .Select(a => a.year + " " + a.name + " " + a.avg);

            File.WriteAllLines(GetString(), res.ToArray(), Encoding.Default);

        }
    }
}
