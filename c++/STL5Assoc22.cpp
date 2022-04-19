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
    Task("STL5Assoc22");
    vector<string>V(ptin(0), ptin());
    
    multimap<char,string>mm;
	
	//vector<string>::iterator
	auto it = V.rbegin();
	
	for (;it != V.rend();it++){
		//um[(*it)[0]] = (*it);
		mm.insert(pair<char,string>((*it)[0],*it));
	}
	for (auto mm_it:mm){
		pt << mm_it.first << mm_it.second;
	}

}
