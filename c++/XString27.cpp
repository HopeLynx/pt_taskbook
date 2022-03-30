#include "pt4.h"
using namespace std;

void Solve()
{
    Task("XString27");
	string s1,s2; int n1,n2;
	pt >> n1; pt >> n2;
	pt >> s1; pt >> s2;
	s1 = s1.substr(0,n1); s2 = s2.substr(s2.length()-n2,n2);;
	pt << s1+s2;
}
