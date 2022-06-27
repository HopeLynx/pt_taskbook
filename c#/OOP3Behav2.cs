// File: "OOP3Behav2"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        /*
        ПРИМЕЧАНИЕ. Описанный вариант взаимодействия субъектов
        и наблюдателей можно реализовать с помощью ДЕЛЕГАТОВ
        и СОБЫТИЙ (см. примечание к предыдущему заданию
        в заготовке для языка C#).
        */

        public abstract class Subject
        {
            public abstract void Attach(Observer observ);
            public abstract void Detach(Observer observ);
            public abstract void SetInfo(string info);
        }

        // РЕАЛИЗУЙТЕ КЛАСС-ПОТОМОК ConcreteSubject
        public class ConcreteSubject :  Subject{
	    List<Observer> observers = new List<Observer>();
	//string message;
		public override void Attach(Observer observ) {
			observers.Add(observ);
		}
    	public override void Detach(Observer observ) {
    		observers.Remove(observ);
            Show("dett");
    		//iterator = observers.erase(iterator);iterator --;
		}
    	public override void SetInfo(string info) {
			//iterator = observers.begin();
            //for (int i = 0;i<observers.Count;i++) observers[i].OnInfo(this,info);
            foreach(var obs in observers.ToList()) obs.OnInfo(this,info);
            ////
		}/////////////////ПРОСКАКИВАЕТ СЛУДУЮЩИЙ ЕСЛИ УДАЛИЛ
};

        public abstract class Observer
        {
            public abstract void OnInfo(Subject sender, string info);
        }

        // РЕАЛИЗУЙТЕ КЛАСС-ПОТОМОК ConcreteObserver

        public class ConcreteObserver :  Observer
{
	public string log;
	public char detachInfo;
    public bool flag;

	public ConcreteObserver (char detachInfo){
		this.detachInfo = detachInfo;
		log = "";
	}
    public override void OnInfo(Subject sender, string info) {
    	log += info;
    	if (info[1] == detachInfo){
		Show("det");Show(info); Detach(sender);
		} 
	}
	public void Attach (Subject s){
		s.Attach(this);
	}
	public void Detach (Subject s){
		Show("det");
		s.Detach(this);
	}
	public string GetLog() {return log;}
};

        public static void Solve()
        {
            Task("OOP3Behav2");

            ConcreteSubject cs1 = new ConcreteSubject();
            ConcreteSubject cs2 = new ConcreteSubject();

            int n = GetInt(),k = GetInt();

            ConcreteObserver[] obs = new ConcreteObserver [n];

            for (int i=0;i<n;i++){
            	Show("init");
                int t = Convert.ToInt32('a')+ i;
                char tmp = (char)t;
            	obs[i] = new ConcreteObserver(tmp);
            	cs1.Attach(obs[i]);
            	cs2.Attach(obs[i]);
	        }

	        for (int i=0;i<k;i++){
	        	Show("in work");
	        	string tmp= GetString();
	        	if (tmp[0] == '1') cs1.SetInfo(tmp);
	        	else cs2.SetInfo(tmp);
	        }

            for (int i=0;i<n;i++){
            	Put(obs[i].GetLog());
	        }
    
        }
    }
}
