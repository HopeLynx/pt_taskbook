// File: "LinqBegin21"
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
            Task("LinqBegin21");
            var data = GetSeqString();
            IEnumerable<string> res = Enumerable.Select(data, s=>s).OrderBy(s => s.Length).ThenByDescending(s => s);
            Show(res);
            res.Put();
            //GetArrString().
            //foreach (var s in res) Put(s);
        
        }
    }
}
