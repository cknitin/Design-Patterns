using Decorator.Component;
using Decorator.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ConcreteDecorator
{
    public class LeatherSeat: CarDecorator
    {
        public LeatherSeat(Car car):base(car)
        {
            Description = "Leather Seat";
        }

        public override string GetDescription() => $"{_car.GetDescription()}, {Description}";
        public override double GetPrice() => _car.GetPrice() + 2500;
    }
}
