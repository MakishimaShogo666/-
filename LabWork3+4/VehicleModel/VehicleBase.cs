using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VehicleModel
{
    /// <summary>
    /// Перечисление видов топлива
    /// </summary>
    public enum FuelEnum
    {
        NotDefined,
        Petrol,
        Diesel,
        Kerosene,
        Mixed,
        Hydrogen,
        Electricity,
        Count
    }

    /// <summary>
    /// Базовый класс VehicleBase
    /// </summary>
    public abstract class VehicleBase
    {
        /// <summary>
        /// Ускорение свободного падения
        /// </summary>
        private const double _gravityAcceleration = 9.8;

        /// <summary>
        /// Коэффициент приведения лошадиных сил к ваттам
        /// </summary>
        private const double _horseForceToWatt = 735.5;

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Вес (в тоннах)
        /// </summary>
        private double _weight;

        /// <summary>
        /// Расход топлива (в л/км)
        /// </summary>
        protected double _waste;

        /// <summary>
        /// Мощность (в л.с.)
        /// </summary>
        private double _power;

        /// <summary>
        /// Тип топлива
        /// </summary>
        protected FuelEnum _fuel;

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight
        {
            get
            {
                return _weight;            
            }
            set
            {
                PropertyCheck(value);
                _weight = value > 0 
                    ? value
                    : throw new Exception("Транспорт должен иметь вес!");
            }
        }

        /// <summary>
        /// Расход топлива (в л/км)
        /// </summary>
        public virtual double Waste
        {
            get
            {
                return _waste;
            }
            set
            {
                PropertyCheck(value);
                _waste = value;
            }
        }

        /// <summary>
        /// Мощность (в л.с.)
        /// </summary>
        public double Power
        {
            get
            {
                return _power;
            }
            set
            {
                PropertyCheck(value);
                _power = value;
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                PropertyCheck(value);
                _name = value;
            }
        }

        /// <summary>
        /// Тип топлива
        /// </summary>
        public abstract FuelEnum Fuel { get; set; }


        /// <summary>
        /// Метод расчёта ускорения
        /// </summary>
        /// <returns></returns>
        public double Acceleration()
        {
            return (_power * _horseForceToWatt) / ((_weight * 1000) * _gravityAcceleration);
        }

        /// <summary>
        /// Метод расчёта скорости
        /// </summary>
        /// <param name="startValue">Начальная скорость, км/ч</param>
        /// <param name="timeInSecond">Время движения, с</param>
        /// <returns></returns>
        public double Velocity(double startValue, double timeInSecond)
        {
            return (startValue/3.6) + Acceleration() * timeInSecond;
        }

        /// <summary>
        /// Метод расчёта пройденного пути
        /// </summary>
        /// <param name="startVelocity">Начальная скорость, км/ч</param>
        /// <param name="timeInSecond">Время движения, с</param>
        /// <returns></returns>
        public double Distance(double startVelocity, double timeInSecond)
        {
            return (Velocity(startVelocity, timeInSecond) * timeInSecond - 
                Acceleration() * (timeInSecond * timeInSecond) / 2)/1000;
        }

        /// <summary>
        /// Метод расчёта потребления топлива
        /// </summary>
        /// <param name="distance">Пройденный путь, км</param>
        /// <returns></returns>
        public virtual double Consumption(double distance)
        {
            return distance * _waste;
        }

        /// <summary>
        /// Метод проверки величины value
        /// </summary>
        /// <param name="value">Проверяемая величина</param>
        protected void PropertyCheck(object value)
        {
            switch(value)
            {
                case double doubleValue:
                {
                    if (doubleValue < 0)
                    {
                        throw new ArgumentOutOfRangeException("Значение не может быть отрицательным!");
                    }
                    break;
                }
                case string stringValue:
                {
                    if (string.IsNullOrWhiteSpace(stringValue))
                    {
                        throw new ArgumentException("Имя не может быть пустым!");
                    }
                    break;
                }
                case FuelEnum fuelValue:
                {
                    if (fuelValue == FuelEnum.Count || fuelValue == FuelEnum.NotDefined)
                    {
                        throw new ArgumentException("Некорректный вид топлива (служебные значения)!");
                    }
                    break;
                }
                default:
                    throw new FormatException("Значение имеет недопустимый формат!");
            }
        }

        /// <summary>
        /// Метод определения совпадения введённой строки с шаблоном
        /// </summary>
        /// <param name="inputString">Введённая строка</param>
        /// <param name="keyInfo">Нажатая клавиша</param>
        /// <param name="pattern">Шаблон</param>
        /// <param name="stringMaxLength">Максимальная длина строки</param>
        /// <returns></returns>
        public static bool PatternCoincidence(string inputString, object keyInfo,
            string pattern, byte stringMaxLength)
        {
            return Regex.IsMatch(keyInfo.ToString(), pattern)
                && (inputString.Length < stringMaxLength);
        }
    }
}
