using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    public class Helicopter : VehicleBase
    {
        public override FuelEnum Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                switch (value)
                {
                    case FuelEnum.Kerosene:
                        _fuel = value;
                        break;
                    default:
                        throw new Exception("Вертолёт работает только от керосина!");
                }
            }
        }
        public Helicopter(string name, double weight, double power, FuelEnum fuel, double waste) : base(name, weight, power, fuel, waste)
        {

        }
        public Helicopter()
        {

        }
    }
}
