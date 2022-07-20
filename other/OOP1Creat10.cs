// File: "OOP1Creat10"
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
            public virtual void BuildStart(char c) {}
            public virtual void BuildFirstChar(char c) {}
            public virtual void BuildNextChar(char c) {}
            public virtual void BuildDelim() {}
            public abstract string GetResult();
        }

        public class BuilderPascal: Builder {
            string product = "";
            public override void BuildStart(char c) {
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c) {
                product += c.ToString().ToUpper();
            }
            public override void BuildNextChar(char c) {
                product += c.ToString().ToLower();
            }
            public override void BuildDelim() {}
            public override string GetResult() {
                return product;
            }
        }

        public class BuilderPyhton: Builder {
            string product = "";
            public override void BuildStart(char c){
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c){
               product += c.ToString().ToLower(); 
            }
            public override void BuildNextChar(char c){
               product += c.ToString().ToLower(); 
            }
            public override void BuildDelim(){
                product += "_";
            }
            public override string GetResult(){
                return product;
            }
        }

        public class BuilderC: Builder {
            string product = "";
            public override void BuildStart(char c) {
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c){
                product += c.ToString().ToLower();
            }
            public override void BuildNextChar(char c){
                product += c.ToString().ToLower();
            }
            public override void BuildDelim(){}
            public override string GetResult(){
                return product;
            }
        }
        // Implement the BuilderPascal, BuilderPyhton
        //   and BuilderC descendant classes

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
                if (templat.Length > 0) {
                    b.BuildStart(templat[0]);
                    for (int i = 1; i < templat.Length; ++i) {
                        if(templat[i - 1] == ' ' && templat[i] != ' ')
                            b.BuildFirstChar(templat[i]);
                        else if(templat[i] == ' ' && templat[i + 1] == ' ')
                            continue;
                        else if(templat[i] == ' ' && templat[i + 1] != ' ')
                            b.BuildDelim();
                        else
                            b.BuildNextChar(templat[i]);
                    }
                }

                // Complete the implementation of the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat10");

            for (int i = 0; i < 5; ++i) {
                
                BuilderPascal pascal = new BuilderPascal();
                BuilderPyhton python = new BuilderPyhton();
                BuilderC c = new BuilderC();

                string str = GetString();
                
                var dPascal = new Director(pascal);
                dPascal.Construct(str);
                Put(dPascal.GetResult());

                var dPython = new Director(python);
                dPython.Construct(str);
                Put(dPython.GetResult());

                var dC = new Director(c);
                dC.Construct(str);
                Put(dC.GetResult());
            }
        }
    }
}
