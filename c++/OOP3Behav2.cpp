#include "pt4.h"
#include <list>
#include <iterator>
using namespace std;

class Observer;

class Subject
{
public:
    virtual void Attach(Observer* observ) = 0;
    virtual void Detach(Observer* observ) = 0;
    virtual void SetInfo(string info) = 0;
};

class Observer
{
public:
    virtual void OnInfo(Subject* sender, string info) = 0;
};

class ConcreteSubject : public Subject{
	list<Observer*> observers;
	list<Observer*>::iterator iterator;
	//string message;
	public:
		void Attach(Observer* observ) {
			observers.push_back(observ);
		};
    	void Detach(Observer* observ) {
    		//observers.remove(observ);
    		iterator = observers.erase(iterator);iterator --;
		};
    	void SetInfo(string info) {
			iterator = observers.begin();
			while (iterator != observers.end()) {
      			(*iterator)->OnInfo(this,info);
      			++iterator;}
		};
};

class ConcreteObserver : public Observer
{
	string log;
	char detachInfo;
public:
	ConcreteObserver (char detachInfo){
		this->detachInfo = detachInfo;
		log = "";
	}
    void OnInfo(Subject* sender, string info) {
    	log += info;
    	if (info[1] == detachInfo){
		Show("det");Show(info); Detach(sender);
		} 
	};
	void Attach (Subject* s){
		s->Attach(this);
	}
	void Detach (Subject* s){
		//Show("det");
		s->Detach(this);
	}
	string GetLog() {return log;}
};


// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ-ÏÎÒÎÌÊÈ ConcreteSubject
//   È ConcreteObserver

void Solve()
{
    Task("OOP3Behav2");
    
    ConcreteSubject* cs1 = new ConcreteSubject();
    ConcreteSubject* cs2 = new ConcreteSubject();
    
    int n,k;
    pt >> n >> k;
    
    ConcreteObserver* obs[n];
    
    for (int i=0;i<n;i++){
    	Show("init");
    	obs[i] = new ConcreteObserver(i+'a');
    	cs1->Attach(obs[i]);
    	cs2->Attach(obs[i]);
	}
	
	for (int i=0;i<k;i++){
		Show("in work");
		string tmp; pt >> tmp;
		if (tmp[0] == '1') cs1->SetInfo(tmp);
		else cs2->SetInfo(tmp);
	}
    
    for (int i=0;i<n;i++){
    	pt << obs[i]->GetLog();
	}
    
    

}
