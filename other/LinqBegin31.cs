// File: "LinqBegin31"
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
            Task("LinqBegin31");
            int k = GetInt();
            var a = GetSeqString();
            a.Take(k).Intersect(a.Reverse().TakeWhile(e => !char.IsDigit(e.Last()))).
            OrderBy(e => e.Length).ThenBy(e => e).Put();
        }
    }
}
