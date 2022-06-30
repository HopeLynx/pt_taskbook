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
            var f = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        country = s[2],
                        art = s[1],
                        cat = s[0]
                    };
                }).ToList()//.Show()
                ;

            var s = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        discount = int.Parse(s[0]),
                        shop = s[1],
                        code = int.Parse(s[2])
                    };
                }).ToList()//.Show()
                ;

            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        cost = int.Parse(s[0]),
                        art = s[2],
                        shop = s[1]
                    };
                }).ToList()//.Show()
                ;

            var l = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        code = int.Parse(s[1]),
                        shop = s[0],
                        art = s[2]
                    };
                }).ToList()//.Show()
                ;

            var smth = (
                from t1 in r
                join t2 in l on
                new {art = t1.art,shop = t1.shop} equals new {art = t2.art,shop=t2.shop}
                select new {art = t1.art, customer = t2.code, shop = t2.shop,cost = t1.cost}
            ).ToList()//.Show()
            ;

            var smth2 = (
                from t1 in smth
                join t2 in f on
                new {art = t1.art} equals new {art = t2.art} 
                select new {art = t2.art, customer = t1.customer,cost = t1.cost,
                            country = t2.country, shop = t1.shop }
            ).ToList()//.Show()
            ;


            var res = smth2.GroupJoin(s, bed1 => bed1.shop + bed1.customer, c1 => c1.shop + c1.code, (bed2, c2) => new {
                country = bed2.country,art = bed2.art,code = bed2.customer,shop = bed2.shop,
                price = bed2.cost,dis = c2.Select(e=>e.discount).DefaultIfEmpty(0).First()
            })
            .GroupBy(e => e.code + e.country, (k, nn) => new {
                nD = nn.Where(a => a.dis == 0).Select(a => a.price).Sum(),
                yD = nn.Where(a => a.dis > 0).Select(a => a.price - a.price * a.dis / 100 ).Sum(),
                code = nn.Select(a => a.code).First(),
                country = nn.Select(a => a.country).First()
            })
            .OrderBy(a => a.country).ThenBy(a => a.code)
            .Select(a => a.country + " " + a.code + " " + (a.nD + a.yD)).ToList().Show();

            File.WriteAllLines(GetString(),res, Encoding.Default);
        }
    }
}
