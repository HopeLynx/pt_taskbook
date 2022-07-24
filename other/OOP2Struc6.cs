// File: "OOP2Struc6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Device
        {
            public virtual void Add(Device d) {}
            public abstract string GetName();
            public abstract int GetTotalPrice();
        }

        public class CompoundDevice: Device {
            string name;
            int price;

            List<Device> devs = new List<Device>();
            public CompoundDevice(string name, int price) {
                this.name = name;
                this.price = price;
            }

            public override void Add(Device d) {
                devs.Add(d);
            }

            public override string GetName() {
                return name;
            }

            public override int GetTotalPrice() {
                int res = 0;
                for (int i = 0; i < devs.Count; ++i) {
                    res += devs[i].GetTotalPrice();
                }
                return price + res;
            }
        }

        public class SimpleDevice: Device {
            string name;
            int price;
            public SimpleDevice(string name, int price) {
                this.name = name;
                this.price = price;
            }

            public override void Add(Device d) {}

            public override string GetName() {
                return name;
            }

            public override int GetTotalPrice() {
                return price;
            }
        }

        // Implement the SimpleDevice
        //   and CompoundDevice descendant classes

        public static void Solve()
        {
            Task("OOP2Struc6");

            int n = GetInt();
            Device[] devA = new Device[n];

            for (int i = 0; i < n; ++i) {
                string name = GetString();
                int price = GetInt();

                if(name[0] == name.ToUpper()[0])
                    devA[i] = new CompoundDevice(name, price);
                else 
                    devA[i] = new SimpleDevice(name, price);
            }

            for(int i = 0; i < n; ++i) {
                int j = GetInt();
                if(j >= 0)
                    devA[j].Add(devA[i]);
            }

            for(int i = 0; i < n; ++i) {
                Put(devA[i].GetName());
                Put(devA[i].GetTotalPrice());
            }

        }
    }
}
