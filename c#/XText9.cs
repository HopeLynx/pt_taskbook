// File: "XText9"
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
            Task("XText9");
            int k = GetInt();
            string inp = GetString();
            string out1 = "lul.tmp";
            //BinaryReader binReader = new BinaryReader(File.Open(inp, FileMode.Open));
            //BinaryWriter binWriter1 = new BinaryWriter(File.Open(out1, FileMode.Create));

            //FileStream writer = File.Create(out1);
            var wr = File.Create(out1);
            wr.Close();
                using (var writer = new StreamWriter(out1)){
                    var lineCount = 0;
                    using (var reader = new StreamReader(inp)){
                        string line;
                        while ((line = reader.ReadLine()) != null){
                            lineCount++;
                            if (lineCount == k) writer.WriteLine("");
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
