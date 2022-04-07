#include "pt4.h"
#include <string>
#include <algorithm>
#include <iterator>
#include <vector>
#include <sstream>

using namespace std;

string join(const vector<string>& vec, const char* delim)
{
    stringstream res;
    copy(vec.begin(), vec.end(), ostream_iterator<string>(res, delim));
    return res.str();
    // need to pop back to delete extra delim
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

class AbstractButton
{
public:
    virtual string GetControl() = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » Button1 » Button2
class Button1 : public AbstractButton {
public:
	Button1(string new_text){
		string tmp_a = new_text;
		transform(tmp_a.begin(), tmp_a.end(), tmp_a.begin(), ::toupper);
		text = "[" + tmp_a + "]";
	}
private:
	string text;
protected:
    string GetControl() override;
};

class Button2 : public AbstractButton {
public:
	Button2(string new_text){
		string tmp_a = new_text;
		transform(tmp_a.begin(), tmp_a.end(), tmp_a.begin(), ::tolower);
		text = "<"+tmp_a+">";
	}
private:
	string text;
protected:
    string GetControl() override;
};

string Button1::GetControl(){
	return text;
}

string Button2::GetControl(){
	return text;
}


class AbstractLabel{
public:
    virtual string GetControl() = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » Label1 » Label2
class Label1 : public AbstractLabel {
public:
	Label1(string new_text){
		string tmp_a = new_text;
		transform(tmp_a.begin(), tmp_a.end(), tmp_a.begin(), ::toupper);
		text = "=" + tmp_a + "=";
	}
private:
	string text;
protected:
    string GetControl() override;
};

class Label2 : public AbstractLabel {
public:
	Label2(string new_text){
		string tmp_a = new_text;
		transform(tmp_a.begin(), tmp_a.end(), tmp_a.begin(), ::tolower);
		text = "\""+tmp_a+"\"";
	}
private:
	string text;
protected:
    string GetControl() override;
};

string Label1::GetControl(){
	return text;
}

string Label2::GetControl(){
	return text;
}

class ControlFactory
{
public:
    virtual AbstractButton* CreateButton(string new_text) = 0;
    virtual AbstractLabel* CreateLabel(string new_text) = 0;
};

// –≈¿À»«”…“≈  À¿——€-œŒ“ŒÃ » Factory1 » Factory2

class Factory1 : public ControlFactory {
protected:
	AbstractButton* CreateButton(string new_text) override;
	AbstractLabel* CreateLabel(string new_text) override;
};

class Factory2 : public ControlFactory {
protected:
	AbstractButton* CreateButton(string new_text) override;
	AbstractLabel* CreateLabel(string new_text) override;
};

AbstractButton* Factory1::CreateButton(string new_text){
	return new Button1(new_text);
}
AbstractLabel* Factory1::CreateLabel(string new_text){
	return new Label1(new_text);
}

AbstractButton* Factory2::CreateButton(string new_text){
	return new Button2(new_text);
}
AbstractLabel* Factory2::CreateLabel(string new_text){
	return new Label2(new_text);
}





class Client
{
    // ƒŒ¡¿¬‹“≈ Õ≈Œ¡’Œƒ»Ã€≈ œŒÀﬂ
    ControlFactory* controller;
    //vector<AbstractButton> buttons;
	//vector<AbstractLabel> labels; 
	vector<string> controls;
public:
    Client(ControlFactory* f);
    void AddButton(string text);
    void AddLabel(string text);
    string GetControls();
};

Client::Client(ControlFactory* f)
{
    // –≈¿À»«”…“≈  ŒÕ—“–” “Œ–
	controller = f;
}
void Client::AddButton(string text)
{
    // –≈¿À»«”…“≈ Ã≈“Œƒ
    //buttons.push_back(controller.CreateButton(text));
    controls.push_back(controller->CreateButton(text)->GetControl());
}
void Client::AddLabel(string text)
{
    // –≈¿À»«”…“≈ Ã≈“Œƒ
    //labels.push_back(controller.CreateLabel(text));
    controls.push_back(controller->CreateLabel(text)->GetControl());
}
string Client::GetControls()
{
    // return "";
    // ”ƒ¿À»“≈ œ–≈ƒ€ƒ”Ÿ»… Œœ≈–¿“Œ– » –≈¿À»«”…“≈ Ã≈“Œƒ
    const char* const delim = " ";
    string tmp = join(controls,delim);
    tmp.pop_back();
    return tmp;
}

void Solve()
{
    Task("OOP1Creat5");
    int n; pt >> n;
    
    Factory1* f1 = new Factory1();
	Factory2* f2 = new Factory2();
    Client c1(f1);
	Client c2(f2); 
    for (int i=0;i<n;i++){
    	string tmp; pt >> tmp;
		vector<string> strings {my_split(tmp,' ')};
		if (strings[0] == "L"){
			c1.AddLabel(strings[1]);
			c2.AddLabel(strings[1]);
		} else if (strings[0] == "B"){
			c1.AddButton(strings[1]);
			c2.AddButton(strings[1]);
		}
	}
	pt << c1.GetControls();
	pt << c2.GetControls();
}
