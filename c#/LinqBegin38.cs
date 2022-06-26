// File: "LinqBegin38"
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
            Task("LinqBegin38");
            /*var a = */GetSeqInt().Where((c,i) => (i+1) % 3 != 0).Select((c,i) => c *((i+1) % 2 == 0 ? 1 : 2 )).Put();

            //a.Where((c,i) => i % 3 == 0).Select(x => 2*x)
            //.Concat(a.Where((c,i) => i % 3 == 1).Select(x => x))
            //.Put();
        }
    }
}
