#include "pt4.h"
using namespace std;

#include <algorithm>
#include <iterator>
#include <string>
#include <cctype>

void fun(char& x){
	if (isdigit(x))	x = '*';
	else if (isalpha(x) && isupper(x)) x = tolower(x);
	else if (isalpha(x) && islower(x)) x = toupper(x);
	return; 
}

void Solve()
{
    Task("STL4Str23");
    string s; pt >> s;
    for_each(s.begin(),s.end(),fun);
	Show(s);
	pt << s;
}
