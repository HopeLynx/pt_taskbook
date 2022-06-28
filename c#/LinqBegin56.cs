// File: "LinqBegin56"
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
            Task("LinqBegin56");
            GetSeqInt().OrderBy(e => Math.Abs(e % 10))
            .GroupBy(e => Math.Abs(e % 10),(k,ee) => k + ":" + ee.Sum(s => s))
            .Put();
        }
    }
}
