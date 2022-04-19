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
    Task("STL5Assoc3");
    vector<int> V0(ptin(0), ptin());
    int N;
    pt >> N;
	
	int k=0;
	multiset<int> M0(V0.begin(), V0.end());
	
    for (int i = 0; i < N; ++i)
    {
        vector<int> V(ptin(0), ptin());
        multiset<int> M(V.begin(), V.end());
		if (includes(M.begin(),M.end(),M0.begin(),M0.end())) k++;

    }
    pt << k;

}
