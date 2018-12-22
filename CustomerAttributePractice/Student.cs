using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAttributePractice
{
    [Customer]
    public class Student
    {
        [Customer("28956")]
        public string Name { get; set; }

        [Customer]
        public string Address { get; set; }

        [Customer("73901")]
        public void SayHi()
        {
            Console.WriteLine($"Name :{Name} Say Hi");
        }

        [Customer]
        public void Answer(string content)
        {
            Console.WriteLine($"{Name} answer:{content}");
        }

        public string Question([Customer]string question)
        {
            return question;
        }
    }
}