#include "pt4.h"
using namespace std;

/*
��� ���������� ������ Singleton (� ����������� ���) � ����� �++
���������� �������� �������� �� ������ �����������,
�� � ���������� ������. ���, � ���������, �� ��������
������� ��������� ��������� �������� delete � �������������
���������� ������� Instance (� ��� ����� ��������� �����������
������ uniqueInstance). ����� ����, ������� ���������
����������� ������ ����������� ����������� ������� (� ��� �����
�������� ��� ������ ��� ����������).
*/

class BaseClass
{
    int data = 0;
public:
    void IncData(int increment);
    int GetData();
};

void BaseClass::IncData(int increment)
{
    data += increment;
}
int BaseClass::GetData()
{
    return data;
}

class Singleton : public BaseClass
{
    static Singleton* uniqueInstance;
    Singleton() {}
    ~Singleton() {}
public:
	static Singleton* getInstance() {
        if(!uniqueInstance)           
            uniqueInstance = new Singleton();
        return uniqueInstance;
    }
    
    static int instanceCount(){
		return uniqueInstance ? 1 : 0;
	}
    // ��������� ���������� ������ Singleton
};

Singleton* Singleton::uniqueInstance = nullptr;

class Doubleton : public BaseClass
{
    static Doubleton* instances[];
    Doubleton() {}
    ~Doubleton() {}
public:
	static Doubleton* getInstance(int ind) {
		if (ind < 2 ) {
        	if(!instances[ind]){
				//for (int i=0;i<2;i++)
				 instances[ind] = new Doubleton();
			}
        	return instances[ind];
		}
		return NULL;
    }
    
    static int instanceCount(){
		int ans = 0;
		for (int i=0;i<2;i++) if (instances[i]) ans++;
		return ans;
	}
    // ��������� ���������� ������ Doubleton
};

Doubleton* Doubleton::instances[2];

class Tenton : public BaseClass
{
    static Tenton* instances[];
    Tenton() {}
    ~Tenton() {}
public:
	static Tenton* getInstance(int ind) {
		Show("!!"); Show(ind);Show("!!");
		if (ind < 10 ) {
        	if(!instances[ind]){
				//for (int i=0;i<10;i++)
				 instances[ind] = new Tenton();
			}

        	return instances[ind];
		}
		return NULL;
    }
    
    static int instanceCount(){
		int ans = 0;
		for (int i=0;i<10;i++) if (instances[i]) ans++;
		return ans;
	}
    // ��������� ���������� ������ Tenton
};

Tenton* Tenton::instances[10];


void Solve()
{
    Task("OOP1Creat6");
	int n;
    pt >> n;
    BaseClass** ans = new BaseClass* [n];
    for (int i=0;i<n;i++){
		string tmp;
		pt >> tmp;
		if (tmp.front()=='S')  ans[i] = Singleton::getInstance();
		else if (tmp.front()=='D') ans[i] = Doubleton::getInstance(tmp[1]-'0'-1);
		else if (tmp.front()=='T') ans[i] = Tenton::getInstance(tmp[1]-'0');
	}
	pt << Singleton::instanceCount() << Doubleton::instanceCount() << Tenton::instanceCount();
	Show("i'm alive");
	
	int k;	pt >> k;
	for (int i=0;i<k;i++){
		int tmp1,tmp2;
		pt >> tmp1 >> tmp2;
		Show(tmp1);Show(tmp2);
		ans[tmp1]->IncData(tmp2);
		
	}
	
	for (int i=0;i<n;i++) pt << ans[i]->GetData();
//
}
