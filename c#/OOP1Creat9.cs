// File: "OOP1Creat9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Builder
        {
            public virtual void BuildStart() {}
            public virtual void BuildPartA() {}
            public virtual void BuildPartB() {}
            public virtual void BuildPartC() {}
            public abstract string GetResult();
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ ConcreteBuilder1 И ConcreteBuilder2

        public class ConcreteBuilder1 :  Builder{
	public string product = "";
	public override void  BuildStart() {product = "";}
	public override void BuildPartA() {product += "-1-";}
    public override void BuildPartB() {product += "-2-";}
    public override void BuildPartC() {product += "-3-";}
    public override string GetResult() {return product;}
};

public class ConcreteBuilder2 : Builder{
	public string product = "";
	public override void BuildStart() {product = "";}
	public override void BuildPartA() {product += "=*=";}
    public override void BuildPartB() {product += "=**=";}
    public override void BuildPartC() {product += "=***=";}
    public override string GetResult() {return product;}
};

        public class Director
        {
            Builder b;
            public Director(Builder b)
            {
                this.b = b;
            }
            public string GetResult()
            {
                return b.GetResult();
            }
            public void Construct(string templat)
            {
                // РЕАЛИЗУЙТЕ МЕТОД
                b.BuildStart();
                for (int i=0;i<templat.Length;i++){
		            if (templat[i]=='A') b.BuildPartA();
		            else if (templat[i]=='B') b.BuildPartB();
		            else if (templat[i]=='C') b.BuildPartC();
	}
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat9");
            Director d1 = new Director(new ConcreteBuilder1());
            Director d2 = new Director(new ConcreteBuilder2());
            for(int i=0;i<5;i++){
    	        string tmp = GetString();
		        d1.Construct(tmp); d2.Construct(tmp);
                Put(d1.GetResult()); Put(d2.GetResult());
	        }
        }
    }
}
