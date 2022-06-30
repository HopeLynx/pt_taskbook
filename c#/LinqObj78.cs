// File: "LinqObj78"
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
            Task("LinqObj78");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        cost = int.Parse(s[0]),
                        art = s[1],
                        shop = s[2]
                    };
                }).ToList().Show();

            var l = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        code = int.Parse(s[0]),
                        shop = s[1],
                        art = s[2]
                    };
                }).ToList().Show();

            var smth = (
                from t1 in r
                join t2 in l on
                new {art = t1.art,shop = t1.shop} equals new {art = t2.art,shop=t2.shop}
                select new {art = t1.art, customer = t2.code, shop = t2.shop,cost = t1.cost}
            ).ToList().Show();

            var mb_ans = (
                from p in smth
                group p by p.art into g
                select new { art = g.Key, sold = g.Select(e => e.customer).Count(),price = g.Select(e => e.cost).Max()}
            ).OrderBy(e => e.sold).ThenBy(e=>e.art).Select(e=> e.sold+" "+e.art+" "+e.price)
            .ToList().Show();


            //if (mb_ans.Count() == 0) File.WriteAllLines(GetString(),new []{"Required students not found"}, Encoding.Default);
            //else
            File.WriteAllLines(GetString(),mb_ans, Encoding.Default);
        }
    }
}
