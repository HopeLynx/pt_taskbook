#include "pt4.h"
using namespace std;

void Solve()
{
    Task("XString38");
	string s,s1,s2;
	pt >> s;
	pt >> s1; pt >> s2;
	int pos = s.find(s1);
	while (pos != -1){
        string tmp = s;
        string tmp_beg = tmp.substr(0,pos);
        string tmp_end = tmp.substr(pos+s1.length(),s.length()-s1.length()-pos);
        s.erase();
        s += tmp_beg + s2 + tmp_end;
        pos = s.find(s1);
    }
	pt << s;
}
