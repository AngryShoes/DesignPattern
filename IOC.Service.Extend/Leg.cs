﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC.Interface;

namespace IOC.Service.Extend
{
    public class Leg : ILeg
    {
        public Leg()
        {
            Console.WriteLine("Leg extend constructor...");
        }
    }
}