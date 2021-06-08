using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    /// <summary>
    /// Класс HybridCar - гибридная машина
    /// </summary>
    public class HybridCar : VehicleBase
    {
        /// <summary>
        /// Коэффициент гибридности (снижение потребления топлива)
        /// </summary>
        private double _hybridCoefficient;

        /// <summary>
        /// Коэффициент гибридности (снижение потребления топлива)
        /// </summary>
        public double HybridCoefficient
        {
            get
            {
                switch (Fuel)
                {
                    case FuelEnum.Electricity:
                        return 0;
                    case FuelEnum.Hydrogen:
                        return 0.5;
                    case FuelEnum.Mixed:
                        return 0.75;
                    default:
                        throw new Exception("Гибрид работает только от электричества, водорода или смешанного топлива!");
                }
            }
            private set
            {
                _hybridCoefficient = value;
            }
        }

        /// <summary>
        /// Топливо гибрида
        /// </summary>
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

        /// <summary>
        /// Расход топлива у гибрида
        /// </summary>
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

        /// <summary>
        /// Потребление (в л) топлива гибрида
        /// </summary>
        /// <param name="distance">Пройденный гибридом путь, км</param>
        /// <returns></returns>
        public override double Consumption(double distance)
        {
            return base.Consumption(distance) * HybridCoefficient;
        }
    }
}
