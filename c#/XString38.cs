// File: "XString38"
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
            Task("XString38");
            var s =GetString();
            var s1 = GetString();
            var s2 = GetString();
            var ans = s.Replace(s1,s2);
            Put(ans);
        }
    }
}
