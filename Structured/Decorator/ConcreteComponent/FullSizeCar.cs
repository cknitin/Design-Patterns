using Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ConcreteComponent
{
    public class FullSizeCar : Car
    {
        public FullSizeCar()
        {
            Description = "Full Size Car";
        }
        public override string GetDescription() => Description;
        public override double GetPrice()=> 29000.0;

    }
}
