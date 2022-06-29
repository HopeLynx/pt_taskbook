// File: "LinqObj58"
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
            Task("LinqObj58");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        surname = s[0],
                        init = s[1],
                        code = int.Parse(s[2]),
                        marks = new int[]{int.Parse(s[3]),int.Parse(s[4]),int.Parse(s[5])}
                    };
                }).Where(e => e.marks.Min() < 50).OrderBy(e=>e.surname)/*.ThenBy(e=>e.code)*/.ToList().Show();

            var mb_ans = (
                from p in r
                group p by p.code into g
                select new { code = g.Key, students = g.OrderBy(e=>e.surname).ThenBy(e=>e.code).Take(3).Select(e => e.surname+" "+e.init)}
            ).SelectMany(e => e.students, (e,ee)=> new{ee,e.code}).OrderBy(e => e.ee).ThenBy(e=>e.code).Select(e=> e.ee+" "+e.code)
            .ToList().Show();


            if (mb_ans.Count() == 0) File.WriteAllLines(GetString(),new []{"Required students not found"}, Encoding.Default);
            else File.WriteAllLines(GetString(),mb_ans, Encoding.Default);
        }
    }
}
