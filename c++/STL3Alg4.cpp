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

bool less_t_zero(int x){
	if (x < 0) return true;
	else return false;
}

void Solve()
{
    Task("STL3Alg4");
    list<int> L(ptin(0), ptin());
	list<int>::iterator it =find_if(L.begin(),L.end(),less_t_zero);it++;
	list<int>::iterator it2 =find_if(it,L.end(),less_t_zero);
	if (it != L.begin()) L.erase(it,it2);
	
	
    Show(L.begin(), L.end(), "L: ");
    copy(L.begin(), L.end(), ptout());
}
