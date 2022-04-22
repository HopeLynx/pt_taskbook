#include "pt4.h"
#include <vector>
#include <fstream>

using namespace std;

void Solve()
{
    Task("XFile10");
    string in; pt >> in;
    string out; pt >> out;
	ifstream fin;fin.open(in,ios::binary | ios::in);
	ofstream fout;fout.open(out,ios::binary | ios::out);
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
		vector<int>::reverse_iterator rit = v.rbegin();
		for(; rit!=v.rend();rit++) {
		int x = *rit;	
		fout.write((char*)&x,sizeof(x));
		}
	}
	fout.close();
}
