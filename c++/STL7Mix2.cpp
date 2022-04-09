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
    int code, year, month, len;
    operator string()
    {
        ostringstream os;
        os << "{ code = " << code << ", year = " << year
            << ", month = " << month << ", len = " << len << " }";
        return os.str();
    }
};

istream& operator>>(istream& is, Data& p)
{
    return is >> p.month >> p.year >> p.code >> p.len;
}

void Solve()
{
    Task("STL7Mix2");
    string name1, name2;
    pt >> name1 >> name2;
    ifstream f1(name1.c_str());
    vector<Data> V((istream_iterator<Data>(f1)), istream_iterator<Data>());
    f1.close();
    ShowLine(V.begin(), V.end(), "V: ");
    
    int max = -1;
    for (auto it:V){
    	if (it.len > max) max = it.len;
	}
	
	vector<Data> vec;
	for (auto it:V){
		if (max == it.len) vec.insert(vec.end(),it);
	}
	max = -1;
    for (auto it:vec){
    	if (it.year*100+it.month > max) max = it.year*100+it.month;
	}
	
    ofstream f2(name2.c_str());
    
	for (auto it:vec){
    	if (it.year*100+it.month == max) {
    		f2 << it.len << " "<< it.year << " "<< it.month;		
		}
	}
	
    f2.close();
}
