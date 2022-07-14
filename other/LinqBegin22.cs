// File: "LinqBegin22"
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
            Task("LinqBegin22");
            int k = GetInt();
            GetSeqString().Where(x => x.Length == k && Char.IsDigit(x,x.Length - 1))
            .Show()
            .OrderBy(x => x)
            .Put();
        }
    }
}
