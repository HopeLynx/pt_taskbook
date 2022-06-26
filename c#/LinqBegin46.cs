// File: "LinqBegin46"
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
            Task("LinqBegin46");
            var A = GetSeqInt();
            var B = GetSeqInt();
            A.Join(B, a => a % 10, b => b % 10, (a,b) => a+"-"+b).Put();
        }
    }
}
