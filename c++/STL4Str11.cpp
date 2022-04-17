#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <string>

void Solve()
{
    Task("STL4Str11");
    string s; pt >> s;
    string::iterator it;
    it = s.begin()+2;
    while(it!=s.end()){
		s.erase(it);
		Show(s);
		it = distance(it,s.end()) > 2 ? it+2 : s.end(); 
	}
	pt << s;
}
