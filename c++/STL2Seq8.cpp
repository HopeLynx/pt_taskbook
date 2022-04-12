#include "pt4.h"
using namespace std;

#include <iterator>
#include <vector>
#include <deque>
#include <list>

typedef ptin_iterator<int> ptin;
typedef ptout_iterator<int> ptout;

void Solve()
{
    Task("STL2Seq8");
    
    vector<int> v(ptin(0),ptin());
    v.insert(v.begin()+v.size()/2,5,0);
    copy(v.begin(),v.end(),ptout());
}
