#include "pt4.h"
using namespace std;

void Solve()
{
    Task("XString7");
	string s;
	pt >> s;
	pt << (int)s[0];
	pt << (int)s[s.length()-1];
}
