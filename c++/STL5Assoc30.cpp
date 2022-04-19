#include "pt4.h"
using namespace std;

#include <iterator>
#include <vector>
#include <set>
#include <map>
#include <functional>
#include <algorithm>

typedef ptin_iterator<int> ptin;

void Solve()
{
    Task("STL5Assoc30");
    vector<int> v1(ptin(0), ptin());
    vector<int> v2(ptin(0), ptin());
    
    multimap<int,int> mm;
    for (auto it = v2.begin();it!=v2.end();it++){
	    mm.insert(pair<int,int>(abs((*it)%10),*it));	
	}
	
	vector<int> v;
	
	for (auto it = v1.begin();it!=v1.end();it++){
		auto range = mm.equal_range(abs((*it)%10));
		for (auto i = range.first; i!=range.second;++i){
			v.insert(v.end(),(*it));
			v.insert(v.end(),i->second);
		} 
	}
	pt << int(v.size()/2); Show(int(v.size()/2));
	for (auto it= v.begin(); it != v.end();it++) pt << (*it);
	

}
