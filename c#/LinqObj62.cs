// File: "LinqObj62"
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
            Task("LinqObj62");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        classn = int.Parse(s[0]),
                        name = s[1]+" "+s[2],
                        mark = int.Parse(s[3]),
                        subj = s[4]
                    };
                }).ToList().Show();

            var mb_ans = (
                from p in r
                group p by p.name into g
                select new { name = g.Key, classn = g.Select(e => e.classn).First(),marks =
                g.Where(ee => ee.subj == "Algebra").Select(e=>e.mark).Count().ToString() + " "+
                g.Where(ee => ee.subj == "Geometry").Select(e=>e.mark).Count().ToString() + " "+
                g.Where(ee => ee.subj == "Physics").Select(e=>e.mark).Count().ToString()
                }
            ).OrderBy(e => e.classn).ThenBy(e=>e.name).Select(e=> e.classn+" "+e.name+" "+e.marks)
            .ToList().Show();


            //if (mb_ans.Count() == 0) File.WriteAllLines(GetString(),new []{"Required students not found"}, Encoding.Default);
            //else
            File.WriteAllLines(GetString(),mb_ans, Encoding.Default);
        }
    }
}
