// File: "LinqBegin33"
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
            Task("LinqBegin33");
            var a = GetSeqInt();
            a.Where(x => x>0).Select(x => x % 10).Where(x => x >= 0).Distinct().Put();
        }
    }
}
