// File: "LinqBegin23"
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
            Task("LinqBegin23");
            int k = GetInt();
            GetSeqInt().Skip(k- 1)
            .Where(x => x % 2 != 0 && x / 100 == 0 && Math.Abs(x) >= 10)
            .Show()
            .OrderByDescending(x => x)
            .Put();
        }
    }
}
