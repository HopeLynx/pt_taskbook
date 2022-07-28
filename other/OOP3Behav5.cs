// File: "OOP3Behav5"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractClass
        {
            public abstract string PrimitiveOperation();
            public string TemplateMethod() {
                return BasicOperation1() + PrimitiveOperation() + BasicOperation2() + this.HookOperation();
            }
            public string BasicOperation1() {
                return "Boil water";
            }
            public string BasicOperation2() {
                return "=Pour into a cup";
            }
            protected virtual string HookOperation() {
                return "";
            }
            // Implement the TemplateMethod, BasicOperation1,
            //   BasicOperation2 and HookOperation methods
        }

        public class ConcreteClass1: AbstractClass {
            public override string PrimitiveOperation() {
                return "=Brew tea";
            }
        }
        public class ConcreteClass2: AbstractClass {
            public override string PrimitiveOperation() {
                return "=Brew coffee";
            }
        }
        public class ConcreteClass3: ConcreteClass1 {
            protected override string HookOperation() {
                return "=Add sugar and lemon";
            }
        }
        public class ConcreteClass4: ConcreteClass2 {
            protected override string HookOperation() {
                return "=Add sugar and milk";
            } 
        }
        // Implement the ConcreteClass1, ConcreteClass2, ConcreteClass3
        //   and ConcreteClass4 descendant classes

        public static void Solve()
        {
            Task("OOP3Behav5");

            int n = GetInt();
            
            AbstractClass[] arr = new AbstractClass[10];
            for(int i = 0; i < n; ++i) {
                int ind = GetInt();
                if (ind == 1)
                    arr[i] = new ConcreteClass1();
                if (ind == 2)
                    arr[i] = new ConcreteClass2();
                if (ind == 3)
                    arr[i] = new ConcreteClass3();
                if (ind == 4)
                    arr[i] = new ConcreteClass4();
            }



            for(int i = n - 1; i >= 0; --i) {
                Put(arr[i].TemplateMethod());
            }
        }
    }
}
