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
    Task("STL3Alg10");
    list<int>   L(ptin(0), ptin());
    vector<int> D(ptin(0), ptin());
    
    vector<int>::iterator it;
	it = search(D.begin()+D.size()/2,D.end(),L.rbegin(),L.rend());
	if (it != D.end()) D.insert(it,L.rbegin(),L.rend());
	//it = D.begin()+D.size()/2;
    Show(D.begin(), D.end(), "D: ");
    copy(D.begin(), D.end(), ptout());
}
