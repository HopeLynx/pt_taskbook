#include "pt4.h"
#include <fstream>
#include <string>
#include <cmath>

using namespace std;

void Solve()
{
    Task("XText45");

	string in; pt >> in;
	fstream fin; fin.open(in, ios::binary | ios :: in);
	int cnt = 0;
	double sum = 0;
	while (fin.peek() != -1){
		string tmp;
		getline(fin,tmp);
		
		double x = stod(tmp);
		Show(x); 
		double fr,intp;
		fr = modf(x,&intp);
		if (fr) {cnt++; sum+=x;}
	}
	pt << cnt;
	pt << sum; 
	
	fin.close();
}
