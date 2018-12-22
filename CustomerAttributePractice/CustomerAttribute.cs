using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAttributePractice
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomerAttribute : Attribute
    {
        public CustomerAttribute()
        {
            Console.WriteLine("constructor no parameter");
        }

        public CustomerAttribute(string Number)
        {
            Console.WriteLine($"constructor with parameter Number:{Number}");
        }

        public bool Validate(string name)
        {
            if (name.Length >= 3)
            {
                return true;
            }
            return false;
        }
    }
}