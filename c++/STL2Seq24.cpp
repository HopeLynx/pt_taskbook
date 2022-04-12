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
    Task("STL2Seq24");
    list<int>  L1(ptin(0), ptin());
    list<int>  L2(ptin(0), ptin());
    
    list<int>::iterator it = L1.begin();
    advance(it,(L1.size()/2));
    
    L1.splice(L2.end(),L2,it);

    Show(L1.begin(), L1.end(), "L1: ");
    Show(L2.begin(), L2.end(), "L2: ");
    copy(L1.begin(), L1.end(), ptout());
    copy(L2.begin(), L2.end(), ptout());
}
