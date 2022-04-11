#include "pt4.h"
#include <cstring>
#include <vector>
#include <algorithm>
using namespace std;

class AbstractComparable
{
	//vector <AbstractComparable*> v;
public:
    virtual int CompareTo(AbstractComparable* other) = 0;
    
    /*
    AbstractComparable(vector <AbstractComparable*> abs) {
    	v.insert(v.end(),abs.begin(),abs.end());
	}
	*/
	//AbstractComparable();
    string key;
    
	int IndexMax(vector <AbstractComparable*> v){
		//int t = 0;
		int max =0;
		for (int i=1; i<v.size();i++){
			int tmp = v[i]->CompareTo(v[max]);
			if (tmp > 0) { max = i;Show("new max"+ to_string(i));}
			//t = i+1;
			//if (v[t]->CompareTo(v[max])>0) max = t;	
			//}
		}
		return max;
	}/*
	int LastIndexMax(vector <AbstractComparable*> v){
		int t = 0;
		for (int i=0; i<v.size()-1;i++){
			int tmp = v[i+1]->CompareTo(v[i]);
			if (tmp <= 0) t = i;
		}
		return t;
	}
	int IndexMin(vector <AbstractComparable*> v){
		int t = 0;int min=0;
		for (int i=0; i<v.size()-1;i++){
			int tmp = v[i+1]->CompareTo(v[i]);
			if (tmp > 0) {
			t = i;
			if (v[t]->CompareTo(v[min])<0) min = t;	
			}
			
		}
		return min;
	}
	int LastIndexMin(vector <AbstractComparable*> v){
		int t = 0;
		for (int i=0; i<v.size()-1;i++){
			int tmp = v[i+1]->CompareTo(v[i]);
			if (tmp >= 0) t = i;
		}
		return t;
	}*/
    // –≈¿À»«”…“≈ —“¿“»◊≈— »≈ Ã≈“Œƒ€ IndexMax,
    //   LastIndexMax, IndexMin » LastIndexMin
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » NumberComparable,
//   LengthComparable » TextComparable

class NumberComparable : public AbstractComparable{
	public:
	int key;
	NumberComparable(string data){
		int tmp = 0;
		for (int i=0;i<data.length();i++){
			if(isalpha(data[i])) tmp++;
		}
		if(tmp || data == "") key = 0;
		else key = stoi(data);
		
	}
    int CompareTo(AbstractComparable* other) {
    	NumberComparable* tmp = new NumberComparable(other->key);
    	/*
    	if (key > other->key) return 1;
    	if (key == other->key) return 0;
    	if (key < other->key) return -1;
    	*/
    	Show( ":" + to_string(key) + ":");Show( ":" + to_string(tmp->key) + ":");
    	int lul = key - tmp->key;
    	Show("!" + to_string(lul) + "!");
    	return lul;
	}
};

class TextComparable : public AbstractComparable{
	public:
	string key;
	TextComparable(string data){
		key = data;	
	}
    int CompareTo(AbstractComparable* other) {
    	TextComparable* test = new TextComparable(other->key);
    	return strcmp(key.c_str(),test->key.c_str());
	}
};

class LengthComparable : public AbstractComparable{
	public:
	string key;
	LengthComparable(string data){
		key = data;	
	}
    int CompareTo(AbstractComparable* other) {
    	LengthComparable* test = new LengthComparable(other->key);
    	//Show(key + ":" + to_string(key.length()));Show(test->key + ":" + to_string(test->key.length()));
    	int tmp = key.length() - test->key.length();
    	//Show("!" + to_string(tmp) + "!");
    	//if (tmp == 0) tmp = strcmp(key.c_str(),other->key.c_str());
    	return tmp;
	}
};


void Solve()
{
    Task("OOP3Behav6");
    
    int n,k; pt >> n >> k;
    for (int i = 0; i<k; i++){
    	string type; pt >> type;
    	vector<AbstractComparable*> v; 
    	for (int j=0;j < n;j++){
    		string tmp; pt >> tmp;
    		if (type =="T"){
    			v.push_back(new TextComparable(tmp));
			} else if (type == "L"){
				v.push_back(new LengthComparable(tmp));
			} else if (type == "N"){
				v.push_back(new NumberComparable(tmp));	
			}	
		}
		AbstractComparable* abs;
		pt << abs->IndexMax(v) << 0 << 0 << 0; //<< abs->LastIndexMax(v) <<
		//abs->IndexMin(v) << abs->LastIndexMin(v) ;
	}

}
