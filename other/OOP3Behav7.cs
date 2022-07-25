// File: "OOP3Behav7"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        public class ConcreteAggregateA: Aggregate {
            int data;
            public ConcreteAggregateA(int data) {
                this.data = data;
            }
            public override Iterator CreateIterator() {
                return new ConcreteIteratorA(this);
            }
            public int GetData() {
                return data;
            }
        }

        public class ConcreteAggregateB: Aggregate {
            string data = "";
            public ConcreteAggregateB(string data) {
                this.data = data;
            }
            public override Iterator CreateIterator() {
                return new ConcreteIteratorB(this);
            }
            public string GetData() {
                return data;
            }
        }

        public class ConcreteAggregateC: Aggregate {
            List<int> data = new List<int>();
            public ConcreteAggregateC(List<int> data) {
                this.data = data;
            }
            public override Iterator CreateIterator() {
                return new ConcreteIteratorC(this);
            }
            public List<int> GetData() {
                return data;
            }
        }

        // Implement the ConcreteAggregateA, ConcreteAggregateB
        //   and ConcreteAggregateC descendant classes

        public abstract class Iterator
        {
            public abstract void First();
            public abstract void Next();
            public abstract bool IsDone();
            public abstract int CurrentItem();
        }

        public class ConcreteIteratorA: Iterator{
            ConcreteAggregateA aggr;
            string dataStr = "";
            int it = 0;
            public ConcreteIteratorA(ConcreteAggregateA aggr) {
                this.aggr = aggr;
                var temp = aggr.GetData().ToString().ToCharArray();
                Array.Reverse(temp);
                dataStr = new string(temp);
            }
            public override void First() {
                if(dataStr.Length == 0) {
                    it = -1;
                }
                else
                    it = 0;
            }
            public override void Next() {
                if(it == -1) {}
                else if(it == dataStr.Length - 1 || (dataStr.Contains('-') && it == dataStr.Length - 2)){
                    it = -1;
                }
                else 
                    it += 1;
            }
            public override bool IsDone() {
                if (it == -1)
                    return true;
                else
                    return false;
            }
            public override int CurrentItem() {
                if(it == -1)
                    return -1;
                else {
                    return (int)Char.GetNumericValue(dataStr[it]);
                }
            }
        }

        public class ConcreteIteratorB: Iterator{
            ConcreteAggregateB aggr;
            string dataStr = "";
            int it = 0;
            public ConcreteIteratorB(ConcreteAggregateB aggr) {
                this.aggr = aggr;
                var temp = aggr.GetData().ToCharArray();
                Array.Reverse(temp);
                dataStr = new string(temp);
            }
            public override void First() {
                if(dataStr.Length == 0) {
                    it = -1;
                }
                else {
                    for(int i = 0; i < dataStr.Length; ++i) {
                        if(Char.IsDigit(dataStr[i])) {
                            it = i;
                            break;
                        }
                    }
                }
            }
            public override void Next() {
                if(it + 1 < dataStr.Length && it != - 1) {
                    for(int i = it + 1; i < dataStr.Length; ++i) {
                        if(Char.IsDigit(dataStr[i])) {
                            it = i;
                            break;
                        }
                        if(i == dataStr.Length - 1)
                            it = -1;
                    }
                }
                else 
                    it = -1;
            }
            public override bool IsDone() {
                if (it == -1)
                    return true;
                else
                    return false;
            }
            public override int CurrentItem() {
                if(it == -1)
                    return -1;
                else {
                    return (int)Char.GetNumericValue(dataStr[it]);
                }
            }
        }

        public class ConcreteIteratorC: Iterator{
            ConcreteAggregateC aggr;
            string dataStr = "";
            int it;
            public ConcreteIteratorC(ConcreteAggregateC aggr) {
                this.aggr = aggr;
                var temp = aggr.GetData();
                for (int i = temp.Count - 1; i >= 0; --i) {
                    var str = temp[i].ToString().ToCharArray();
                    Array.Reverse(str);
                    var del = new string(str);
                    var a = del.Trim('-');
                    dataStr += a;
                }
            }
            public override void First() {
                if(dataStr.Length == 0) {
                    it = -1;
                }
                else
                    it = 0;
            }
            public override void Next() {
                if(it == -1) {}
                else if(it < dataStr.Length - 1) {
                    it += 1;
                }
                else 
                    it = -1;
            }
            public override bool IsDone() {
                if (it == -1)
                    return true;
                else
                    return false;
            }
            public override int CurrentItem() {
                if(it == -1)
                    return -1;
                else
                    return (int)Char.GetNumericValue(dataStr[it]);
            }
        }

        // Implement the ConcreteIteratorA, ConcreteIteratorB
        //   and ConcreteIteratorC descendant classes

        public static void Solve()
        {
            Task("OOP3Behav7");

            int n = GetInt();
            List<Aggregate> res = new List<Aggregate>();

            for (int i = 0; i < n; ++i) {
                var c = GetChar();
                if(c == 'A'){
                    var data = GetInt();
                    res.Add(new ConcreteAggregateA(data));
                }
                if(c == 'B') {
                    var data = GetString();
                    res.Add(new ConcreteAggregateB(data));
                }
                if(c == 'C') {
                    var data = GetInt();
                    List<int> ls = new List<int>();
                    for(int j = 0; j < data; ++j) {
                        ls.Add(GetInt());
                    }
                    var temp = new ConcreteAggregateC(ls);
                    res.Add(temp);
                }
            }

            for(int i = res.Count - 1; i >= 0; --i) {
                var it = res[i].CreateIterator();
                var sum = 0;
                List<int> cls = new List<int>();
                for (it.First(); !it.IsDone(); it.Next()) {
                    var temp = it.CurrentItem();
                    sum += temp;
                    cls.Add(temp);
                }
                if (sum == -1) {
                    Put(0);
                }
                else 
                    Put(sum);
                for(int j = 0; j < cls.Count; ++j) {
                    if(cls[j] == -1) {
                    }
                    else
                        Put(cls[j]);
                }
            }
        }
    }
}
