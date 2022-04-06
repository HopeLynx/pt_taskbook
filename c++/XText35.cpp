#include "pt4.h"
#include <fstream>
#include <string>

using namespace std;

void Solve()
{
    Task("XText35");
	string in; pt >> in; string out = "file.tmp";
	fstream fin; fin.open(in, ios::binary | ios :: in);
	fstream fout; fout.open(out, ios::binary | ios :: out);

	while (fin.peek() != -1){
		string tmp;
		getline(fin,tmp);
		Show(tmp);int b = tmp.length(); Show(b);
		if (tmp != "" && tmp.length()>1) {
		int x = 50 - (tmp.length()-2);
		for (int i =0; i<x/2; i++) fout<<' ';
		}
		fout << tmp << '\n';	
	}
	
	fin.close();
	fout.close();
	remove(in.c_str());
	rename(out.c_str(),in.c_str());
}
