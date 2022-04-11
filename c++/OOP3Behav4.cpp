#include "pt4.h"
#include <vector>
#include <algorithm>
#include <iterator>
using namespace std;

class Validator
{
public:
    virtual string Validate(string s){return "";};
};

class EmptyValidator : public Validator {
	public:
    string Validate(string s){
		string ans = "";
		if (s == "") ans = "!Empty text";
		return ans;
	};
};

class NumberValidator : public Validator {
	public:
    string Validate(string s){
		string ans = "";int tmp = 0;
		for (int i=0;i<s.length();i++){
			if(isalpha(s[i])) tmp++;
		}
		if(tmp || s == "") ans += "!'" + s + "': not a number";
		return ans;
	};
};

class RangeValidator : public Validator {
	int a;
	int b;
	public:
	RangeValidator(int a,int b){
		if (a > b ) {
			this->a = b;
			this->b = a;
		} else {
			this->a = a;
			this->b = b;			
		}
	}
    string Validate(string s){
		string ans = "";int tmp = 0;
		for (int i=0;i<s.length();i++){
			if(isalpha(s[i])) tmp++;
		}
		if(tmp || s == "" || stoi(s) < a || stoi(s) > b)
		ans += "!'" + s + "': not in range " + to_string(a) + ".." + to_string(b);
		return ans;
	};
};
// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ-ÏÎÒÎÌÊÈ EmptyValidator,
//   NumberValidator È RangeValidator

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ TextBox È TextForm

class TextBox{
	string text = "";
	Validator* v = new Validator();
	
	public:
		void SetText(string text){
			this->text = text;
		}
		void SetValidator(Validator* v){
			this->v = v; 
		}
		string Validate(){
			return v->Validate(text);
		}
};

class TextForm{
	vector <TextBox> tb;
	
	public:
		TextForm (int n){
			for (int i=0;i<n;i++){
				tb.push_back(TextBox());
			}
		}
		void SetText(int ind,string text){
			tb[ind].SetText(text);
		}
		void SetValidator(int ind,Validator* v){
			tb[ind].SetValidator(v); 
		}
		string Validate(){
			string ans = "";
			vector <TextBox>::iterator it = tb.begin(); 
			while (it != tb.end()){
			//for (auto i:tb){
				ans += it->Validate();
				Show("!!!" + ans);
				it++;
			}
			return ans;
		}
};

void Solve()
{
    Task("OOP3Behav4");
	int n,a,b,k;
	pt >> n >> a >> b >> k;
	
	TextForm tf(n);
	
	Show("1");
	
	NumberValidator* nv = new NumberValidator();
	RangeValidator* rv = new RangeValidator(a,b);
	EmptyValidator* ev = new EmptyValidator();
	
	int ind; char c;
	for (int i=0;i<k;i++){
		pt >> ind >> c;
		Validator* v;
		if (c == 'N'){
			v = nv;
		} else if (c == 'R') {
			v = rv;
		} else if (c == 'E'){
			v = ev;
		}
		tf.SetValidator(ind,v);
	}
	
	Show("2");
	
	for (int i =0; i<5;i++){
		for (int j = 0; j<n;j++){
			string in;
			pt >> in;
			Show("mb here");
			tf.SetText(j,in);
		}
		Show("check");
		pt << tf.Validate();
	}
	
}
