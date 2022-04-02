// File: "XString11"
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
            Task("XString11");
            string s = GetString();
            for (int i = 1; i <= s.Length-1; i ++)
                {
                    s = s.Insert(i, " ");
                    i++;
                }
            ShowLine(s);
            Put(s);
        }
    }
}
