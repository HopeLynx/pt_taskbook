// File: "XString30"
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
            Task("XString30");
            var z =GetChar();
            var s = GetString();
            var s0 = GetString();
            for (int i = 0; i < s.Length; i++){
                if (s[i]==z) {
                    ShowLine(s);
                    s = s.Insert(i+1, s0);
                    i+= s0.Length;
                    }
            }
            Put(s);
        }
    }
}
