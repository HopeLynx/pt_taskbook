#include "pt4.h"
using namespace std;

#include <iterator>
#include <vector>
#include <set>
#include <map>
#include <functional>
#include <algorithm>

typedef ptin_iterator<int> ptin;
typedef ptout_iterator<int> ptout;

void Solve()
{
    Task("STL5Assoc6");
    vector<int> V1(ptin(0), ptin());
    vector<int> V2(ptin(0), ptin());
    multiset<int> m1(V1.begin(),V1.end());
    multiset<int> m2(V2.begin(),V2.end());
	set_union(m1.begin(),m1.end(),m2.begin(),m2.end(),ptout());
}
