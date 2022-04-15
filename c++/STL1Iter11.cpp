#include "pt4.h"
#include <algorithm>
#include <iterator>
#include <vector>
#include <string>
#include <fstream>

using namespace std;

//typedef ptin_iterator<int> ptin;
//typedef ptout_iterator<int> ptout;

/*
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
*/
void Solve()
{
    Task("STL1Iter11");
    
    string in; pt >> in;
    string out; pt >> out;
    fstream fin; fin.open(in, ios::binary | ios :: in);
    fstream fout; fout.open(out, ios::binary | ios :: out);
    istream_iterator<string> my_it(fin);
    ostream_iterator<string> my_out_it(fout,"\n");
    
	//vector<string> v;
    for (;my_it != istream_iterator<string>();my_it++){
		//v.push_back(*my_it);
		if (*my_it != "0")my_out_it = *my_it;
	} 
    /*
	vector<string> spl;
    
	for (int i=0;i<v.size();i++){
    	vector<string> tmp{my_split(v[i],' ')};
			for (int j=0;j<tmp.size();j++)	spl.push_back(tmp[j]);
	}
	*/
	
   // copy(spl.begin(),spl.end(),my_out_it);

}
