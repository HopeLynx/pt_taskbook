// File: "XText34"
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
            Task("XText34");

            string inp = GetString();
            string out1 = "lul.tmp";
            
            var wr = File.Create(out1);
            wr.Close();

            using (var writer = new StreamWriter(out1)){
                var lineCount = 0;
                using (var reader = new StreamReader(inp)){
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        lineCount++;
                        if (line.Length != 0)
                        for (int i =0; i < 50 - line.Length; i++)
                        writer.Write(' ');
                        writer.WriteLine(line);
                    }
                }
            }
            

            //reader.Close();
            //writer.Close();
            File.Delete(inp);
            System.IO.File.Move(out1, inp);
        }
    }
}
