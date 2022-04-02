// File: "XString23"
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
            Task("XString23");
            string s = GetString();
            int ans = s[0]-'0';
            for (int i =1; i< s.Length-1; i+=2){
                Show(ans);
                if (s[i] == '+') ans += s[i+1]-'0';
                if (s[i] == '-') ans -= s[i+1]-'0';
                if (s[i] == '/') ans /= s[i+1]-'0';
                if (s[i] == '*') ans *= s[i+1]-'0'; 
                
            }
            Put(ans);
        }
    }
}
