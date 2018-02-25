using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    internal class Component : IComponent
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something in Component...");
        }
    }
}