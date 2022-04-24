// File: "XText50"
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
            Task("XText50");

            string inp = GetString();
            string out1 = GetString();
            string out2 = GetString();
            /*
            var wr = File.Create(out1);
            wr.Close();
            wr = File.Create(out2);
            wr.Close();
*/
            var stream1 = File.Open(out1, FileMode.Create);
            var stream2 = File.Open(out2, FileMode.Create);

            using (var writer1 = new BinaryWriter(stream1,Encoding.UTF8, false)){
                using (var writer2 = new BinaryWriter(stream2,Encoding.UTF8, false)){
                    //var lineCount = 0;
                    using (var reader = new StreamReader(inp)){
                        string line;
                        while ((line = reader.ReadLine()) != null){
                            //lineCount++;
                            string [] s = line.Split('|');
                            if (s.Length == 2){

                                
                                s[0] = s[0]+"|\n";
                                for(int i=(s[0].Length);i<80;i++){
                                    s[0] = s[0]+ " ";
                                }
                                Show(s[0].Length);
                                writer1.Write(s[0]);
                                
                                double tmp = double.Parse(s[1],CultureInfo.InvariantCulture);
                                Show(tmp);
                                writer2.Write(tmp);
                            }
                            
                        }
                    }
                }
            }
            stream1.Close();
            stream2.Close();
        }
    }
}
