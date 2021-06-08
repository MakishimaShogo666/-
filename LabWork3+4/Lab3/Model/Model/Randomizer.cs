using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс рандомного транспорта
    /// </summary>
    public class Randomizer
    {
        /// <summary>
        /// Приватное поле рандома
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Лист нименований транспорта
        /// </summary>
        private static List<string> _names = new List<string>()
        {
            "Ребросближатель",
            "Цианстильбен",
            "Риттингерит",
            "Десланозид",
            "Шляхетство",
            "Зоометрия",
            "Карбовакс",
            "Топоплан",
            "Евтерпа",
            "Доризм"
        };

        /// <summary>
        /// Присвоение случайного наименования
        /// </summary>
        /// <returns></returns>
        public static string GetRandomName()
        {
            return _names[_random.Next(0, _names.Count)];
        }

        /// <summary>
        /// Создание случайного числа
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <returns></returns>
        public static int GetRandomNumber(int minValue,int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
