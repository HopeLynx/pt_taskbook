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
    Task("STL2Seq3");
    vector<int> v(ptin(0),ptin());
    copy(v.begin()+v.size()/2,v.end(),ptout());
    copy(v.begin(),v.begin()+v.size()/2,ptout());
}
