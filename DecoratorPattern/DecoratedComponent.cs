using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    internal class DecoratedComponent : IComponent
    {
        private static IComponent _component;

        public DecoratedComponent(IComponent component)
        {
            _component = component;
        }

        public void DoSomething()
        {
            DoSomethingElse();
            _component.DoSomething();
        }

        public void DoSomethingElse()
        {
            Console.WriteLine("Do Something Else in Decorated Component...");
        }
    }
}