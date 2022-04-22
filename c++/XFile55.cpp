#include "pt4.h"
#include <vector>
#include <fstream>
#include <stdio.h>
using namespace std;

void Solve()
{
    Task("XFile55");
	string out; pt >> out; 
	fstream fout; fout.open(out, ios::binary | ios :: out);
	int n; pt >> n;
	fstream *f = new fstream[n];
	for (int i=0;i<n;i++){
		string s;
		pt>>s;
		f[i].open(s,ios::binary | ios :: in);
		vector <int> v;
		while (f[i].peek() != -1){
		int x;
		f[i].read((char*)&x,sizeof(x));
		v.push_back(x);
		}
		f[i].close();
		int x = v.size();
		fout.write((char*)&x,sizeof(x));
		for(int i=0; i<v.size();i++) {
		int x = v[i];
		fout.write((char*)&x,sizeof(x));
		}
	}
	fout.close();
	delete[] f;
}
