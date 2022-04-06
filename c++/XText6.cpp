#include "pt4.h"
#include <fstream>
#include <string>

using namespace std;

void Solve()
{
    Task("XText6");

	string s1; pt >> s1; string s2; pt >> s2;
	fstream f1; f1.open(s1, ios::binary | /*ios :: in |*/ ios :: out | ios :: app);//app?
	fstream f2; f2.open(s2, ios::binary | ios :: in);

	while (f2.peek() != -1){
		string tmp;
		//f2 >>tmp;
		getline(f2,tmp);
		Show(tmp);
		//if (tmp == "") return;
		f1 << tmp << '\n';	
	}
	
	f1.close();
	f2.close();
}
