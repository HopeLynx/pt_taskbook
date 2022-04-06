#include "pt4.h"
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <iterator>

using namespace std;

void Solve()
{
    Task("XText55");
    
	string in; pt >> in;
	string out; pt >> out;
	fstream fin; fin.open(in, ios::binary | ios :: in);
	fstream fout; fout.open(out, ios::binary | ios :: out);

	vector<char> v;
	while (fin.peek() != -1){
		string tmp;
		getline(fin,tmp);
		for (int i=0;i<tmp.length();i++) v.push_back(tmp[i]);
	}
		//Show(v[1]);
		sort(v.begin(),v.end());
		vector<char>::iterator it = unique(v.begin(),v.end());
		v.resize(distance(v.begin(),it));it = v.begin();it++;
		for(;it!=v.end();it++) {
			char x = *it;
			Show(x);
			fout.write((char*)&x,sizeof(x));
		}
	
	fin.close();
	fout.close();
}


