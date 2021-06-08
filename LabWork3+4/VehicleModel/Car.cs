using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    public class Car : VehicleBase 
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
                    case FuelEnum.Diesel:
                    case FuelEnum.Petrol:
                        _fuel = value;
                        break;
                    default:
                        throw new Exception("Машина работает только от дизеля и бензина!");
                }
            }
        }
    }
}
