#include "pt4.h"
#include <algorithm>
#include <iterator>
#include <vector>
#include <string>
#include <fstream>

using namespace std;

void Solve()
{
    Task("STL1Iter18");
    
    string out; pt >> out;
    fstream fout; fout.open(out, ios::binary | ios :: out);
    ostream_iterator<string> my_out_it(fout);
	int k; pt >> k;
    fill_n(my_out_it,k,"*");

}
