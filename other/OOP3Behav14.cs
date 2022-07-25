// File: "OOP3Behav14"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Request
        {
            public abstract string ToStr();
        }
        public class RequestA: Request {
            int param;
            public RequestA(int param) { this.param = param; }
            public int GetParam() { return param; }
            public override string ToStr() { return "A:" + param.ToString(); }
        }
        public class RequestB: Request {
            string param;
            public RequestB(string param) { this.param = param; }
            public string GetParam() { return param; }
            public override string ToStr() { return "B:" + param; }
        }

        // Implement the RequestA and RequestB descendant classes

        public class Handler
        {
            Handler successor;
            public Handler(Handler successor)
            {
                this.successor = successor;
            }
            public virtual void HandleRequest(Request req)
            {
                if(successor != null) {
                    successor.HandleRequest(req);
                }
                else {
                    string temp = req.ToStr();
                    string res = "Request " + temp + " not processed";
                    Put(res);
                }
                // Implement the method
            }
        }
        public class HandlerA: Handler {
            int id;
            int param1, param2;
            public HandlerA(Handler successor, int id, int param1, int param2) :base(successor) {
                this.id = id;
                this.param1 = param1;
                this.param2 = param2;
            }
            public override void HandleRequest(Request req) {
                if(req.GetType() == typeof(RequestA)) {
                    var temp = req.ToStr();
                    var rr = temp.Substring(2);
                    int param = int.Parse(rr);
                    if(param >= param1 && param <= param2) {
                        string tempres = req.ToStr();
                        string res = "Request " + tempres + " processed by handler " + id.ToString();
                        Put(res);
                    }
                    else {
                        base.HandleRequest(req);
                    }
                }
                else {
                    base.HandleRequest(req);
                }
            }
        }
        public class HandlerB: Handler {
            int id;
            string param1, param2;
            public HandlerB(Handler successor, int id, string param1, string param2) :base(successor) {
                this.id = id;
                this.param1 = param1;
                this.param2 = param2;
            }
            public override void HandleRequest(Request req) {
                if(req.GetType() == typeof(RequestB)) {
                    var temp = req.ToStr();
                    var rr = temp.Substring(2);
                    if(String.Compare(param1, rr) != 1 && String.Compare(rr, param2) != 1) {
                        string tempres = req.ToStr();
                        string res = "Request " + tempres + " processed by handler " + id.ToString();
                        Put(res);
                    }
                    else {
                        base.HandleRequest(req);
                    }
                }
                else {
                    base.HandleRequest(req);
                }
            }
        }

        // Implement the HandlerA and HandlerB descendant classes

        public class Client
        {
            Handler h;
            public Client(Handler h)
            {
                this.h = h;
            }
            public void SendRequest(Request req)
            {
                h.HandleRequest(req);
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav14");

            int n = GetInt();

            Handler h = new Handler(null);
            for(int i = 0; i < n; ++i) {
                char c = GetChar();
                if(c == 'A') {
                    int param1 = GetInt();
                    int param2 = GetInt();
                    h = new HandlerA(h, i, param1, param2);
                } else {
                    string param1 = GetString();
                    string param2 = GetString();
                    h = new HandlerB(h, i, param1, param2);
                }
            }

            Client cli = new Client(h);

            int k = GetInt();
            for(int i = 0; i < k; ++i) {
                char c = GetChar();
                if(c == 'A') {
                    int p = GetInt();
                    Request req = new RequestA(p);
                    cli.SendRequest(req);
                }
                else {
                    string p = GetString();
                    Request req = new RequestB(p);
                    cli.SendRequest(req);
                }
            }

        }
    }
}
