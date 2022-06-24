// File: "OOP3Behav10"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class State
        {
            public abstract string GetNextToken();
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ ConcreteStateNormal,
        //   ConcreteStateString, ConcreteStateComm
        //   И ConcreteStateFin

        // РЕАЛИЗУЙТЕ КЛАСС Context

        public static void Solve()
        {
            Task("OOP3Behav10");

        }
    }
}
