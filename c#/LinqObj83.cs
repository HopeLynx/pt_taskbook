// File: "LinqObj83"
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
            Task("LinqObj83");



            var f = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        cat = s[0],
                        art = s[1],
                        country = s[2]
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
                        shop = s[1],
                        art = s[2]
                    };
                }).ToList()//.Show()
                ;

            var l = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        shop = s[0],
                        code = int.Parse(s[1]),
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
                select new {art = t2.art, customer = t1.customer,cost = t1.cost, country = t2.country, shop = t1.shop /*grb = t1.shop+" "+t2.country*/}
            ).ToList()//.Show()
            ;

            var ans = 
                from p in smth2
                orderby p.shop,p.country
                group p by new { p.shop, p.country} into g
                select new {shop =g.Key.shop,country = g.Key.country,price = g.Select(e=>e.cost).Sum()};
                /*foreach(var shop_cnt_gr in ans){
                    Show(shop_cnt_gr.Key + " ");
                    var tmp = 0;
                    foreach (var m in shop_cnt_gr){
                        tmp+= m.cost;
                    }
                    Show(tmp);
                }*/

            var shops = l.GroupBy(e=>e.shop,(k,ee)=>k);
            var countries = f.GroupBy(e=>e.country,(k,ee)=>k);
            var shops_cnt = shops.SelectMany(e1 => countries.Select(e2 => e1 + " " + e2)).OrderBy(e=>e);
            
            var k = shops_cnt.GroupJoin(ans,e1=>e1,e2=>e2.shop+" "+e2.country,(e1,ee2)=>e1+" "+ee2.Select(e=>e.price).DefaultIfEmpty(0).Sum()).ToList().Show();
/*
            var mb_ans = (
                from p in smth2
                group p by p.grb into g
                select new { grb = g.Key, price = g.Select(e => e.cost).DefaultIfEmpty(0).Sum()}
            ).OrderBy(e => e.grb).ThenBy(e=>e.price).Select(e=> e.grb+" "+e.price)
            .ToList().Show();
/*
            var mb_ans2 = (
                from p in mb_ans
                group p by p.stores into g
                select new {store = g.Key, country = g.Select(e=> e.country),sold = g.Select(e=>e.price.Sum()) }
            ).ToList().Show();
*/
            File.WriteAllLines(GetString(),k, Encoding.Default);
        }
    }
}
