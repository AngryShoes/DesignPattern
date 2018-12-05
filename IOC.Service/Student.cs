using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC.Interface;

namespace IOC.Service
{
    public class Student : IPeople
    {
        public IHand Hand { get; set; }

        public ILeg Leg { get; set; }

        public Student()
        {
            Console.WriteLine($"{this.GetType().Name} constructor...");
        }

        public void SayHello()
        {
            Console.WriteLine($"{this.GetType().Name} Say Hello...");
        }
    }
}