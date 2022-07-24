// File: "OOP3Behav9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static class ReceiverA
        {
            public static void ActionA()
            {
                Put("+A");
            }
            public static void UndoActionA()
            {
                Put("-A");
            }
        }

        public static class ReceiverB
        {
            public static void ActionB()
            {
                Put("+B");
            }
            public static void UndoActionB()
            {
                Put("-B");
            }
        }

        public static class ReceiverC
        {
            public static void ActionC()
            {
                Put("+C");
            }
            public static void UndoActionC()
            {
                Put("-C");
            }
        }

        public abstract class Command
        {
            public abstract void Execute();
            public abstract void Unexecute();
        }

        public class CommandA: Command {
            public override void Execute() {
                ReceiverA.ActionA();
            }
            public override void Unexecute() {
                ReceiverA.UndoActionA();
            }
        }
        public class CommandB: Command {
            public override void Execute() {
                ReceiverB.ActionB();
            }
            public override void Unexecute() {
                ReceiverB.UndoActionB();
            }
        }
        public class CommandC: Command {
            public override void Execute() {
                ReceiverC.ActionC();
            }
            public override void Unexecute() {
                ReceiverC.UndoActionC();
            }
        }
        public class MacroCommand: Command {
            Command[] cmd;
            public MacroCommand(Command[] cmd) {
                this.cmd = cmd;
            }
            public override void Execute() {
                for (int i = 0; i < cmd.Length; ++i) {
                    cmd[i].Execute();
                }
            }
            public override void Unexecute() {
                for (int i = cmd.Length - 1; i >= 0; --i) {
                    cmd[i].Unexecute();
                }
            }
        }

        // Implement the CommandA, CommandB, CommandC
        //   and MacroCommand descendant classes

        public class Menu
        {
            Command[] menuCmds = new Command[3];
            List<Command> lastCmds = new List<Command>();
            int undoIndex;
            // Add required fields
            public Menu(Command cmd1, Command cmd2)
            {
                menuCmds[0] = cmd1;
                menuCmds[1] = cmd2;
                Command[] temp = new Command[2]{cmd1, cmd2};
                menuCmds[2] = new MacroCommand(temp);
                // Implement the constructor
            }
            public void Invoke(int cmdIndex)
            {
                if(undoIndex + 1 <= lastCmds.Count - 1) {
                    var num = lastCmds.Count - undoIndex - 1;
                    for(int i = 0; i < num; ++i) {
                        lastCmds.RemoveAt(lastCmds.Count - 1);
                    }
                }
                menuCmds[cmdIndex].Execute();
                lastCmds.Add(menuCmds[cmdIndex]);
                undoIndex = lastCmds.Count - 1;
                ShowLine(undoIndex);
                // Implement the method
            }
            public void Undo(int count)
            {   
                if(count >= undoIndex + 1) {
                    var num = undoIndex;
                    for(int i = num; i >= 0; --i) {
                        lastCmds[undoIndex].Unexecute();
                        --undoIndex;
                    }
                    // if(undoIndex < 0 && lastCmds.Count > 1) {
                    //     undoIndex++;
                    // }
                }
                else if(count <= undoIndex + 1 && count < lastCmds.Count) {
                    for(int i = count - 1; i >= 0; --i) {
                        lastCmds[undoIndex].Unexecute();
                        --undoIndex;
                    }
                    // if(undoIndex < 0 && lastCmds.Count > 1) {
                    //     undoIndex++;
                    // }
                }
                ShowLine(undoIndex);
                // Implement the method
            }
            public void Redo(int count)
            {
                if(count > lastCmds.Count - undoIndex - 1) {
                    int num = lastCmds.Count - 1 - undoIndex;
                    for(int i = 0; i < num; ++i) {
                        lastCmds[undoIndex + 1].Execute();
                        undoIndex++;
                    }
                }
                else if(count <= lastCmds.Count - undoIndex - 1) {
                    for(int i = 0; i < count; ++i) {
                        lastCmds[undoIndex + 1].Execute();
                        undoIndex++;
                    }
                }
                ShowLine(undoIndex);
                // Implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav9");

            char c1 = GetChar();
            char c2 = GetChar();

            Command cmd1 = null;
            if(c1 == 'A')
                cmd1 = new CommandA();
            else if(c1 == 'B')
                cmd1 = new CommandB();
            else if(c1 == 'C')
                cmd1 = new CommandC();

            Command cmd2 = null;
            if(c2 == 'A')
                cmd2 = new CommandA();
            else if(c2 == 'B')
                cmd2 = new CommandB();
            else if(c2 == 'C')
                cmd2 = new CommandC();

            Menu m = new Menu(cmd1, cmd2);

            int n = GetInt();
            for(int i = 0; i < n; ++i) {
                string str = GetString();
                int num = (int)Char.GetNumericValue(str[1]);
                if(str[0] == 'I') {
                    m.Invoke(num);
                }
                else if(str[0] == 'U') {
                    m.Undo(num);
                }
                else if(str[0] == 'R') {
                    m.Redo(num);
                }

            }

        }
    }
}
