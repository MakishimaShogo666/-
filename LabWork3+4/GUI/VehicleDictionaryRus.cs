using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModel;

namespace GUI
{
    class VehicleDictionaryRus
    {
        /// <summary>
        /// Словарь соответствия типа топлива его текстовому названию
        /// </summary>
        public static readonly Dictionary<FuelEnum, string> FuelToString = new Dictionary<FuelEnum, string>
        {
            { FuelEnum.Petrol, "Бензин" },
            { FuelEnum.Diesel, "Дизель" },
            { FuelEnum.Kerosene, "Керосин" },
            { FuelEnum.Mixed, "Смешанное топливо" },
            { FuelEnum.Hydrogen, "Водород" },
            { FuelEnum.Electricity, "Электричество" },
        };
    }
}
