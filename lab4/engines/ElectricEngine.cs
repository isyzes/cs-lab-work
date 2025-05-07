using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(string model, double power) : base(model, power)
        {
            
        }

        public static explicit operator ElectricEngine(Car v)
        {
            throw new NotImplementedException();
        }
    }
}