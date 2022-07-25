// File: "OOP3Behav4"
using PT4;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class Validator
        {
            public virtual string Validate(string s)
            {
                return "";
            }
        }

        public class EmptyValidator: Validator {
            public override string Validate(string s) {
                if(s.Length != 0)
                    return "";
                else
                    return "!Empty text";
            }
        }

        public class NumberValidator: Validator {
            public override string Validate(string s) {
                if(s.Length == 0)
                    return "!'" + s + "': not a number";
                for(int i = 0; i < s.Length; ++i) {
                    if(s[0] != '-' && !char.IsDigit(s[i]))
                        return "!'" + s + "': not a number";
                }
                for(int i = 1; i < s.Length; ++i) {
                    if(s[0] == '-' && !char.IsDigit(s[i]))
                        return "!'" + s + "': not a number";
                }
                return "";
            }
        }

        public class RangeValidator: Validator {
            int min, max;
            public RangeValidator(int a, int b){
                if(a < b) {
                    this.min = a;
                    this.max = b;
                }
                else {
                    this.min = b;
                    this.max = a;
                }
            }
            public override string Validate(string s) {
                if(s.Length == 0) 
                    return "!'" + s + "': not in range " + min + ".." + max;
                for(int i = 0; i < s.Length; ++i) {
                    if(s[0] != '-' && !char.IsDigit(s[i]))
                        return "!'" + s + "': not in range " + min + ".." + max;
                }
                for(int i = 1; i < s.Length; ++i) {
                    if(s[0] == '-' && !char.IsDigit(s[i]))
                        return "!'" + s + "': not in range " + min + ".." + max;
                }
                if(int.Parse(s) >= min && int.Parse(s) <= max)
                    return "";
                else
                    return "!'" + s + "': not in range " + min + ".." + max;
                }
            }

        

        public class TextBox {
            string text = "";
            Validator v = new Validator();

        public void SetText(string s) {
            this.text = s;
        }
        public void SetValidator(Validator v) {
            this.v = v;
        }
        public string Validate() {
            return v.Validate(text);
        }
        }

        public class TextForm {
            TextBox[] tb = new TextBox[10];
            int n;
            public TextForm(int n) {
                this.n = n;
                for(int i = 0; i < n; ++i) {
                    tb[i] = new TextBox();
                }
            }
            public void SetText(int ind, string text) {
                tb[ind].SetText(text);
            }
            public void SetValidator(int ind, Validator v) {
                tb[ind].SetValidator(v);
            }
            public string Validate() {
                string res = "";
                for(int i = 0; i < n; ++i) {
                    res += tb[i].Validate();
                }
                return res;
            }
        }

        // Implement the EmptyValidator, NumberValidator
        //   and RangeValidator descendant classes

        // Implement the TextBox and TextForm classes

        public static void Solve()
        {
            Task("OOP3Behav4");

            int N = GetInt();
            int A = GetInt();
            int B = GetInt();

            int K = GetInt();

            List<Tuple<int, char>> lst = new List<Tuple<int, char>>();
            for(int i = 0; i < K; ++i) {
                int ind = GetInt();
                char c = GetChar();
                lst.Add(new Tuple<int, char>(ind, c));
            }

            for(int i = 0; i < 5; ++i) {
                TextForm tf = new TextForm(N);

                foreach(var el in lst) {
                if(el.Item2 == 'E') {
                    Validator val = new EmptyValidator();
                    tf.SetValidator(el.Item1, val);
                }
                else if(el.Item2 == 'N') {
                    Validator val = new NumberValidator();
                    tf.SetValidator(el.Item1, val);
                }
                else {
                    Validator val = new RangeValidator(A, B);
                    tf.SetValidator(el.Item1, val);
                }
                }

                for (int j = 0; j < N; ++j) {
                    string str = GetString();
                    tf.SetText(j, str);
                }

                Put(tf.Validate());
            }
        }
    }
}

