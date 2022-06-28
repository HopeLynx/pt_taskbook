// File: "LinqObj17"
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
            Task("LinqObj17");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        code = int.Parse(s[0]),
                        year = int.Parse(s[1]),
                        surname = (s[2])
                    };
                }).ToList();

            var mb_ans = (
                from p in r
                group p by p.year into g
                select new { Year = g.Key, Number = g.Select(pc => pc.code).Distinct().Count()}
            ).OrderBy(e => e.Number).ThenBy(e => e.Year).Select(e => e.Number+" "+e.Year).Show();
            
            /*
            var ans = (
                from p in r
                group p by p.year into g
                select new { Year = g.Key, Hours = g.Sum(pc => pc.hours)}
            ).OrderByDescending(e => e.Hours).ThenBy(e => e.Year).ToList().Show();
            */

            //var s = mb_ans.Select(e => e.Number+" "+e.Year).ToString();
            //Show(s);
            File.WriteAllLines(GetString(), mb_ans.ToArray() , Encoding.Default);
        }
    }
}
