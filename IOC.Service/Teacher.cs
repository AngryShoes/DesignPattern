using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace IOC.Service
{
    public class Teacher : IPeople
    {
        [Dependency]
        public IHand Hand { get; set; }

        [Dependency]
        public ILeg Leg { get; set; }

        public Teacher()
        {
            Console.WriteLine($"{this.GetType().Name} constructor...");
        }

        [InjectionConstructor]
        public Teacher(IHand hand)
        {
            this.Hand = hand;
            Console.WriteLine($"{this.GetType().Name} param constructor...");
        }

        public void SayHello()
        {
            Console.WriteLine($"{this.GetType().Name} Say Hello...");
        }

        [InjectionMethod]
        public void Teaching()
        {
            Console.WriteLine($"{this.GetType().Name} Teaching...");
        }
    }
}