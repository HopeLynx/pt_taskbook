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
            public abstract char Show(bool state);
        }

    public class ConcreteFlyweight: Flyweight {
        public override char Show(bool st) {
            if(st == true) return 'A';
            return 'a';
        }
    }

    public class UnsharedConcreteFlyweight: Flyweight {
        char inf;
        public UnsharedConcreteFlyweight(char inf) {this.inf = inf;}
        public override char Show(bool state) {
            if(state == true) return Char.ToUpper(inf);
            return Char.ToLower(inf);
        }
    }

    public class FlyweightFactory {
        ConcreteFlyweight cf = null; int cnt = 0;
        public Flyweight GetFlyweight(char inf) {
            if(inf == 'A' || inf == 'a') {
                if(cf == null) {
                    cf = new ConcreteFlyweight();cnt += 1;return cf;
                } else return cf;
            } else { cnt += 1;return new UnsharedConcreteFlyweight(inf);}
        }
        public int GetCount() {return cnt;}
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
            public string ShowFlyweights(Boolean st) {
                string res = "";
                for(int i = 0; i < fw.Count; ++i) {
                    res += fw[i].Show(st);
                }
                return res;
            }
            public int GetFlyweightCount() {return f.GetCount();}
        }

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
