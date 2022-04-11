#include "pt4.h"
using namespace std;

#include <vector>
#include <iterator>

class OperationA
{
public:
    static void ActionA();
    static void UndoActionA();
};

void OperationA::ActionA()
{
    pt << "+A";
}
void OperationA::UndoActionA()
{
    pt << "-A";
}

class OperationB
{
public:
    static void ActionB();
    static void UndoActionB();
};

void OperationB::ActionB()
{
    pt << "+B";
}
void OperationB::UndoActionB()
{
    pt << "-B";
}

class OperationC
{
public:
    static void ActionC();
    static void UndoActionC();
};

void OperationC::ActionC()
{
    pt << "+C";
}
void OperationC::UndoActionC()
{
    pt << "-C";
}

class Command
{
public:
    virtual void Execute() = 0;
    virtual void Unexecute() = 0;
};

class CommandA : public Command
{
public:
    void Execute() {
    	OperationA().ActionA();
	};
    void Unexecute() {
    	OperationA().UndoActionA();
	};
};

class CommandB : public Command
{
public:
    void Execute() {
    	OperationB().ActionB();
	};
    void Unexecute() {
    	OperationB().UndoActionB();
	};
};

class CommandC : public Command
{
public:
    void Execute() {
    	OperationC().ActionC();
	};
    void Unexecute() {
    	OperationC().UndoActionC();
	};
};

class MacroCommand : public Command{
	vector <Command*> v;
	public:
		MacroCommand(vector <Command*> s){
			// TODO
			v = s;
		}
		void Execute() {
		//
		for (auto i = v.begin(); i != v.end(); i++) (*i)->Execute();
		//	
		};
		void Unexecute() {
		//
		for (auto i = v.rbegin(); i != v.rend(); i++) (*i)->Unexecute();
		//	
		};
};

// пеюкхгсире йкюяяш-онрнлйх CommandA,
//   CommandB, CommandC х MacroCommand

class Menu
{
    // днаюбэре менаундхлше онкъ
    vector <Command*> Availcmd;
    vector <Command*> Lastcmd;
    int undoIndex = -1;
public:
    Menu(Command* cmd1, Command* cmd2);
    void Invoke(int cmdIndex);
    void Undo(int count);
    void Redo(int count);
};

Menu::Menu(Command* cmd1, Command* cmd2)
{
	Availcmd.push_back(cmd1);Availcmd.push_back(cmd2);
	Availcmd.push_back(new MacroCommand(vector <Command*> {cmd1,cmd2}));
    // пеюкхгсире йнмярпсйрнп
}
void Menu::Invoke(int cmdIndex)
{
	Availcmd[cmdIndex]->Execute();
	if (Lastcmd.size() > undoIndex + 1) Lastcmd.erase(Lastcmd.begin()+undoIndex+1,Lastcmd.end());
	Lastcmd.push_back(Availcmd[cmdIndex]);
	undoIndex = Lastcmd.size()-1;
	
    // пеюкхгсире лернд
}
void Menu::Undo(int count)
{Show('U');
	if (count > undoIndex){
		for (auto it = Lastcmd.rbegin()+(Lastcmd.size()-undoIndex-1 );it != Lastcmd.rend();it++){
			Show('!');
			(*it)->Unexecute();
			Show('!');
		}
		undoIndex = -1;
	} else {
		for (auto it = Lastcmd.begin()+undoIndex;it != Lastcmd.begin()+undoIndex-count;it--){
			Show('-');
			(*it)->Unexecute();
			Show('-');
		}
		undoIndex -= count ;
	}
    // пеюкхгсире лернд
}
void Menu::Redo(int count)
{Show('R');
	if (count > Lastcmd.size() - (undoIndex+1)){
		for (auto it = Lastcmd.begin()+undoIndex+1;it != Lastcmd.end();it++){
			(*it)->Execute();
		}
		undoIndex =  Lastcmd.size()-1;
	} else {
		for (auto it = Lastcmd.begin()+undoIndex+1;it != Lastcmd.begin()+undoIndex +count+1;it++){
			(*it)->Execute();
		}
		undoIndex += count;
	}
    // пеюкхгсире лернд
}

void Solve()
{
    Task("OOP3Behav9");
	char cmd1,cmd2;
	pt >> cmd1 >> cmd2;
	Command* com1;
	Command* com2;
	
	if (cmd1 == 'A') com1 = new CommandA();
	if (cmd1 == 'B') com1 = new CommandB();
	if (cmd1 == 'C') com1 = new CommandC();
	
	if (cmd2 == 'A') com2 = new CommandA();
	if (cmd2 == 'B') com2 = new CommandB();
	if (cmd2 == 'C') com2 = new CommandC();
	
	Menu men(com1,com2);
	
	int n; pt >> n;
	
	for (int i =0; i<n;i++){
		string tmp; pt >> tmp;
		if (tmp[0] == 'I'){
			men.Invoke(tmp[1]-'0');
		}
		if (tmp[0] == 'U'){
			men.Undo(tmp[1]-'0');
		}
		if (tmp[0] == 'R'){
			men.Redo(tmp[1]-'0');
		}
	}
}
