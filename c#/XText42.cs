// File: "XText42"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XText42");

            double a = GetDouble();
            double b = GetDouble();
            int n = GetInt();
            string out1 = GetString();

            double h = (b-a)/(n*1.00);
            
            var wr = File.Create(out1);
            wr.Close();

            using (var writer = new StreamWriter(out1)){
                for (int j = 0;j <= n;j++){
                    double tmp = a+h*j;
                    string line = (tmp).ToString("F4",System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                    for (int i =0; i < 10 - line.Length; i++) writer.Write(' ');
                    writer.Write(line);
                    line = (Math.Sqrt(tmp)).ToString("F8",System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                    for (int i =0; i < 15 - line.Length; i++) writer.Write(' ');
                    writer.Write(line);
                    writer.Write('\n');
                }
            }
        }
    }
}