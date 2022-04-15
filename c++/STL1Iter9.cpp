#include "pt4.h"
#include <algorithm>
#include <iterator>
#include <vector>
#include <string>
#include <fstream>

using namespace std;

//typedef ptin_iterator<int> ptin;
typedef ptout_iterator<int> ptout;

const vector<string> my_split(const string& s, const char& c)
{
	string buff{""};
	vector<string> v;
	for(auto n:s){
		if(n != c) buff+=n;
		else if(n == c && buff != "") { v.push_back(buff); buff = ""; }
	}
	if(buff != "") v.push_back(buff);
	return v;
}

void Solve()
{
    Task("STL1Iter9");
    
    string in; pt >> in;
    fstream fin; fin.open(in, ios::binary | ios :: in);
    istream_iterator<int> my_it(fin);
    /*
	vector<string> v;
    for (;my_it != istream_iterator<string>();my_it++) v.push_back(*my_it);
    
	vector<int> spl;
    
	for (int i=0;i<v.size();i++){
    	vector<string> tmp{my_split(v[i],' ')};
			for (int j=0;j<tmp.size();j++)	spl.push_back(stoi(tmp[j]));
	}
	
    int num = 1;
    remove_copy_if(spl.begin(),spl.end(),ptout(),[&num](int e){return num++ % 2 == 0;});
	*/

	int num = 1;
    remove_copy_if(my_it,istream_iterator<int>(),ptout(),[&num](int e){return num++ % 2 == 0;});
}
