using Observer.ConcreteObserver;
using Observer.ConcreteSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var gClooney = new GClooney("I Love MY New Wife.");
            var tSwift = new TSwift("I started a joke is my favorite number.");

            var firstFan = new Fan();
            var secondFan = new Fan();

            gClooney.AddFollower(firstFan);
            tSwift.AddFollower(secondFan);

           gClooney.Tweet= "I Love Joker";
           tSwift.Tweet= "I am looser";

            Console.ReadLine();


        }
    }
}
