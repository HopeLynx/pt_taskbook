#include "pt4.h"
using namespace std;

#include <iterator>
#include <vector>
#include <set>
#include <map>
#include <functional>
#include <algorithm>

typedef ptin_iterator<string> ptin;

void Solve()
{
    Task("STL5Assoc18");
    vector<string> v(ptin(0), ptin());
	map<char,int> m;
	vector<string>::iterator it = v.begin();
	for (;it != v.end();it++){
		m[(*it)[0]] += (*it).size();
	}
	
	map<char,int>::iterator ans = m.begin();
	for(;ans != m.end();ans++){
		pt << (ans)->first << (ans)->second;
	}
}
