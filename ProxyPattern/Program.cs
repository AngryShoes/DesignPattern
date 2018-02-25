using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SinaServiceProxy sinaServiceProxy = new SinaServiceProxy();
            sinaServiceProxy.SendMsg();
            Console.ReadKey();
        }
    }
}