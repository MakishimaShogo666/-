using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Transport;

namespace CUI
{
    /// <summary>
    /// Добавление информации о
    /// транспорте с консоли
    /// </summary>
    public static class AddConsoleData
    {
        /// <summary>
        /// Ввод данных о машине
        /// </summary>
        /// <returns></returns>
        public static Car GetNewCarFromKeyboard()
        {
            var car = new Car();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Наименование транспорта: ");
                    car.Name = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите средний расход, л/100км: ");
                    car.AverageConsumption = ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите пройденную дистанцию, км: ");
                    car.Distance = ReadFromConsoleAndParse();
                })
            };
            actions.ForEach(SetValue);
            return car;
        }

        /// <summary>
        /// Ввод данных о машине-гибриде
        /// </summary>
        /// <returns></returns>
        public static HybridCar GetNewHybridFromKeyboard()
        {
            var hybrid = new HybridCar();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Наименование транспорта: ");
                    hybrid.Name = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите удельный расход топлива," +
                        " г/кВтч: ");
                    hybrid.SpecificConsumptionGasEngine = ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите время в пути, ч: ");
                    hybrid.TravelTime = ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите мощность " +
                        "электродвигателя, кВт: ");
                    hybrid.ElectricMotorPower = ReadFromConsoleAndParse();
                })
            };
            actions.ForEach(SetValue);
            return hybrid;
        }

        /// <summary>
        /// Ввод данных о вертолете
        /// </summary>
        /// <returns></returns>
        public static Helicopter GetNewHelicopterFromKeyboard()
        {
            var helicopter = new Helicopter();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Наименование транспорта: ");
                    helicopter.Name = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите средний расход, кг/ч: ");
                    helicopter.AverageConsumption = ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Введите время полета, ч: ");
                    helicopter.FlightTime = ReadFromConsoleAndParse();
                })
            };
            actions.ForEach(SetValue);
            return helicopter;
        }

        /// <summary>
        /// Чтение с консоли и преобразование в double
        /// </summary>
        /// <returns></returns>
        public static double ReadFromConsoleAndParse()
        {
            try
            {
                return double.Parse(Console.ReadLine().Replace('.', ','));
            }
            catch
            {
                throw new ArgumentException("Должно быть введено число!");
            }

        }

        /// <summary>
        /// Получение информации о 
        /// пользовательском вводе
        /// и задание параметра
        /// </summary>
        /// <param name="action"></param>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
