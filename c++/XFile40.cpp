#include "pt4.h"
#include <vector>
#include <fstream>
#include <stdio.h>

using namespace std;

void Solve()
{
    Task("XFile40");
	string in; pt >> in;
    string out = "kek.tmp";
	ifstream fin;fin.open(in,ios::binary);
	ofstream fout;fout.open(out,ios::binary);
	vector <int> v;
	int n=0;
	if (fin.is_open()){
		while (fin.peek() != -1){
		int x;
		fin.read((char*)&x,sizeof(x));
		//Show(x);
		v.push_back(x);
		}
	}
	fin.close();
	if (fout.is_open()){
		for(int i=0; i<v.size();i++) {
		int x = v[i];
		Show(x);
		if (i % 2 == 0)	fout.write((char*)&x,sizeof(x));
		else {x = 0; fout.write((char*)&x,sizeof(x));fout.write((char*)&x,sizeof(x));}
		}
	}
	fout.close();
	remove(in.c_str());
	rename(out.c_str(),in.c_str());
}
