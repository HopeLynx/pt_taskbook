#include "pt4.h"
using namespace std;

#include <vector>
#include <string>

class State
{
public:
    virtual string GetNextToken() = 0;
};

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑ Context
class Context {
	string text;
	State* st;
	public:
	void SetState(State* ns){
		st = ns;
	};
	char GetCharAt(int ind) {
		return text[ind];
	};
	string GetNextToken(){
		return st->GetNextToken();
	};
}; 

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ-ÏÎÒÎÌÊÈ ConcreteStateNormal,
//   ConcreteStateString, ConcreteStateComm
//   È ConcreteStateFin

class ConcreteStateFin : public State {
	public:
    string GetNextToken() {
    	return "";
	};
};

class ConcreteStateNormal : public State {
	Context* ct;
	int index;
	public:
	ConcreteStateNormal(Context* c, int ind);
	string GetNextToken();
	};

class ConcreteStateString : public State {
	Context* ct;
	int index;
	public:
	ConcreteStateString(Context* c, int ind);
    string GetNextToken();
	};
	
class ConcreteStateComm : public State {
	Context* ct;
	int index;
	public:
	ConcreteStateComm(Context* c, int ind);
    string GetNextToken();
	};

ConcreteStateNormal::ConcreteStateNormal(Context* c, int ind){
	ct = c;
	index = ind;
}

string ConcreteStateNormal::GetNextToken() {
	string ans = "";
	char tmp = 0;
	tmp = ct->GetCharAt(index);
    	while (tmp != '.' && tmp != '{' && tmp != '}' && tmp != '"'){
			ans += tmp;
			index++;
		}
		    if (tmp == '.') {
    			ct->SetState(new ConcreteStateFin);
			}
			if (tmp == '{' || tmp == '}'){
				ct->SetState(new ConcreteStateComm(ct,index));
			}
			 if (tmp == '"') {
    			ct->SetState(new ConcreteStateString(ct,index));
			}
			
		return "Normal:"+ans;
	};


ConcreteStateString::ConcreteStateString(Context* c, int ind){
		ct = c;
		index = ind;
	}
string ConcreteStateString::GetNextToken() {
    	string ans = "";
    	char tmp = 0;
    	tmp = ct->GetCharAt(index);
    	while (tmp != '.' && tmp != '"'){
			ans += tmp;
			index++;
		}
		    if (tmp == '.') {
    			ct->SetState(new ConcreteStateFin());
			}
			 if (tmp == '"') {
    			ct->SetState(new ConcreteStateNormal(ct,index));
			}
		return "String: "+ans;
	};



	ConcreteStateComm::ConcreteStateComm(Context* c, int ind){
		ct = c;
		index = ind;
	}
    string ConcreteStateComm::GetNextToken() {
    	string ans = "";
    	char tmp = 0;
    	tmp = ct->GetCharAt(index);
    	while (tmp != '.' && tmp != '{' && tmp != '}'){
			ans += tmp;
			index++;
		}
		    if (tmp == '.') {
    			ct->SetState(new ConcreteStateFin);
			}
			if (tmp == '{' || tmp == '}'){
				ct->SetState(new ConcreteStateNormal(ct,index));
			}
		return "Comm: "+ans;
	};

void Solve()
{
    Task("OOP3Behav10");
    string s; pt >> s;
    Context c;
    c.SetState(new ConcreteStateNormal(&c,0));
    string tmp;tmp = c.GetNextToken();
	while(tmp.length()){
		pt << tmp;
		tmp = c.GetNextToken();
	}
    

}
