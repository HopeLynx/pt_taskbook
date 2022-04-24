// File: "XText45"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
//using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XText45");
            string inp = GetString();
            using (var reader = new StreamReader(inp)){
                    string line;
                    int cnt = 0;
                    double sum = 0;
                    while ((line = reader.ReadLine()) != null){
                        //line = Regex.Replace(line, @"\s+", "");
                        line = line.Replace("\n","");
                        line = line.Trim();
                        double tmp = double.Parse(line,CultureInfo.InvariantCulture);
                        Show(tmp);

                        var x = Math.Abs(tmp) - Math.Abs(Math.Truncate(tmp));
                        if (x != 0) {cnt++;sum += tmp;}
                        //Show(Convert.ToDouble(line.Trim()));
                    }
                    Put(cnt);
                    Put(sum);
                }
        }
    }
}
