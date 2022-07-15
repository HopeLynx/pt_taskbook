// File: "LinqBegin52"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqBegin52");
            var a = GetSeqString().Where(e => char.IsDigit(e.Last()));
            var b = GetSeqString().Where(e => char.IsDigit(e.Last()));
            /*a.SelectMany(e1 => b.Select(e2 => e1 + "=" + e2))
            .OrderBy(e => e.Split('=')[0])
            .ThenByDescending(e => e.Split('=')[1])
            .Put();*/
            (from e1 in a
            where char.IsDigit(e1.Last()) 
            from e2 in b 
            where char.IsDigit(e2.Last())
            orderby e1, e2 descending 
            select e1 + "=" + e2).Put();
        }
    }
}
