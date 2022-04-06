#include "pt4.h"
#include <fstream>
#include <string>
#include <cmath>

using namespace std;

void Solve()
{
    Task("XText40");

	string in; pt >> in;
	fstream fin; fin.open(in, ios::binary | ios :: in);
	while (fin.peek() != -1){
		string tmp;
		getline(fin,tmp);
		
		double x = stod(tmp);
		Show(x);
	}
	
	fin.close();
}
