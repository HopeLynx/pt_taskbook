// File: "LinqObj28"
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

        static int Entrance(int num){return (num - 1) / 36 + 1;}
        static int Floor(int num){return (num - 1) % 36 / 4 + 1;}
        public static void Solve()
        {
            Task("LinqObj28");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        size = Convert.ToDouble(s[0].Replace('.',',')),
                        surname = (s[1]),
                        code = int.Parse(s[2])
                    };
                }).ToList();

            var mb_ans = (
                from p in r
                group p by p.code into g
                select new { code = g.Key, people = g.Select(pc => pc.surname).Count(), debt = g.Sum(pc => pc.size), floor = Floor(g.Key)}
            ).OrderBy(e => e.code)
            .ToList().Show();
            IEnumerable<int> floors = new List<int>(){1,2,3,4,5,6,7,8,9};

            var ans = (
                from p in mb_ans
                group p by p.floor into g
                select new {floor = g.Key, debt = g.Sum(pc => pc.debt), people = g.Select(pc => pc.people).Sum()}
            ).OrderByDescending(e => e.floor).ToList();

            var hope = (
                from f in floors
                join a in ans on f equals a.floor into g
                select new {floor = f, debt = g.Select(pc => pc.debt).DefaultIfEmpty(0).Sum(), people = g.Select(pc => pc.people).DefaultIfEmpty(0).Sum()}
            ).OrderByDescending(e => e.floor).Select(e => e.floor+" "+e.debt+".00 "+e.people).Show();


            File.WriteAllLines(GetString(),hope , Encoding.Default);
        }
    }
}
