#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <string>

void Solve()
{
    Task("STL4Str21");
	int k; pt>>k;
	string s; pt>>s;
	rotate(s.begin(),s.begin()+k,s.begin()+s.length()/2);
	rotate(s.begin()+s.length()/2,s.end()-k,s.end());
	Show(s);
	pt << s;
}
