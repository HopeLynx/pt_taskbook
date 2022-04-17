#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <string>

void Solve()
{
    Task("STL4Str4");
    int k=0; pt >> k;
    string s; pt >> s;
    s.insert(s.length()/2,k,'*');
    pt << s;

}
