#include "pt4.h"
using namespace std;

#include <vector>
#include <string>

class Component
{
public:
    virtual string Show() = 0;
};

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑ-ÏÎÒÎÌÎÊ ConcreteComponent
class ConcreteComponent : public Component
{
	string text;
public:
    string Show() {return text;};
    ConcreteComponent (string txt) {text = txt;}
};

class Decorator : public Component
{
protected:
    Component* comp;
};

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ-ÏÎÒÎÌÊÈ ConcreteDecoratorA
//   È ConcreteDecoratorB

class ConcreteDecoratorA : public Decorator
{
	public:
	string Show() {return "==" + comp->Show() + "==";};
	ConcreteDecoratorA(Component* c) {comp = c;}
};

class ConcreteDecoratorB : public Decorator
{
	public:
	string Show() {return "(" + comp->Show() + ")";};
	ConcreteDecoratorB(Component* c) {comp = c;}
};

void Solve()
{
    Task("OOP2Struc7");
    vector <Component*> comp;
    int n; pt >> n;
    for (int i=0; i<n; i++){
		string s,d; pt >> s >> d;
		
		ConcreteComponent* cc = new ConcreteComponent(s);
		if (d != ""){
			for (int j=0;j<d.length();j++){
				if (d[j] == 'A')cc = new ConcreteComponent(ConcreteDecoratorA(cc).Show());
				if (d[j] == 'B')cc = new ConcreteComponent(ConcreteDecoratorB(cc).Show());				
			}
		}
    	comp.push_back(cc);
		//Show(ConcreteDecoratorA(cc).Show());
	}
	for (int i=comp.size()-1;i>=0;i--) pt << comp[i]->Show();
}
