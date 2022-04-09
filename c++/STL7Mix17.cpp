#include "pt4.h"
using namespace std;

#include <fstream>
#include <sstream>
#include <iomanip>
#include <algorithm>
#include <vector>
#include <set>
#include <map>
struct Data
{
    int num, year;
    string fam;
    operator string()
    {
        ostringstream os;
        os << "{ num = " << num << ", year = " << year
            << ", fam = " << fam << " }";
        return os.str();
    }
};

istream& operator>>(istream& is, Data& p)
{
    return is >> p.num >> p.year >> p.fam;
}

bool cmp (pair<int,set<int>> const & a, pair<int,set<int>> const & b) 
{ 
    return int(a.second.size()) != int(b.second.size())?  int(a.second.size()) < int(b.second.size()) : a.first < b.first;
};

void Solve()
{
    Task("STL7Mix17");
    string name1, name2;
    pt >> name1 >> name2;
    ifstream f1(name1.c_str());
    vector<Data> V((istream_iterator<Data>(f1)), istream_iterator<Data>());
    f1.close();
    ShowLine(V.begin(), V.end(), "V: ");

	map<int,set<int>> ms;

	for (auto it:V){
		ms[it.year].insert(it.num);
	} //Show(int(ms[2001].size())); 
	
	//sort(ms.begin(),ms.end(),cmp);
	
	multimap<int,int> ans;
	for (auto it:ms){
		ans.insert(pair<int,int>(int(it.second.size()),it.first));
	}
	

    ofstream f2(name2.c_str());
	for (auto it:ans) f2 << it.first << " " << it.second << endl;
    f2.close();
}
