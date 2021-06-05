using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    public class HybridCar : VehicleBase
    {
        private double _hybridCoefficient;

        public double HybridCoefficient
        {
            get
            {
                switch (Fuel)
                {
                    case FuelEnum.Electricity:
                        return 0.5;
                    case FuelEnum.Hydrogen:
                        return 0.75;
                    case FuelEnum.Mixed:
                        return 0.9;
                    default:
                        throw new Exception("Гибрид работает только от электричества, водорода или смешанного топлива!");
                }
            }
            private set
            {
                _hybridCoefficient = value;
            }
        }
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
                    case FuelEnum.Electricity:
                    case FuelEnum.Hydrogen:
                    case FuelEnum.Mixed:
                        _fuel = value;
                        break;
                    default:
                        throw new Exception("Гибрид работает только от электричества, водорода или смешанного топлива!");
                }
            }
        }
        public override double Waste
        {
            get
            {
                switch (Fuel)
                {
                    case FuelEnum.Electricity:
                        return 0;
                    default:
                        return _waste;
                }
            }
            set
            {
                PropertyCheck(value);
                if (Fuel == FuelEnum.Electricity && value != 0)
                {
                    throw new Exception("При использовании электричества топливо не расходуется!");
                }
                else
                {
                    _waste = value;
                }
            }
        }
        public HybridCar()
        {

        }
        public HybridCar(string name, double weight, double power, FuelEnum fuel, double waste) : base(name, weight, power, fuel, waste)
        {

        }
        public override double Consumption(double distance)
        {
            return base.Consumption(distance) * HybridCoefficient;
        }
    }
}
