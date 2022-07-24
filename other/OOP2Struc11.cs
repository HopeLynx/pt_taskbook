// File: "OOP2Struc11"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Flyweight
        {
            public abstract char Operation(bool state);
        }

        public class ConcreteFlyweight: Flyweight {
            public override char Operation(bool state) {
                if(state == true)
                    return 'A';
                return 'a';
            }
        }

        public class UnsharedConcreteFlyweight: Flyweight {
            char inf;
            public UnsharedConcreteFlyweight(char inf) {
                this.inf = inf;
            }
            public override char Operation(bool state) {
                if(state == true)
                    return Char.ToUpper(inf);
                return Char.ToLower(inf);
            }
        }

        public class FlyweightFactory {
            ConcreteFlyweight cf = null;
            int count;
            public Flyweight GetFlyweight(char inf) {
                if(inf == 'A' || inf == 'a') {
                    if(cf == null) {
                        cf = new ConcreteFlyweight();
                        count += 1;
                        return cf;
                    }
                    else
                        return cf;
                }
                else {
                    count += 1;
                    return new UnsharedConcreteFlyweight(inf);
                }
            }

            public int GetCount() {
                return count;
            }
        }

        public class Client {
            FlyweightFactory f = new FlyweightFactory();
            List<Flyweight> fw = new List<Flyweight>();
            public void MakeFlyweights(string inf) {
                fw = new List<Flyweight>();
                for(int i = 0; i < inf.Length; ++i) {
                    fw.Add(f.GetFlyweight(inf[i]));
                }
            }
            public string ShowFlyweights(Boolean state) {
                string res = "";
                for(int i = 0; i < fw.Count; ++i) {
                    res += fw[i].Operation(state);
                }
                return res;
            }
            public int GetFlyweightCount() {
                return f.GetCount();
            }

        }

        // Implement the ConcreteFlyweight
        //   and UnsharedConcreteFlyweight descendant classes

        // Implement the FlyweightFactory and Client classes

        public static void Solve()
        {
            Task("OOP2Struc11");

            int n = 5;
            Client cl = new Client();

            for (int i = 0; i < n; ++i) {
                string str = GetString();
                cl.MakeFlyweights(str);
                Put(cl.ShowFlyweights(true));
                Put(cl.ShowFlyweights(false));
                Put(cl.GetFlyweightCount());
            }

        }
    }
}
