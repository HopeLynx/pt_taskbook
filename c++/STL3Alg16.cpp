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
    Task("STL3Alg16");
    int a, b;
    pt >> a >> b;
    vector<int> V1(ptin(0), ptin());
    vector<int> V2(ptin(0), ptin());
    
    fill(V1.begin(),V1.begin()+5,a);
    fill(V1.end()-5,V1.end(),b);
    
    fill_n(V2.begin(),5,a);
    fill_n(V2.end()-5,5,b);

    Show(V1.begin(), V1.end(), "V1: ");
    Show(V2.begin(), V2.end(), "V2: ");
    copy(V1.begin(), V1.end(), ptout());
    copy(V2.begin(), V2.end(), ptout());
}
