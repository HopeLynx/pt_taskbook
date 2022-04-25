// File: "XFile11"
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
            Task("XFile11");
            string inp = GetString();
            string out1 = GetString();
            string out2 = GetString();

            var len = new FileInfo(inp).Length;
            len /= 8;
            BinaryReader binReader = new BinaryReader(File.Open(inp, FileMode.Open));
            BinaryWriter binWriter1 = new BinaryWriter(File.Open(out1, FileMode.Create));
            BinaryWriter binWriter2 = new BinaryWriter(File.Open(out2, FileMode.Create));
            for (int i = 0; i< len; i++){
                double value = binReader.ReadDouble(); 
                Show(value);

                if (i % 2 == 0) {
                    binWriter1.Write(value);
                } else {
                    binWriter2.Write(value);
                }
            }
            binReader.Close();
            binWriter1.Close();
            binWriter2.Close();
        }
    }
}