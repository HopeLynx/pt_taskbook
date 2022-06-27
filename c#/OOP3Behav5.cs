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
            // РЕАЛИЗУЙТЕ МЕТОДЫ TemplateMethod,
            // BasicOperation1, BasicOperation2 И HookOperation
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
        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ ConcreteClass1,
        //   ConcreteClass2, ConcreteClass3 И ConcreteClass4

        public static void Solve()
        {
            Task("OOP3Behav5");
			int n = GetInt();
			AbstractClass[] a = new AbstractClass[10];

            for(int i = 0; i < n; ++i) {
                int ind = GetInt();
				switch(ind){
					case 1: a[i]=new ConcreteClass1();break;
					case 2: a[i]=new ConcreteClass2();break;
					case 3: a[i]=new ConcreteClass3();break;
					case 4: a[i]=new ConcreteClass4();break;
				}
            }
            for(int i = n - 1; i >= 0; --i) Put(a[i].TemplateMethod());

        }
    }
}
