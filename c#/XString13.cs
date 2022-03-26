// File: "XString13"
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
            Task("XString13");
            string s = GetString();
            string onlydigit = new string(s.Where(char.IsDigit).ToArray());
            ShowLine(s);
            ShowLine(onlydigit);
            Show(onlydigit.Length);
            Put(onlydigit.Length);
        }
    }
}

