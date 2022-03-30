#include "pt4.h"
#include <locale>
using namespace std;

void Solve()
{
    Task("XString17");
	string s;
	pt >> s;
	for (int i=0;i<s.length();i++) s[i] = char(toupper(s[i]));
	pt << s;
}
