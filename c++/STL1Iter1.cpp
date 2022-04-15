#include "pt4.h"
#include <algorithm>
#include <iterator>

using namespace std;

typedef ptin_iterator<int> ptin;

void Solve()
{
    Task("STL1Iter1");
    pt << count(ptin(0),ptin(),0);

}
