using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace IOC.Interface
{
    public interface IPeople
    {
        IHand Hand { get; set; }

        ILeg Leg { get; set; }

        void SayHello();
    }
}