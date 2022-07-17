// File: "LinqObj32"
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
        static int Entrance(int num)
        {
            return (num - 1) / 36 + 1;
        }
        static int Floor(int num)
        {
            return (num - 1) % 36 / 4 + 1;
        }
        public static void Solve()
        {
            Task("LinqObj32");
            /*var res = File.ReadLines(GetString())
            .OrderBy(e => Convert.ToDouble(e.Split()[2].Replace('.',',')))
            .GroupBy(e => Floor(int.Parse(e.Split()[1])),(k,ee) => new {k, i = ee.First().Split()[2]}).OrderBy(e => e.k).Select(e => e.k + " " + e.i)
            .Show();*/
            IEnumerable<string> s = new List<string> {"1 0.0","2 0.0","3 0.0","4 0.0","5 0.0","6 0.0","7 0.0","8 0.0","9 0.0"};
            s.Show();
            var res = File.ReadLines(GetString()).Select(e => new 
            {
                surname = e.Split()[0],
                flat = int.Parse(e.Split()[1]),
                duty = Convert.ToDouble(e.Split()[2].Replace('.',','))
            }).GroupBy(e => Floor(e.flat), (k,ee) => new
            {
                floor = k,
                min = ee.Min(e => e.duty)
            }) .OrderBy(e => e.floor).Select(e => e.floor + " " + e.min).Show();
            var res2 = res.GroupJoin(s,ee => ee.floor,e => e[0],(e,ee) => e).Show();
            //Convert.ToString(Convert.ToDouble(a) + Convert.ToDouble(e)))).Show();

            // File.WriteAllLines(GetString(), res1);
        }
    }
}
