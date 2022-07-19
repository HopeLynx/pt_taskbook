// File: "LinqObj97"
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
            Task("LinqObj97");

            var b = File.ReadLines(GetString(), Encoding.Default)
            .Select(a => a.Split(' '))
            // .Show()
            ;

            var c = File.ReadLines(GetString(), Encoding.Default)
            .Select(a => a.Split(' '));

            var d = File.ReadLines(GetString(), Encoding.Default)
            .Select(a => a.Split(' '));

            var e = File.ReadLines(GetString(), Encoding.Default)
            .Select(a => a.Split(' '));

            var bed = b.Join(e, b1 => b1[1], e1 => e1[2], ((b3, e3) => new {
                country = b3[2],
                item = b3[1],
                man = e3[1],
                shop = e3[0]
            }))
            .Join(d, be1 => be1.shop + be1.item, d1 => d1[1] + d1[2], (be2, d2) => new {
                country = be2.country,
                item = be2.item,
                man = be2.man,
                shop = be2.shop,
                price = d2[0]
            })
            ;

            var res = bed.GroupJoin(c, bed1 => bed1.shop + bed1.man, c1 => c1[1] + c1[2], (bed2, c2) => new {
                country = bed2.country,
                item = bed2.item,
                man = bed2.man,
                shop = bed2.shop,
                price = bed2.price,
                dis = c2.Select(a => a[0]).DefaultIfEmpty("0").First()
            })
            .GroupBy(e => e.man + e.country, (k, nn) => new {
                nD = nn.Where(a => (Convert.ToInt32(a.dis)) == 0).Select(a => (Convert.ToInt32(a.price))).Sum(),
                yD = nn.Where(a => (Convert.ToInt32(a.dis)) > 0).Select(a => Convert.ToInt32(a.price) - Convert.ToInt32(a.price) * Convert.ToInt32(a.dis) / 100 ).Sum(),
                man = nn.Select(a => a.man).First(),
                country = nn.Select(a => a.country).First()
            })
            .OrderBy(a => a.country)
            .ThenBy(a => a.man)
            .Select(a => a.country + " " + a.man + " " + (a.nD + a.yD))
            .Show();

            File.WriteAllLines(GetString(), res.ToArray(), Encoding.Default);

        }
    }
}
