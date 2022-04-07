#include "pt4.h"
using namespace std;

class Builder
{
public:
    virtual void BuildStart() {}
    virtual void BuildPartA() {}
    virtual void BuildPartB() {}
    virtual void BuildPartC() {}
    virtual string GetResult() = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » ConcreteBuilder1 » ConcreteBuilder2

class ConcreteBuilder1 : public Builder{
	string product = "";
	void BuildStart() {product = "";};
	void BuildPartA() {product += "-1-";};
    void BuildPartB() {product += "-2-";};
    void BuildPartC() {product += "-3-";};
    string GetResult() {return product;};
};

class ConcreteBuilder2 : public Builder{
	string product = "";
	void BuildStart() {product = "";};
	void BuildPartA() {product += "=*=";};
    void BuildPartB() {product += "=**=";};
    void BuildPartC() {product += "=***=";};
    string GetResult() {return product;};
};

class Director
{
    Builder* b;
public:
    Director(Builder* b);
    string GetResult();
    void Construct(string templat);
};

Director::Director(Builder* b)
{
    this->b = b;
}
string Director::GetResult()
{
    return b->GetResult();
}
void Director::Construct(string templat)
{
	b->BuildStart();
	for (int i=0;i<templat.length();i++){
		if (templat[i]=='A') b->BuildPartA();
		else if (templat[i]=='B') b->BuildPartB();
		else if (templat[i]=='C') b->BuildPartC();
	}
    // –≈¿À»«”…“≈ Ã≈“Œƒ
}

void Solve()
{
    Task("OOP1Creat9");
    Director d1(new ConcreteBuilder1);
    Director d2(new ConcreteBuilder2);
    
    for(int i=0;i<5;i++){
    	string tmp;
		pt >> tmp;
		d1.Construct(tmp); d2.Construct(tmp);
		pt << d1.GetResult() << d2.GetResult();
	}

}
