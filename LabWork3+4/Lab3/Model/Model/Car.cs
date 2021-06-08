using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transport
{
    /// <summary>
    /// Класс Машины
    /// </summary>
    [Serializable]
    public class Car : TransportBase
    {
        /// <summary>
        /// Средний расход на 100км
        /// </summary>
        private double _averageConsumption;

        /// <summary>
        /// Пройденое расстояние
        /// </summary>
        private double _distance;

        /// <summary>
        /// Средний расход
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
        /// Пройденое расстояние
        /// </summary>
        public double Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                NumberCheck(value);
                _distance = value;
            }
        }

        /// <summary>
        /// Конструкток по умолчанию
        /// </summary>
        public Car() : this("Неизвестно", 0, 0)
        {

        }

        /// <summary>
        /// Конструктор класса Ram2500
        /// </summary>
        /// <param name="name">Наименование тренспорта</param>
        /// <param name="averageConsumption">Средний расход на 100км</param>
        /// <param name="distance">Пройденая дистанция</param>
        public Car(string name, double averageConsumption, double distance) : base(name)
        {
            AverageConsumption = averageConsumption;
            Distance = distance;
        }

        /// <summary>
        /// Возращает количество затраченного топлива
        /// </summary>
        public override double FuelQuantity
        {
            get
            {
                return Math.Abs((AverageConsumption/100)
                    * Distance);
            }
        }
    }
}
