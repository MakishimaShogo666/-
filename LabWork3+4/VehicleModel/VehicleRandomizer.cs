using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    /// <summary>
    /// Класс рандомного транспорта
    /// </summary>
    public class VehicleRandomizer
    {
        /// <summary>
        /// Приватное поле рандома
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Лист нименований вертолётов
        /// </summary>
        private static List<string> _helicopterNames = new List<string>()
        {
            "Ка-50",
            "Ми-24",
            "AH-64 Apache",
            "Ми-8",
            "Ка-52",
            "AH-1Z Viper",
            "Ми-28НМ",
            "Ми-35М",
        };

        /// <summary>
        /// Лист нименований не вертолётов
        /// </summary>
        private static List<string> _autoNames = new List<string>()
        {
            "Mercedes-Benz",
            "Волга",
            "Лада",
            "Bugatti",
            "Lamborghini",
            "Chrysler",
            "BMW",
            "Audi",
        };

        /// <summary>
        /// Присвоение случайного наименования
        /// </summary>
        /// <returns></returns>
        public static string GetRandomName(string vehicleString)
        {
            if (vehicleString == "Вертолёт")
            {
                return _helicopterNames[_random.Next(0, _helicopterNames.Count)];
            }
            else
            {
                return _autoNames[_random.Next(0, _autoNames.Count)];
            }
        }

        /// <summary>
        /// Создание случайного числа
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <returns></returns>
        public static double GetRandomNumber(int maxValue)
        {
            return _random.NextDouble() * maxValue;
        }
    }
}
