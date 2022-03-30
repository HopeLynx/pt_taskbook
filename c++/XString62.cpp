#include "pt4.h"
using namespace std;

void Solve()
{
    Task("XString62");
	string s;
	pt >> s;
	for (int i=0;i<s.length();i++){
		if (isalpha(s[i]) && s[i] != 'z' && s[i] != 'Z') s[i]+=1;
		else if (s[i]=='z') s[i] = 'a';
		else if (s[i]=='Z') s[i] = 'A';
	}
	pt << s;
}
