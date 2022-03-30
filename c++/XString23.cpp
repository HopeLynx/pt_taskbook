#include "pt4.h"
using namespace std;

int my_atoi(char c){
    int res = -1;
 
    //for (int i = 0; str[i] != '\0'; ++i)
    //  res = res * 10 + str[i] - '0';
	if (isdigit(c)){
		res = c - '0';
	}
    return res;
}

void Solve()
{
    Task("XString23");
	string s;
	pt >> s;
	int tmp=my_atoi(s[0]);
	if (tmp == -1)return;// pt << "error";
	int ans = tmp;
	for (int i=2;i<s.length();i+=2){
		tmp=my_atoi(s[i]);
		if (tmp == -1)return;// pt << "error";
		switch(s[i-1]){
			case '+': ans += tmp;break;
			case '-': ans -= tmp;break; 
		break;
		}

	}
	pt << ans;
	
}
