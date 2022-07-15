// File: "LinqBegin49"
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
            Task("LinqBegin49");
            var A = GetSeqString();
            var B = GetSeqString().OrderBy(e => e);
            var C = GetSeqString().OrderByDescending(e => e);
            A.Join(B,e => e.First(),e => e.First(),(e1,e2) => e1 + "=" + e2).Join(C,e => e.First(),e => e.First(),(e1,e2) => e1 + "=" + e2).Put();

        }
    }
}
