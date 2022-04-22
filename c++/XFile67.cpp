#include "pt4.h"
#include <vector>
#include <fstream>

using namespace std;

int my_atoi(string str){
    int res = 0;
 
    for (int i = 0; str[i] != '\0'; ++i)
    	res = res * 10 + str[i] - '0';
	//if (isdigit(c)){
	//	res = c - '0';
	//}
    return res;
}

const vector<string> my_split(const string& s, const char& c)
{
	string buff{""};
	vector<string> v;
	for(auto n:s){
		if(n != c) buff+=n;
		else if(n == c && buff != "") { v.push_back(buff); buff = ""; }
	}
	if(buff != "") v.push_back(buff);
	return v;
}

void Solve()
{
    Task("XFile67");
	string in; pt >> in;
	fstream fin; fin.open(in, ios::binary | ios :: in);
	string d_out,m_out; pt >> d_out; pt >> m_out;
	fstream dout; dout.open(d_out, ios::binary | ios :: out);
	fstream mout; mout.open(m_out, ios::binary | ios :: out);

	
	
	while (!fin.eof()){
		string tmp;
		fin >> tmp;
		Show(tmp);
		if (tmp == "") return;
		vector<string> v{my_split(tmp, '/')};
		//if(dout.is_open()) Show("why1");if(mout.is_open()) Show("why2");
		int d = my_atoi(v[0]);Show(d);dout.write((char*)&d,sizeof(d));
		int m = my_atoi(v[1]);Show(m);mout.write((char*)&m,sizeof(m));
	}
	
	fin.close();
	dout.close();
	mout.close();
}
