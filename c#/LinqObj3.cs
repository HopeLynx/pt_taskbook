// File: "LinqObj3"
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
        // To read strings from the source text file into
        // a string sequence (or array) s, use the statement:
        //   s = File.ReadLines(GetString());
        // To write the sequence s of IEnumerable<string> type
        // into the resulting text file, use the statement:
        //   File.WriteAllLines(GetString(), s);
        // When solving tasks of the LinqObj group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqObj3");
            var r = File.ReadLines(GetString(), Encoding.Default)
                .Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new
                    {
                        year = int.Parse(s[0]),
                        month = int.Parse(s[1]),
                        hours = int.Parse(s[2]),
                        code = int.Parse(s[3])
                    };
                }).ToList();
            var ans = (
                from p in r
                group p by p.year into g
                select new { Year = g.Key, Hours = g.Sum(pc => pc.hours)}
            ).OrderByDescending(e => e.Hours).ThenBy(e => e.Year).ToList().Show();
            var s = ans.Select(e => e.Year+" "+e.Hours).First().ToString();
            Show(s);
            File.WriteAllText(GetString(), s , Encoding.Default);
            
        }
    }
}
