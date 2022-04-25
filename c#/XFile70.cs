// File: "XFile70"
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
            Task("XFile70");
            string inp = GetString();
            string out1 = GetString();
            var lenl = new FileInfo(inp).Length;
            lenl /= 81;
            int len = unchecked((int)lenl);
            BinaryReader binReader = new BinaryReader(File.Open(inp, FileMode.Open));
            BinaryWriter binWriter1 = new BinaryWriter(File.Open(out1, FileMode.Create));
            Show(len);
            string[] arr = new string[len];
            int ind = 0;
            for (int i = 0; i< len; i++){
                string value = binReader.ReadString();
                if((value[3] == '1' && value[4] == '2')
                || (value[3]=='0' && 
                (value[4]=='1' || value[4] == '2'))){
                arr[ind] = value;ind++;
                }
            }
            if (ind > 0){
            for(int i=ind-1;i>=0;i--) {
                ShowLine(arr[i]);
                binWriter1.Write(arr[i]);
            }
            }
            binReader.Close();
            binWriter1.Close();
        }
    }
}
