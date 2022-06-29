// File: "LinqObj45"
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
            Task("LinqObj45");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        name = s[0],
                        price = int.Parse(s[1]),
                        code = int.Parse(s[2]),
                        addr = s[3]
                    };
                }).ToList();

            var mb_ans = (
                from p in r
                group p by p.addr into g
                select new { addr = g.Key, num = g.Select(e => e.name).Distinct().Count()}
            ).OrderBy(e => e.addr).Select(e => e.addr+" "+e.num).ToList().Show();


            File.WriteAllLines(GetString(),mb_ans , Encoding.Default);
        }
    }
}
