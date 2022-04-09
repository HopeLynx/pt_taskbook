#include "pt4.h"

#include <algorithm>
#include <cctype>
#include <string>

using namespace std;

void my_to_lower(string& data){
	transform(data.begin(), data.end(), data.begin(),
	[](unsigned char c){ return tolower(c); });
}

void my_to_upper(string& data){
	transform(data.begin(), data.end(), data.begin(),
	[](unsigned char c){ return toupper(c); });
}

class Implementor
{
public:
    virtual string DrawLine(int size) = 0;
    virtual string DrawText(string text) = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » ConcreteImplementorA
//   » ConcreteImplementorB

class ConcreteImplementorA : public Implementor
{
	public:
		string DrawLine(int size) {
			string ans ="";
			for (int i=0;i<size;i++){
				ans += "-";
			}
			return ans;
		};
		string DrawText(string text) {
			string ans ="";
			my_to_lower(text);Show(text);
			ans += text;
			ans += "-";
			return ans;
		};
};

class ConcreteImplementorB : public Implementor
{
	public:
		string DrawLine(int size) {
			string ans ="";
			for (int i=0;i<size;i++){
				ans += "=";
			}
			return ans;
		};
		string DrawText(string text) {
			string ans ="";
			my_to_upper(text);Show(text);
			ans += text;
			ans += "=";
			return ans;
		};
};

// ˝ÚÓÚ ‚˚Á˚‚‡ÂÏ ÒÌ‡˜‡Î‡ ‰Îˇ ÒÚÓÍ ·ÂÁ ·ÛÍ‚ 


class Abstractions{
	protected:
    	int size;
    	Implementor* imp;
    public:
    	virtual string show_line() = 0;
    	virtual void setsize(int size) =0;
};

class myAbstraction : public Abstractions
{
protected:
    int size;
    Implementor* imp;
public:
    myAbstraction(Implementor* imp_, int size_){
    	Show("myAbs!");
		imp = imp_;
		size = size_;
	}
	myAbstraction(){imp = NULL;		size = 0;}
    // «¿¬≈–ÿ»“≈ –≈¿À»«¿÷»ﬁ  À¿——¿ Abstraction
    string show_line(){
    	Show("parent_print");
    	return imp->DrawLine(size);
	}
	void setsize(int size_) {size = size_;}
};

// ˝ÚÓÚ ‚˚Á˚‚‡ÂÏ ÔÓÚÓÏ ‰Îˇ ÌÓÏ ÒÚÓÍ
// –≈¿À»«”…“≈  À¿——-œŒ“ŒÃŒ  RefinedAbstraction
class RefinedAbstraction : public Abstractions
{
private:
    //int size;
    string caption;
    //Implementor* imp;
public:
    RefinedAbstraction(Implementor* imp_, int size_, string caption_) /*: Abstraction::Abstraction(imp_,size_)*/{
		Show("ref!");
		
		imp = imp_;
		size = size_;
		caption = caption_;
	}
	RefinedAbstraction(){imp = NULL;size = 0; caption = "";}
	
    string show_line() {
    	Show("child_print");
    	string ans = "";
    	if (size == 0) return ans;
    	else if (size >= 1) {
    		ans += imp->DrawLine(1);
			ans += imp->DrawText(caption);
			if (ans.length() > size) {
				while (ans.length() > size) ans.pop_back();
			} else {	
				if (ans.length() < size){
					while (ans.length() < size) ans += imp->DrawLine(1);
					Show("loser");
				}
			}
		}
		return ans; 
	}
	void setsize(int size_) {size = size_;}
};

void Solve()
{
    Task("OOP2Struc10");
    int n; string cap; 
    pt >> n >> cap;
    
    ConcreteImplementorA* ca = new ConcreteImplementorA;
    ConcreteImplementorB* cb = new ConcreteImplementorB;
    
    Abstractions* abs[4];
    abs[0] = new myAbstraction(ca,n);
    abs[1] = new myAbstraction(cb,n);
    abs[2] = new RefinedAbstraction(ca,n,cap);
    abs[3] = new RefinedAbstraction(cb,n,cap);
    
    for (int i=0;i<4;i++) pt << abs[i]->show_line();
    for (int j=0;j<5;j++) {
    	int l;pt >> l;
		for (int i=0;i<4;i++) {abs[i]->setsize(l);pt << abs[i]->show_line();}
	}

}
