#include "pt4.h"
#include <fstream>
#include <string>

using namespace std;

void Solve()
{
    Task("XText49");
    
	string in; pt >> in;
	string in_int; pt >> in_int;
	string out = "file.tmp";
	fstream fin; fin.open(in, ios::binary | ios :: in);
	fstream fin_int; fin_int.open(in_int, ios::binary | ios :: in);
	fstream fout; fout.open(out, ios::binary | ios :: out);

	while (fin.peek() != -1){
		string tmp;
		getline(fin,tmp);
		
		if (fin_int.peek() != -1){
			int x;
			fin_int.read((char*)&x,sizeof(x));
			fout << tmp << to_string(x) << '\n';
			Show(tmp);Show(to_string(x));
		} else {
			fout << tmp << '\n';	
		}
	}
	
	fin.close();
	fin_int.close();
	fout.close();
	remove(in.c_str());
	rename(out.c_str(),in.c_str());
}
