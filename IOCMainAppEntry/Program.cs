using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOCMainAppEntry
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("IOC Program......");
            try
            {
                IOCTest.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}