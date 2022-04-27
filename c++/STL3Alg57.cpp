#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <vector>
#include <deque>
#include <list>
#include <functional>
#include <numeric>
#include <string>
typedef ptin_iterator<string> ptin;

string conc_first(string x,string y){
	char tmp = y[0];
	string ans = x;
	ans += tmp;
	return ans;
}

void Solve()
{
    Task("STL3Alg57");
    vector<string> V(ptin(0), ptin());
    string s = "";
    string ans = accumulate(V.rbegin(),V.rend(),s,conc_first);
	pt << ans;
}
