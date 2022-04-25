// File: "XFile36"
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
            Task("XFile36");
            string inp = GetString();
            string out1 = "test.tmp"; 
            var len = new FileInfo(inp).Length;
            len /= 4;
            BinaryReader binReader = new BinaryReader(File.Open(inp, FileMode.Open));
            BinaryWriter binWriter1 = new BinaryWriter(File.Open(out1, FileMode.Create));
            
            for (int i = 0; i< len; i++){
                int value = binReader.ReadInt32(); 
                Show(value);
                binWriter1.Write(value);
            }
            binReader.Close();
            binReader = new BinaryReader(File.Open(inp, FileMode.Open));
            for (int i = 0; i< len; i++){
                int value = binReader.ReadInt32(); 
                binWriter1.Write(value);
            }
            binReader.Close();
            binWriter1.Close();
            File.Delete(inp);
            System.IO.File.Move(out1, inp);
        }
    }
}
