using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Aspect Object Program....,,");
            UnityAop unityAop = new UnityAop();
            unityAop.Test();
            Console.Read();
        }
    }
}