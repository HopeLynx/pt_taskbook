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

bool is_not_pos(int x){
	if (x<=0) return true;
	return false;
}

void Solve()
{
    Task("STL3Alg28");
    list<int> L(ptin(0), ptin());
    list<int>::iterator it = L.begin();
    advance(it,L.size()/2);
	remove_copy_if(it,L.end(),inserter(L,L.begin()),is_not_pos);

    Show(L.begin(), L.end(), "L: ");
    copy(L.begin(), L.end(), ptout());
}
