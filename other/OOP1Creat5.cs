// File: "OOP1Creat5"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractButton
        {
            public abstract string GetControl();
        }

        public class Button1: AbstractButton {
            string text;
            public Button1(string text) {
                this.text = text;
            }
            public override string GetControl() {
                return "[" + text.ToUpper() + "]";
            }   
        }

        public class Button2: AbstractButton {
            string text;
            public Button2(string text) {
                this.text = text;
            }
            public override string GetControl() {
                return "<" + text.ToLower() + ">";
            }   
        }

        // Implement the Button1 and Button2 descendant classes

        public abstract class AbstractLabel
        {
            public abstract string GetControl();
        }

        public class Label1: AbstractLabel {
            string text;
            public Label1(string text) {
                this.text = text;
            }
            public override string GetControl() {
                return "=" + text.ToUpper() + "=";
            }   
        }

        public class Label2: AbstractLabel {
            string text;
            public Label2(string text) {
                this.text = text;
            }
            public override string GetControl() {
                return "\"" + text.ToLower() + "\"";
            }   
        }

        // Implement the Label1 and Label2 descendant classes

        public abstract class ControlFactory
        {
            public abstract AbstractButton CreateButton(string text);
            public abstract AbstractLabel CreateLabel(string text);
        }

        public class Factory1: ControlFactory {
            public override AbstractButton CreateButton(string text) {
                return new Button1(text);
            }
             public override AbstractLabel CreateLabel(string text) {
                 return new Label1(text);
             }
        }

        public class Factory2: ControlFactory {
            public override AbstractButton CreateButton(string text) {
                return new Button2(text);
            }
             public override AbstractLabel CreateLabel(string text) {
                 return new Label2(text);
             }
        }

        // Implement the Factory1 and Factory2 descendant classes

        public class Client
        {
            // Add required fields
            ControlFactory f;
            List<string> res = new List<string>();           
            
            public Client(ControlFactory f)
            {
                this.f = f;
                // Implement the constructor
            }
            public void AddButton(string text)
            {
                res.Add(f.CreateButton(text).GetControl());
                // Implement the method
            }
            public void AddLabel(string text)
            {
                res.Add(f.CreateLabel(text).GetControl());
                // Implement the method
            }
            public string GetControls()
            {
                string temp = res[0];

                for(int i = 1; i < res.Count(); ++i) {
                    temp += " " + res[i];
                }
                
                return temp;
                // Remove the previous statement and implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat5");

            string[] input = new string[GetInt()];

            for (int i = 0; i < input.Length; ++i) {
                input[i] = GetString();
            }

            Factory1 f1 = new Factory1();
            Factory2 f2 = new Factory2();
            Client c1 = new Client(f1);
            Client c2 = new Client(f2);

            for(int i = 0; i < input.Length; ++i) {
                string temp = "";
                for(int j = 2; j < input[i].Length; ++j)
                    temp += input[i][j];

                if(input[i][0] == 'B') {
                    c1.AddButton(temp);
                    c2.AddButton(temp);
                }
                else {
                    c1.AddLabel(temp);
                    c2.AddLabel(temp);
                }
            }

            // ShowLine(c1.GetControls());
            // ShowLine(c2.GetControls());
            
            Put(c1.GetControls());
            Put(c2.GetControls());

        }
    }
}
