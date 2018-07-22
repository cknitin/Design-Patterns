using Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorator
{
    public class CarDecorator: Car
    {
        protected Car _car;

        public CarDecorator(Car car)
        {
            _car = car;
        }

        public override string GetDescription() => _car.GetDescription();
        public override double GetPrice() => _car.GetPrice();
    }
}
