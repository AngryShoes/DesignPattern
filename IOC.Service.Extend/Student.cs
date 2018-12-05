using IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Service.Extend
{
    public class Student : IPeople
    {
        public IHand Hand { get; set; }

        public ILeg Leg { get; set; }

        public Student()
        {
            Console.WriteLine($"{this.GetType().Name} extend constructor...");
        }

        public void SayHello()
        {
            Console.WriteLine($"{this.GetType().Name} extend Say Hello...");
        }
    }
}