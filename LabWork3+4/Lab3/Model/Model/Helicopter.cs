using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transport
{
    /// <summary>
    /// Класс Вертолет
    /// </summary>
    [Serializable]
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Время полета
        /// </summary>
        private double _flightTime;

        /// <summary>
        /// Средний расход топлива кг/ч
        /// </summary>
        private double _averageConsumption;

        /// <summary>
        /// Средний расход топлива кг/ч
        /// </summary>
        public double AverageConsumption
        {
            get
            {
                return _averageConsumption;
            }
            set
            {
                NumberCheck(value);
                _averageConsumption = value;
            }
        }

        /// <summary>
        /// Время полета
        /// </summary>
        public double FlightTime
        {
            get
            {
                return _flightTime;
            }
            set
            {
                NumberCheck(value);
                _flightTime = value;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Helicopter() : this("Неизвестно", 0, 0)
        {

        }

        /// <summary>
        /// Конструктор класса Helicopter
        /// </summary>
        /// <param name="name">Наименование транспорта</param>
        /// <param name="averageConsumption">Средний расход
        /// топлива кг/ч</param>
        /// <param name="flightTime">Время полета</param>
        public Helicopter(string name, double averageConsumption,
            double flightTime) : base(name)
        {
            AverageConsumption = averageConsumption;
            FlightTime = flightTime;
        }

        /// <summary>
        /// Возращает количество затраченного топлива
        /// </summary>
        public override double FuelQuantity
        {
            get
            {
                return Math.Abs(AverageConsumption / 0.715 * FlightTime);
            }
        }
    }
}
