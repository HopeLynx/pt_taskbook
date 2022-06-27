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

// РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ RequestA И RequestB
        public class RequestA: Request {
            int pr;
            public RequestA(int pr) { this.pr = pr; }
            public int GetParam() { return pr; }
            public override string ToStr() { return "A:" + pr.ToString(); }
        }
        public class RequestB: Request {
            string pr;
            public RequestB(string pr) { this.pr = pr; }
            public string GetParam() { return pr; }
            public override string ToStr() { return "B:" + pr; }
        }
        public class Handler
        {
            Handler sc;
            public Handler(Handler sc)
            {
                this.sc = sc;
            }
            public virtual void HandleRequest(Request req)
            {
                // РЕАЛИЗУЙТЕ МЕТОД
                if(sc != null) {
                    sc.HandleRequest(req);
                }
                else {
                    string tmp = req.ToStr();
                    string res = "Request " + tmp + " not processed";
                    Put(res);
                }
            }
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ HandlerA И HandlerB

        public class HandlerA: Handler {
            int id;
            int pr1, pr2;
            public HandlerA(Handler sc, int id, int pr1, int pr2) :base(sc) {this.id = id;this.pr1 = pr1;this.pr2 = pr2;}
            public override void HandleRequest(Request req) {
                if(req.GetType() == typeof(RequestA)) {
                    var tmp = req.ToStr();
                    var rr = tmp.Substring(2);
                    int pr = int.Parse(rr);
                    if(pr >= pr1 && pr <= pr2) {
                        string preres = req.ToStr();
                        string res = "Request " + preres + " processed by handler " + id.ToString();
                        Put(res);
                    }else base.HandleRequest(req);
                } else base.HandleRequest(req);
                
            }
        }
        public class HandlerB: Handler {
            int id;
            string pr1, pr2;
            public HandlerB(Handler sc, int id, string pr1, string pr2) :base(sc) {this.id = id;this.pr1 = pr1;this.pr2 = pr2;}
            public override void HandleRequest(Request req) {
                if(req.GetType() == typeof(RequestB)) {
                    var tmp = req.ToStr();
                    var rr = tmp.Substring(2);
                    if(String.Compare(pr1, rr) != 1 && String.Compare(rr, pr2) != 1) {
                        string preres = req.ToStr();
                        string res = "Request " + preres + " processed by handler " + id.ToString();
                        Put(res);
                    }
                    else base.HandleRequest(req);
                } else base.HandleRequest(req);
            }
        }

        public class Client
        {
            Handler h;
            public Client(Handler h){this.h = h;}
            public void SendRequest(Request req){h.HandleRequest(req);}
        }

        public static void Solve()
        {
            Task("OOP3Behav14");
            var n = GetInt();
            Handler h = new Handler(null);
            for(int i = 0; i < n; ++i) {
                var c = GetChar();
                if(c == 'A') {
                    var pr1 = GetInt();var pr2 = GetInt();
                    h = new HandlerA(h, i, pr1, pr2);
                } else {
                    var pr1 = GetString();var pr2 = GetString();
                    h = new HandlerB(h, i, pr1, pr2);
                }
            }
            Client cl = new Client(h);
            var k = GetInt();
            for(int i = 0; i < k; ++i) {
                var c = GetChar();
                if(c == 'A') {
                    var p = GetInt();
                    Request req = new RequestA(p);
                    cl.SendRequest(req);
                }
                else {
                    string p = GetString();
                    Request req = new RequestB(p);
                    cl.SendRequest(req);
                }
            }
        }
    }
}
