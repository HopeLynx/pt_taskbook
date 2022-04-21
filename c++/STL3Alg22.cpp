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
    Task("STL3Alg22");
    int k;
    pt >> k;
    list<int> L(ptin(0), ptin());
	list<int> tmp(5);
	list<int> ans;
    list<int>::iterator it = tmp.begin();
    list<int>::iterator it2 = tmp.end();
    
    it = L.begin();
    it2 = L.begin();
    advance(it,5-k);//right
    advance(it2,5);
	rotate_copy(L.begin(),it,it2,tmp.begin());
	
	ans.insert(ans.begin(),L.begin(),L.end());
	ans.insert(ans.end(),tmp.begin(),tmp.end());
	
	it = L.end();
    it2 = L.end();
    advance(it,k-5);//left
    advance(it2,-5);
	rotate_copy(it2,it,L.end(),tmp.begin());
	ans.insert(ans.begin(),tmp.begin(),tmp.end());
	
	Show(ans.begin(), ans.end(), "ans: ");
	
    copy(ans.begin(), ans.end(), ptout());
}
