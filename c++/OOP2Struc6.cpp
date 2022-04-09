#include "pt4.h"
using namespace std;

#include <cctype>
#include <vector>

class Device
{
public:
    virtual void Add(Device* d) {}
    virtual string GetName() = 0;
    virtual int GetTotalPrice() = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » SimpleDevice » CompoundDevice

class SimpleDevice : public Device
{
	string name;
	int price;
public:
    void Add(Device* d) {}
    string GetName() {return name;};
    int GetTotalPrice() {return price;};
    
	SimpleDevice(string n,int p) {
		name = n;
		price = p;
	}
};

class CompoundDevice : public Device
{
	string name;
	int price;
	vector <Device*> children;
public:
    void Add(Device* d) {/* TODO */
	children.push_back(d);
	}
    string GetName() {return name;};
    int GetTotalPrice() {
		int sum = price;
		for (int i=0;i<children.size();i++){
			sum += children[i]->GetTotalPrice();
		}
		return sum;
	};
	CompoundDevice(string n,int p) {
		name = n;
		price = p;
	}
	
};

void Solve()
{
    Task("OOP2Struc6");
	
	vector <Device*> dev;
	int n; pt >> n;
	for(int i=0;i<n;i++){
		string s; int p;
		pt >> s >> p;
		//set up
		if (/* cap letter */ isupper(s[0])) {
			dev.push_back(new CompoundDevice(s,p));
		} else {
			dev.push_back(new SimpleDevice(s,p));
		}
	}
	for(int i=0;i<n;i++){
		int ind; pt >> ind;
		if (ind != -1) (dev[ind])->Add(dev[i]);
		//set up
	}
	for(int i=0;i<n;i++){
		pt << (dev[i])->GetName() << (dev[i])->GetTotalPrice(); 
	}
}
