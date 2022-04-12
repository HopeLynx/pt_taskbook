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
    Task("STL2Seq21");

    vector<int> v(ptin(0),ptin());
    v.erase(v.begin()+v.size()/2-1,v.begin()+v.size()/2+1+1);
    copy(v.begin(),v.end(),ptout());
}





