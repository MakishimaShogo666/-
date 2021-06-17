using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

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
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(HybridCar))]
    [XmlInclude(typeof(Helicopter))]
    public abstract class VehicleBase
    {
        /// <summary>
        /// Словарь соответствия типа топлива его текстовому названию
        /// </summary>
        public static readonly Dictionary<FuelEnum, string> FuelToStringDictionary = new Dictionary<FuelEnum, string>
        {
            { FuelEnum.Petrol, "Бензин" },
            { FuelEnum.Diesel, "Дизель" },
            { FuelEnum.Kerosene, "Керосин" },
            { FuelEnum.Mixed, "Смешанное топливо" },
            { FuelEnum.Hydrogen, "Водород" },
            { FuelEnum.Electricity, "Электричество" },
        };

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
        /// Дистанция
        /// </summary>
        private double _distance;

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
        /// Расход топлива (в л/км)
        /// </summary>
        public virtual double Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                PropertyCheck(value);
                _distance = value;
            }
        }

        /// <summary>
        /// Метод расчёта потребления топлива
        /// </summary>
        /// <returns>Объём потребления топлива, л</returns>
        public virtual double Consumption()
        {
            return Distance * Waste;
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
                    if (double.IsNaN(doubleValue))
                    {
                        throw new ArgumentException("Нечисловое значение!");
                    }
                    break;
                }
                case string stringValue:
                {
                    if (string.IsNullOrWhiteSpace(stringValue)|| string.IsNullOrEmpty(stringValue))
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
        /// <returns>true - если совпадает, иначе - false</returns>
        public static bool PatternCoincidence(string inputString, object keyInfo,
            string pattern, byte stringMaxLength)
        {
            return Regex.IsMatch(keyInfo.ToString(), pattern)
                && (inputString.Length < stringMaxLength);
        }
    }
}
