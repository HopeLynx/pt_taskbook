// File: "OOP3Behav11"
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
            public abstract void InsertCoin();
            public abstract void GetBall();
            public abstract void ReturnCoin();
            public abstract void AddBall();
        }

        public class ReadyState: State {
            BallMachine machine;
            public ReadyState(BallMachine machine) {
                this.machine = machine;
            }
            public override void InsertCoin() {
                Put("Coin is inserted");
                var temp = machine.GetHasPayed();
                machine.SetState(temp);
            }
            public override void GetBall() {
                Put("You need to pay first");
            }
            public override void ReturnCoin() {
                Put("You need to pay first");
            }
            public override void AddBall() {}
        }
        public class HasPayedState: State {
            BallMachine machine;
            public HasPayedState(BallMachine machine) {
                this.machine = machine;
            }
            public override void InsertCoin() {
                Put("You have already paid");
            }
            public override void GetBall() {
                Put("Take your ball");
                var temp = machine.DecreaseBallCount();
                if(temp > 0) {
                    var state = machine.GetReady();
                    machine.SetState(state);
                } else {
                    var state = machine.GetNoBall();
                    machine.SetState(state);
                }
            }
            public override void ReturnCoin() {
                Put("Take your coin");
                var temp = machine.GetReady();
                machine.SetState(temp);
            }
            public override void AddBall() {}
        }
        public class NoBallState: State {
            BallMachine machine;
            public NoBallState(BallMachine machine) {
                this.machine = machine;
            }
            public override void InsertCoin() {
                Put("Sorry, balls are over");
            }
            public override void GetBall() {
                Put("Sorry, balls are over");
            }
            public override void ReturnCoin() {
                Put("Sorry, balls are over");
            }
            public override void AddBall() {
                var temp = machine.GetReady();
                machine.SetState(temp);
            }
        }

        public class BallMachine {
            int ballCount;
            State ready;
            State hasPayed;
            State noBall;
            State currentState;
            public BallMachine() {
                ballCount = 3;
                ready = new ReadyState(this);
                hasPayed = new HasPayedState(this);
                noBall = new NoBallState(this);
                currentState = ready;
            }

            public void InsertCoin(){
                currentState.InsertCoin();
            }
            public void GetBall() {
                currentState.GetBall();
            }
            public void ReturnCoin() {
                currentState.ReturnCoin();
            }
            public void AddBall() {
                Put("Ball is added");
                ++ballCount;
                currentState.AddBall();
            }
            public int DecreaseBallCount() {
                --ballCount;
                return ballCount;
            }
            public void SetState(State newState) {
                currentState = newState;
            }
            public State GetReady() {
                return ready;
            }
            public State GetHasPayed() {
                return hasPayed;
            }
            public State GetNoBall() {
                return noBall;
            }


        }
        // Implement the ReadyState, HasPayedState
        //   and NoBallState descendant classes

        // Implement the BallMachine class

        public static void Solve()
        {
            Task("OOP3Behav11");

            string str = GetString();

            BallMachine bm = new BallMachine();
            for(int i = 0; i < str.Length; ++i) {
                if(str[i] == 'I')
                    bm.InsertCoin();
                else if(str[i] == 'G')
                    bm.GetBall();
                else if(str[i] == 'R')
                    bm.ReturnCoin();
                else
                    bm.AddBall();
            }

        }
    }
}
