// File: "XText56"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XText56");

            string inp = GetString();
            string out1 = GetString();

            var stream1 = File.Open(out1, FileMode.Create);

            using (var writer1 = new BinaryWriter(stream1,Encoding.UTF8, false)){
                    using (var reader = new StreamReader(inp)){
                        string line;
                        int [] arr = new int[256];
                        while ((line = reader.ReadLine()) != null){
                            char[] characters = line.ToCharArray();
                            foreach(char ch in characters){
                                if (ch != '\n' && ch != '\r') arr[ch]++;
                            }
                        }
                        for (int i=255;i > 0;i--){
                            if (arr[i] != 0) writer1.Write((char)(i));
                        }
                    }
            }
            stream1.Close();
        }
    }
}
