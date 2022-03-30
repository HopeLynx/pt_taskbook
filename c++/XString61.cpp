#include "pt4.h"
using namespace std;

const vector<string> my_split(const string& s, const char& c)
{
	string buff{""};
	vector<string> v;
	for(auto n:s){
		if(n != c) buff+=n;
		else if(n == c && buff != "") { v.push_back(buff); buff = ""; }
	}
	if(buff != "") v.push_back(buff);
	return v;
}

void Solve()
{
    Task("XString61");
	string s; string ans = "";
	pt >> s;
	vector<string> v{my_split(s, '\\')};
	if(v.size() == 2) {pt << "\\";return;}
	else pt << v[v.size()-1-1];
}
