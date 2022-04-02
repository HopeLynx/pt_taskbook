// File: "XString45"
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
            Task("XString45");
            var s =GetString();
            string[] tmp = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int ans = tmp[0].Length;
            for (int i = 1 ; i< tmp.Length; i++){
                if (ans > tmp[i].Length) ans = tmp[i].Length;
            }
            Put(ans);
        }
    }
}
