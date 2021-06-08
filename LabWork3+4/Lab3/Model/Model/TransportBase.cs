using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Model.Transport;

namespace Model
{
    /// <summary>
    /// Базоввый класс для всех
    /// видов транспорта
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(HybridCar))]
    [XmlInclude(typeof(Helicopter))]
    public abstract class TransportBase
    {
        /// <summary>
        /// Наименоание транспорта
        /// </summary>
        private string _name;

        /// <summary>
        /// Ниаменование транспорта
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CorrectName(value);
                    _name = CorrectRegister(value);
                }
                else
                {
                    throw new ArgumentException("Наименование не может быть " +
                        "пустой строкой или null");
                }

            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected TransportBase() : this("Неизвестно")
        {

        }

        /// <summary>
        /// Конструктор класса TransportBase
        /// </summary>
        /// <param name="name">Наименование транспорта</param>
        protected TransportBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Рачет колличества затраченного топлива
        /// </summary>
        public abstract double FuelQuantity { get; }

        /// <summary>
        /// Проверка на корректность чисел
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double NumberCheck (double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Величина должна" +
                    "быть положительным числом!");
            }
            else
            {
                return number;
            }
        }

        /// <summary>
        /// Проверка на корректность символов
        /// </summary>
        /// <param name="name"></param>
        public static void CorrectName(string name)
        {
            Regex pattern = new Regex(@"((^([а-яА-Я])+$))");

            if (!pattern.IsMatch(name))
            {
                throw new ArgumentException("Наименование может иметь " +
                    "только русские символы!");
            }
        }

        /// <summary>
        /// Приведение к правильному регистру 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string CorrectRegister(string word)
        {
            return word.Substring(0, 1).ToUpper() +
                word.Substring(1).ToLower();
        }
    }
}
