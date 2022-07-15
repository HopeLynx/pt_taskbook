// File: "LinqBegin55"
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
            Task("LinqBegin55");
            var A = GetSeqInt().OrderByDescending(e => e);
            var B = GetSeqInt().OrderBy(e =>e);

            A.GroupJoin(B,e1 => e1 % 10, e2 => e2 % 10,(e1,ee2) => ee2.DefaultIfEmpty().Select(e => e1 + ":" + e)).
            SelectMany(e => e).Show()
            .Put();
        }
    }
}
