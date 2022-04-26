#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <vector>
#include <deque>
#include <list>
#include <functional>
typedef ptin_iterator<int> ptin;
typedef ptout_iterator<int> ptout;


void Solve()
{
    Task("STL3Alg39");
    vector<int> V(ptin(0), ptin());
    
    vector<int> tmp(V.size()/2);
    partial_sort_copy(V.begin(),V.end(),tmp.begin(),tmp.end());
    V.insert(V.end(),tmp.begin(),tmp.end());

    Show(V.begin(), V.end(), "V: ");
    copy(V.begin(), V.end(), ptout());
}
