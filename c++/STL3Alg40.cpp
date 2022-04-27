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

bool is_not_Odd(int x){
	return x%2==0; 
} 

void Solve()
{
    Task("STL3Alg40");
    list<int> L(ptin(0), ptin());
    
    auto it = partition(L.begin(),L.end(),is_not_Odd);
    pt << distance(L.begin(),it);
    pt << distance(it,L.end());

    Show(L.begin(), L.end(), "L: ");
    //copy(L.begin(), L.end(), ptout());
}
