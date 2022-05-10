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

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ Button1 И Button2
        public class Button1 :  AbstractButton {


	    public Button1(string new_text){
		string tmp_a = new_text;
        tmp_a = tmp_a.ToUpper();
		text = "[" + tmp_a + "]";
	}
private	string text;
    public override string GetControl() {
        return text;
    }
};

class Button2 :  AbstractButton {

	public Button2(string new_text){
		string tmp_a = new_text;
		tmp_a = tmp_a.ToLower();
        text = "<"+tmp_a+">";
	}
    private	string text;
    public override string GetControl() {
        return text;
    }
};

        public abstract class AbstractLabel
        {
            public abstract string GetControl();
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ Label1 И Label2

        public class Label1 :  AbstractLabel {


	    public Label1(string new_text){
		string tmp_a = new_text;
        tmp_a = tmp_a.ToUpper();
		text = "=" + tmp_a + "=";
	}
private	string text;
    public override string GetControl() {
        return text;
    }
};

class Label2 :  AbstractLabel {

	public Label2(string new_text){
		string tmp_a = new_text;
		tmp_a = tmp_a.ToLower();
        text = "\""+tmp_a+"\"";
	}
    private	string text;
    public override string GetControl() {
        return text;
    }
};



        public abstract class ControlFactory
        {
            public abstract AbstractButton CreateButton(string text);
            public abstract AbstractLabel CreateLabel(string text);
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ Factory1 И Factory2
        public class Factory1 : ControlFactory{
            public override AbstractButton CreateButton(string text)
            {
                return new Button1(text);
            }
            public override AbstractLabel CreateLabel(string text)
            {
                return new Label1(text);
            }

        }

                public class Factory2 : ControlFactory{
            public override AbstractButton CreateButton(string text)
            {
                return new Button2(text);
            }
            public override AbstractLabel CreateLabel(string text)
            {
                return new Label2(text);
            }

        }

        public class Client
        {
            // ДОБАВЬТЕ НЕОБХОДИМЫЕ ПОЛЯ
            ControlFactory controller;
            List <string> controls = new List <string> {};
            public Client(ControlFactory f)
            {
                controller = f;
                // РЕАЛИЗУЙТЕ КОНСТРУКТОР
            }
            public void AddButton(string text)
            {
                var tmp = controller.CreateButton(text).GetControl();
                Show(tmp);
                controls.Add(tmp);
                // РЕАЛИЗУЙТЕ МЕТОД
            }
            public void AddLabel(string text)
            {
                // РЕАЛИЗУЙТЕ МЕТОД
                var tmp = controller.CreateLabel(text).GetControl();
                Show(tmp);
                controls.Add(tmp);
            }
            public string GetControls()
            {
                var tmp = string.Join(" ",controls);
                return tmp;
                // УДАЛИТЕ ПРЕДЫДУЩИЙ ОПЕРАТОР И РЕАЛИЗУЙТЕ МЕТОД
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat5");
            var n = GetInt();

            Factory1 f1 = new Factory1();
	        Factory2 f2 = new Factory2();
            Client c1 = new Client(f1);
	        Client c2 = new Client(f2); 
            for (int i=0;i<n;i++){
    	        string tmp; tmp = GetString();
		        var strings = tmp.Split(' ') ;
		        if (strings[0] == "L"){
		        	c1.AddLabel(strings[1]);
		        	c2.AddLabel(strings[1]);
		        } else if (strings[0] == "B"){
		        	c1.AddButton(strings[1]);
		        	c2.AddButton(strings[1]);
		        }
	        }
	        Put(c1.GetControls());
	        Put(c2.GetControls());
        }
    }
}
