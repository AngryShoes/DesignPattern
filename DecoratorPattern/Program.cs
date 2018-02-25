using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    internal class Program
    {
        private static IComponent component;

        private static void Main(string[] args)
        {
            component = new DecoratedComponent(new Component());
            component.DoSomething();
            Console.ReadKey();
        }
    }
}