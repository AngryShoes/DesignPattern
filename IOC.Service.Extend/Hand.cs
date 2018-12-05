using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC.Interface;

namespace IOC.Service.Extend
{
    public class Hand : IHand
    {
        public Hand()
        {
            Console.WriteLine("Hand in extend constructor...");
        }
    }
}