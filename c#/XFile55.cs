// File: "XFile55"
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
            Task("XFile55");
            string out1 = GetString();
            int n = GetInt();
            BinaryWriter binWriter1 = new BinaryWriter(File.Open(out1, FileMode.Create));

            for(int i=0; i<n;i++){
                string inp = GetString();
                var lenl = new FileInfo(inp).Length;
                lenl /= 4;
                int len = unchecked((int)lenl);
                BinaryReader binReader = new BinaryReader(File.Open(inp, FileMode.Open));
                binWriter1.Write(len);
                for (int j = 0; j< len; j++){
                    int value = binReader.ReadInt32(); 
                    Show(value);
                    binWriter1.Write(value);
                }
                binReader.Close();
            }
            binWriter1.Close();
        }
    }
}
