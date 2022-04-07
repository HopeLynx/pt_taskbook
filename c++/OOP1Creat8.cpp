#include <iterator>
#include <vector>
#include <sstream>

#include "pt4.h"
using namespace std;


string join(const vector<string>& vec, const char* delim)
{
    stringstream res;
    copy(vec.begin(), vec.end(), ostream_iterator<string>(res, delim));
    // need to pop back to delete extra delim
    Show(res.str());
    string ans = res.str();
    ans.pop_back();
    return ans;
}

class AbstractGraphic
{
public:
    virtual AbstractGraphic* Clone() = 0;
    virtual void ChangeLocation(int x1, int y1, int x2, int y2) = 0;
    virtual string Draw() = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » Ellip, Line » Rect

class Ellip : public AbstractGraphic {
	int x1=0,y1=0,x2=0,y2=0;
	public:
		AbstractGraphic* Clone() {
			return new Ellip(*this);
		};
		void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		};
		string Draw() {
			string ans = "Ellip(";
			ans+=to_string(x1); ans+=","; ans+=to_string(y1); ans+=",";
			ans+=to_string(x2); ans+=","; ans+=to_string(y2);
			ans += ")";
			Show (ans);
		return ans;
		};
};

class Line : public AbstractGraphic {
	int x1=0,y1=0,x2=0,y2=0;
	public:
		AbstractGraphic* Clone() {
			return new Line(*this);
		};
		void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		};
		string Draw() {
			string ans = "Line(";
			ans+=to_string(x1); ans+=","; ans+=to_string(y1); ans+=",";
			ans+=to_string(x2); ans+=","; ans+=to_string(y2);
			ans += ")";
			Show (ans);
		return ans;
		};
};

class Rect : public AbstractGraphic {
	int x1=0,y1=0,x2=0,y2=0;
	public:
		AbstractGraphic* Clone() {
			return new Rect(*this);
		};
		void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		};
		string Draw() {
			string ans = "Rect(";
			ans+=to_string(x1); ans+=","; ans+=to_string(y1); ans+=",";
			ans+=to_string(x2); ans+=","; ans+=to_string(y2);
			ans += ")";
			Show (ans);
		return ans;
		};
};


class GraphEditor
{
	vector <string> Drawings;
	AbstractGraphic* params[2];
    // ƒŒ¡¿¬‹“≈ Õ≈Œ¡’Œƒ»Ã€≈ œŒÀﬂ
public:
    GraphEditor(AbstractGraphic* p1, AbstractGraphic* p2);
    ~GraphEditor();
    void AddGraphic(int np, int x1, int y1, int x2, int y2);
    string DrawAll();
};

GraphEditor::GraphEditor(AbstractGraphic* p1, AbstractGraphic* p2)
{
	params[0] =  p1->Clone();
	params[1] =  p2->Clone();
	//param1 = p1->Clone();
	//param2 = p2->Clone();
    // –≈¿À»«”…“≈  ŒÕ—“–” “Œ–
}
GraphEditor::~GraphEditor()
{
//	delete params;
	//delete param2;
	Drawings.clear();
    // –≈¿À»«”…“≈ ƒ≈—“–” “Œ–
}
void GraphEditor::AddGraphic(int np, int x1, int y1, int x2, int y2)
{
	params[np-1]->ChangeLocation(x1,y1,x2,y2);
	Drawings.push_back(params[np-1]->Draw());
    // –≈¿À»«”…“≈ Ã≈“Œƒ
}
string GraphEditor::DrawAll()
{
    return join(Drawings," ");
    // ”ƒ¿À»“≈ œ–≈ƒ€ƒ”Ÿ»… Œœ≈–¿“Œ– » –≈¿À»«”…“≈ Ã≈“Œƒ
};

void Solve()
{
    Task("OOP1Creat8");
    string tmp; int n;
	pt >> tmp >> n;
	
	AbstractGraphic* pt1; 
	if (tmp.front() == 'R') pt1 = (new Rect)->Clone();
	else if (tmp.front() == 'E') pt1 = (new Ellip)->Clone();
	else if (tmp.front() == 'L') pt1 = (new Line)->Clone();
	
	AbstractGraphic* pt2; 
	if (tmp.back() == 'R') pt2 = (new Rect)->Clone();
	else if (tmp.back() == 'E') pt2 = (new Ellip)->Clone();
	else if (tmp.back() == 'L') pt2 = (new Line)->Clone();
	
	GraphEditor ge(pt1,pt2);
	
	for (int i=0;i<n;i++) {
		int np,x1,y1,x2,y2;
		pt >> np >> x1 >> y1 >> x2 >> y2;
		ge.AddGraphic(np,x1,y1,x2,y2);
	}
	
	pt << ge.DrawAll();
}
