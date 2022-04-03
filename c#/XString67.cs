// File: "XString67"
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
            Task("XString67");
                        var s =GetString();
            string ans="";
            int kek = s.Length/2;
            var builder = new StringBuilder();
            for (int i=0;i<kek;i++){
                builder.Append(s[s.Length-1]);
                builder.Append(s[0]);
                s = s.Remove(s.Length-1,1);
                s = s.Remove(0,1);
                ShowLine(builder.ToString());
            }
            
            if (s.Length == 2) {
                builder.Append(s[s.Length-1]);
                builder.Append(s[0]);
            }
            else if (s.Length == 1) builder.Append(s[0]);
            ans = builder.ToString();

            Put(ans);


        }
    }
}
