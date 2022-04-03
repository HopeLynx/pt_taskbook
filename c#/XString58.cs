// File: "XString58"
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
            Task("XString58");
            var s =GetString();
            string[] tmp = s.Split('\\',StringSplitOptions.RemoveEmptyEntries);
            string ans = tmp[tmp.Length-1];
            tmp = ans.Split('.');
            Put(tmp[0]);
        }
    }
}
