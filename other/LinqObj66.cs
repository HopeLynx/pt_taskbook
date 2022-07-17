// File: "LinqObj66"
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
            Task("LinqObj66");

            string s = GetString();
            var r = File.ReadLines(GetString(), Encoding.Default)
            .Select(e => e.Split(' '));
            // .Show()

            var temp = r
            .Where(e => e[0] == s)
            .GroupBy(e => e[1] + e[2] + e[4]
            , (k, nn) => new {
                avr = nn.Select(a => Convert.ToInt32(a[3])).Average(),
                n2 = nn.Where(e => Convert.ToInt32(e[3]) > 2).Count(),
                y2 = nn.Where(e => Convert.ToInt32(e[3]) > 1).Count(),
                n = nn.Select(a => Convert.ToInt32(a[4])).First()
            });

            var res1 = temp
            .Where(e => e.y2 == e.n2 && Convert.ToInt32(e.avr) >= 3.5)
            .GroupBy(a => a.n
            , (k, nn) => new {
                l = nn.Count(),
                n = nn.Select(a => a.n).First()
            }
            )
            // .Show()
            ;       

            var res2 = temp
            .Where(e => e.y2 != e.n2 || Convert.ToInt32(e.avr) < 3.5)
            .GroupBy(a => a.n
            , (k, nn) => new {
                l = 0,
                n = nn.Select(a => a.n).First()
            }
            )
            // .Show()
            ;

            var res = 
            res1.Concat(res2)
            .OrderByDescending(a => a.l)
            .GroupBy(a => a.n
            , (k, nn) => new {
                l = nn.First().l,
                n = nn.Select(a => a.n).First()
            }
            )
            .OrderBy(a => a.n)
            .Select(a => a.n + " " + a.l)
            ;

            // var res = r.GroupBy(e => e[1] + e[2] + e[4]
            // , (k, nn) => new {
            //     avr = nn.Select(a => Convert.ToInt32(a[3])).Average(),
            //     n = nn.Select(a => a[4]).First()
            // }
            // )
            // .GroupBy(a => a.n, (k, nn) => new {
            //     l = nn.Where(e => Convert.ToInt32(e.avr) >= 3.5).Count(),
            //     n = nn.Select(a => a.n).First()
            // })
            // .OrderBy(a => Convert.ToInt32(a.n))
            // .Show()
            // .Select(a => a.n + " " + a.l)
            // .Show()
            ;

            File.WriteAllLines(GetString(), res.ToArray(), Encoding.Default);

        }
    }
}
