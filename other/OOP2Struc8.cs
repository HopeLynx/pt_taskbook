// File: "OOP2Struc8"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Function
        {
            public abstract string GetName();
            public abstract int GetValue(int x);
        }

        public class FX: Function {
            public override string GetName() {
                return "X";
            }

            public override int GetValue(int x) {
                return x;
            }
        }

        public class FDouble: Function {
            Function f;
            public FDouble(Function f) {
                this.f = f;
            }
            public override string GetName() {
                return "2*(" + f.GetName() + ")";
            }

            public override int GetValue(int x) {
                return f.GetValue(x) * 2;
            }
        }

        public class FTriple: Function {
            Function f;
            public FTriple(Function f) {
                this.f = f;
            }
            public override string GetName() {
                return "3*(" + f.GetName() + ")";
            }

            public override int GetValue(int x) {
                return f.GetValue(x) * 3;
            }
        }

        public class FSquare: Function {
            Function f;
            public FSquare(Function f) {
                this.f = f;
            }
            public override string GetName() {
                return "(" + f.GetName() + ")^2";
            }

            public override int GetValue(int x) {
                int temp = f.GetValue(x);
                return temp * temp;
            }
        }

        public class FCube: Function {
            Function f;
            public FCube(Function f) {
                this.f = f;
            }
            public override string GetName() {
                return "(" + f.GetName() + ")^3";
            }

            public override int GetValue(int x) {
                int temp = f.GetValue(x);
                return temp * temp * temp;
            }
        }

        // Implement the FX, FDouble, FTriple, FSquare
        //   and FCube descendant classes

        public static void Solve()
        {
            Task("OOP2Struc8");

            int n = GetInt();
            string[] str = new string[n];
            Function[] func = new Function[n];

            for (int i = 0; i < n; ++i) {
                string temp = GetString();
                str[i] = temp;
            }

            int x1 = GetInt();
            int x2 = GetInt();
            Function fx = new FX();

            for (int i = 0; i < n; ++i) {
                
                if(str[i].Length > 0) {
                    Function f;
                    if(str[i][0] == 'D')
                        f = new FDouble(new FX());
                    else if(str[i][0] == 'T')
                        f = new FTriple(new FX());
                    else if(str[i][0] == 'S')
                        f = new FSquare(new FX());
                    else
                        f = new FCube(new FX());

                    for(int j = 1; j < str[i].Length; ++j) {
                        if(str[i][j] == 'D')
                            f = new FDouble(f);
                        else if(str[i][j] == 'T')
                            f = new FTriple(f);
                        else if(str[i][j] == 'S')
                            f = new FSquare(f);
                        else
                            f = new FCube(f);
                    }

                    func[i] = f;
                }
                else 
                    func[i] = new FX();
            }

            for (int i = 0; i < n; ++i) {
                Put(func[i].GetName());
                Put(func[i].GetValue(x1));
                Put(func[i].GetValue(x2));
            }
        }
    }
}
