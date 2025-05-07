using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class InternalCombustionEngine : Engine
    {
        private double engineDisplacement;

        public InternalCombustionEngine(string model, double power, double engineDisplacement) : base(model, power)
        {
            this.engineDisplacement = engineDisplacement;
        }
    }
}