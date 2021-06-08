using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    /// <summary>
    /// Класс Helicopter - Вертолёт
    /// </summary>
    public class Helicopter : VehicleBase
    {
        /// <summary>
        /// Топливо вертолёта
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
                    case FuelEnum.Kerosene:
                        _fuel = value;
                        break;
                    default:
                        throw new Exception("Вертолёт работает только от керосина!");
                }
            }
        }
    }
}
