#include "pt4.h"
using namespace std;

#include<vector>
#include<string>
#include<iterator>

class TextView
{
    // ÍÅ ÈÇÌÅÍßÉÒÅ ÐÅÀËÈÇÀÖÈÞ ÄÀÍÍÎÃÎ ÊËÀÑÑÀ
    int x = 0, y = 0;
    int width = 1, height = 1;
public:
    void GetOrigin(int& x, int& y);
    void SetOrigin(int x, int y);
    void GetSize(int& width, int& height);
    void SetSize(int width, int height);
};

void TextView::GetOrigin(int& x, int& y)
{
    x = this->x;
    y = this->y;
}
void TextView::SetOrigin(int x1, int y1)
{
    this->x = x1;
    this->y = y1;
}
void TextView::GetSize(int& width, int& height)
{
    width = this->width;
    height = this->height;
}
void TextView::SetSize(int w, int h)
{
    this->width = w;
    this->height = h;
}

class Shape
{
public:
    virtual string GetInfo() = 0;
    virtual void MoveBy(int a, int b) = 0;
};

// ÐÅÀËÈÇÓÉÒÅ ÊËÀÑÑÛ RectShape È TextShape,
//   ÈÑÏÎËÜÇÓß ÄËß ÊËÀÑÑÀ TextShape ÌÍÎÆÅÑÒÂÅÍÍÎÅ
//   ÍÀÑËÅÄÎÂÀÍÈÅ (ÎÒ ÊËÀÑÑÎÂ Shape È TextView)
/*
class RectShape : public Shape,TextView {
public:
	string GetInfo() {
		int f,t;GetOrigin(f,t);
		int w,h;GetSize(w,h);
		string ans = "R("; ans+= to_string(f);ans+=",";
		ans+=to_string(t);ans+=")(";ans+=to_string(w);
		ans+=",";ans+=to_string(h);ans+=")";
	};
	void MoveBy(int a, int b) {
		int x,y,w,h;
		GetOrigin(x,y);GetSize(w,h);
		x+=a;y+=b;w+=a;h+=b;
		SetOrigin(x,y);SetSize(w,h);
	};
};
*/

class RectShape : public Shape {
	int x1=0,y1=0,x2=0,y2=0;
public:
	string GetInfo() {
		/*
		int f,t;tview->GetOrigin(f,t);
		int w,h;tview->GetSize(w,h);
		string ans = "R("; ans+= to_string(f);ans+=",";
		ans+=to_string(t);ans+=")(";ans+=to_string(w);
		ans+=",";ans+=to_string(h);ans+=")";
		*/
		string ans = "R("; ans+= to_string(x1);ans+=",";
		ans+=to_string(y1);ans+=")(";ans+=to_string(x2);
		ans+=",";ans+=to_string(y2);ans+=")";
		return ans;
	};
	void MoveBy(int a, int b) {
		/*
		int x,y,w,h;
		tview->GetOrigin(x,y);tview->GetSize(w,h);
		Show(x);Show(y);Show(w);Show(h);
		x+=a;y+=b;w+=a;h+=b;
		tview->SetOrigin(x,y);tview->SetSize(w,h);
		Show(x);Show(y);Show(w);Show(h);
		*/
		x1 += a;y1 += b;
		x2 += a;y2 += b;
	};
	/*
		RectShape (TextView* tw){
		tview = tw;
	};
	*/
	RectShape (int x1_,int y1_, int x2_,int y2_){
		/*
		int tmp1,tmp2;tw->GetOrigin(tmp1,tmp2);Show(tmp1);Show(tmp2);
		tview = tw;
		tview->GetOrigin(tmp1,tmp2);Show(tmp1);Show(tmp2);
		*/
		x1 = x1_;
		y1 = y1_;
		x2 = x2_;
		y2 = y2_;
		//TextView* tw = new TextView();
		//Show("lol");
		//tw->SetOrigin(x1,y1);
		//tw->SetSize(h1,w1);
		//Show("pop");
		//tview = tw;
		
	};
};


// ÿ ìîãó ñäåëàòü êàê óãîäíî,
// íî èç çàäàíèÿ íå ïîíÿòíî êàê èìåííî íàäî áûëî
class TextShape : public Shape {
	int x1=0,y1=0,x2=0,y2=0;
	TextView tview;
public:
	string GetInfo() {
		//int f,t;tview->GetOrigin(f,t);
		//int w,h;tview->GetSize(w,h);
		/*
		string ans = "T("; ans+= to_string(f);ans+=",";
		ans+=to_string(t);ans+=")(";ans+=to_string(w);
		ans+=",";ans+=to_string(h);ans+=")";
		*/
		string ans = "T("; ans+= to_string(x1);ans+=",";
		ans+=to_string(y1);ans+=")(";ans+=to_string(x2);
		ans+=",";ans+=to_string(y2);ans+=")";
		return ans;
	};
	void MoveBy(int a, int b) {
		//int x,y,w,h;
		x1 += a;y1 += b;
		x2 += a;y2 += b;
		
		//tview->GetOrigin(x,y);tview->GetSize(w,h);
		
		//tview->SetOrigin(x,y);tview->SetSize(w,h);
	};
	TextShape (TextView tw,int x1_,int y1_, int x2_,int y2_){
		/*
		int tmp1,tmp2;tw->GetOrigin(tmp1,tmp2);Show(tmp1);Show(tmp2);
		tview = tw;
		tview->GetOrigin(tmp1,tmp2);Show(tmp1);Show(tmp2);
		*/
		tview = tw;
		x1 = x1_;
		y1 = y1_;
		x2 = x2_;
		y2 = y2_;
		//TextView* tw = new TextView();
		//Show("lol");
		//tw->SetOrigin(x1,y1);
		//tw->SetSize(h1,w1);
		//Show("pop");
		//tview = tw;
		
	};
};

void Solve()
{
    Task("OOP2Struc4");
	int n; pt >> n;
	//Shape* sp = new ;
	vector <Shape*> sp;
	//TextView* tw;
	Shape* sh;
	for (int i=0; i<n; i++){
		char c; int x1,y1,w1,h1;
		pt >> c >> x1 >> y1 >> w1 >> h1;
		Show(1);
				
		if (c == 'T') {	
		sh = new TextShape((TextView()),x1,y1,w1,h1); Show("t");
		}
		else if (c == 'R') {
		sh = new RectShape(x1,y1,w1,h1);
		Show("r");	
		}
		//int tmp1,tmp2;sh->tview->GetOrigin(tmp1,tmp2);Show(tmp1);Show(tmp2);
		sp.push_back(sh);
		Show("!!!!!");
		//sp[i] = sh;
	}
	int a,b; pt >> a >> b;
	for (int i=0;i<n;i++){
		Show("damn");
		Show (sp[i]->GetInfo());
		sp[i]->MoveBy(a,b);
		Show (sp[i]->GetInfo());
		pt << sp[i]->GetInfo();
	}
	
}
