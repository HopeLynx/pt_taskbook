#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <vector>
#include <deque>
#include <list>
#include <functional>
#include <string>
typedef ptin_iterator<string> ptin;
typedef ptout_iterator<string> ptout;

bool my_comp(string i, string j){
	if(i.length() == j.length()){
		return i.compare(j) < 0;
	} else return i.length() > j.length();
}

void Solve()
{
    Task("STL3Alg46");
    deque<string> D(ptin(0), ptin());

	sort(D.begin(),D.end(),my_comp);

    Show(D.begin(), D.end(), "D: ");
    copy(D.begin(), D.end(), ptout());
}
