using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Service.Extend
{
    public class Teacher : IPeople
    {
        public IHand Hand { get; set; }
        public ILeg Leg { get; set; }

        public Teacher()
        {
            Console.WriteLine($"{this.GetType().Name} extend constructor...");
        }

        public Teacher(IHand hand)
        {
            this.Hand = hand;
            Console.WriteLine($"{this.GetType().Name} extend constructor with parameter");
        }

        public void SayHello()
        {
            Console.WriteLine($"{this.GetType().Name} extend Say Hello...");
        }
    }
}