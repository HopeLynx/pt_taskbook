#include "pt4.h"
#include <vector>
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
    Task("XString50");
	string s; string ans = "";
	pt >> s;
	/*char last=s[0];
	ans += last;
	for (int i=1;i<s.length();i++){
		last = s[i-1];
		if (isalpha(s[i]) && last == ' ') ans += " ";
		if (isalpha(s[i])) ans += s[i];
	}*/
	vector<string> v{my_split(s, ' ')};
	vector<string>::reverse_iterator rit = v.rbegin();
	ans += *rit;rit++; 
	for(; rit!=v.rend();rit++) ans += " " + *rit;
	pt << ans;
}
