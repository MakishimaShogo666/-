using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModel;

namespace GUI
{
    /// <summary>
    /// Класс аргумента для передачи транспорта
    /// </summary>
    public class VehicleEventArgs : EventArgs
    {
        /// <summary>
        /// Передаваемый транспорт
        /// </summary>
        public VehicleBase SendingVehicle { get; }

        /// <summary>
        /// Конструктор для передачи транспорта
        /// </summary>
        /// <param name="sendingVehicle"></param>
        public VehicleEventArgs(VehicleBase sendingVehicle)
        {
            SendingVehicle = sendingVehicle;
        }
    }
}
