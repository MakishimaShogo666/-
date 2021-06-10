using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using VehicleModel;

namespace ConsoleRead
{
    /// <summary>
    /// Класс InputOutput для ввода-вывода информации
    /// </summary>
    public class InputOutput
    {
        /// <summary>
        /// Перечисление типов ввода
        /// </summary>
        public enum InputTypeEnum
        {
            Digit, // число (цифра, могут вводиться десятичные дроби)
            Integer, // натуральное число
            Fuel, // ввод типа топлива
            Mix // ввод всего
        }

        /// <summary>
        /// Шаблон для ввода любых символов
        /// </summary>
        private const string _allPattern = @".";

        /// <summary>
        /// Шаблон для ввода цифр
        /// </summary>
        private const string _intDigitPattern = @"\d";

        /// <summary>
        /// Метод для записи символов в новую строку
        /// </summary>
        /// <param name="text">Вводимый символ</param>
        /// <param name="color"></param>
        public static void TextWriteLine(object text, ConsoleColor color)
        {
            if (text != null)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для записи в текущую строку 
        /// </summary>
        /// <param name="text">Вводимый символ</param>
        public static void TextWrite(object text)
        {
            if (text != null)
            {
                Console.Write(text);
            }
            else
            {
                Console.Write("");
            }
        }

        /// <summary>
        /// Метод вывода информации о транспорте
        /// </summary>
        /// <param name="message">Сообщение перед выводом транспорта</param>
        /// <param name="vehicle">Выводимый транспорт</param>
        public static void VehicleWrite(string message, VehicleBase vehicle)
        {
            TextWriteLine(message, ConsoleColor.Blue);
            TextWriteLine(null, 0);
            TextWriteLine("Имя: " + vehicle.Name, ConsoleColor.White);
            TextWriteLine("Вес: " + vehicle.Weight + " т", ConsoleColor.White);
            TextWriteLine("Мощность: " + vehicle.Power + " л.с.", ConsoleColor.White);
            TextWriteLine("Топливо: " + FuelToString(vehicle.Fuel), ConsoleColor.White);
            TextWriteLine("Расход топлива: " + vehicle.Waste + " л/км", ConsoleColor.White);
            TextWriteLine(null, 0);
        }

        /// <summary>
        /// Метод преобразования типа топлива в строку
        /// </summary>
        /// <param name="fuel">Тип топлива</param>
        /// <returns>Строка, соответствующая типу топлива</returns>
        public static string FuelToString(FuelEnum fuel)
        {
            switch (fuel)
            {
                case FuelEnum.Diesel:
                {
                    return "дизель";
                }
                case FuelEnum.Electricity:
                {
                    return "электричество";
                }
                case FuelEnum.Hydrogen:
                {
                    return "водород";
                }
                case FuelEnum.Kerosene:
                {
                    return "керосин";
                }
                case FuelEnum.Mixed:
                {
                    return "смешанное топливо";
                }
                case FuelEnum.Petrol:
                {
                    return "бензин";
                }
            }
            throw new ArgumentException("Такого топлива нет!");
        }

        /// <summary>
        /// Метод задания типа топлива в соответствии с введённой цифрой
        /// </summary>
        /// <param name="fuelNumber">Введённая цифра</param>
        /// <returns>Тип топлива</returns>
        public static FuelEnum FuelSetter(int fuelNumber)
        {
            switch (fuelNumber)
            {
                case 1:
                    return FuelEnum.Petrol;
                case 2:
                    return FuelEnum.Diesel;
                case 3:
                    return FuelEnum.Kerosene;
                case 4:
                    return FuelEnum.Mixed;
                case 5:
                    return FuelEnum.Hydrogen;
                case 6:
                    return FuelEnum.Electricity;
            }
            return FuelEnum.NotDefined;
        }

        /// <summary>
        /// Метод ввода символа после нажатия клавишы
        /// </summary>
        /// <param name="condition">Условие ввода</param>
        /// <param name="inputString">Вводимая строка</param>
        /// <param name="keyInfo">Нажатая клавиша</param>
        /// <returns>Строка после нажатия клавишы</returns>
        public static string KeyWrite(bool condition, string inputString, ConsoleKeyInfo keyInfo)
        {
            if (condition)
            {
                TextWrite(keyInfo.KeyChar);
                return inputString;
            }
            else
            {
                return inputString.Substring(0, inputString.Length - 1);
            }
        }

        /// <summary>
        /// Процедура проверки условий ввода символов
        /// </summary>
        /// <param name="pattern">Шаблон ввода</param>
        /// <param name="stringMaxLength">Максимальная длина строки</param>
        /// <param name="inputType">Тип ввода</param>
        private static string ConditionInput(string pattern,
            byte stringMaxLength, InputTypeEnum inputType)
        {
            string inputString = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //Если символ клавиши совпадает с шаблоном ввода и число символов в строке меньше максимального
                //или нажата клавиша Backspace, то выполняется процедура проверки ввода
                //
                if (VehicleBase.PatternCoincidence(inputString, keyInfo.KeyChar, pattern, stringMaxLength)
                   || (keyInfo.Key == ConsoleKey.Backspace))
                {
                    if (keyInfo.Key != ConsoleKey.Backspace)
                    {
                        inputString += keyInfo.KeyChar;
                        switch (inputType)
                        {
                            case InputTypeEnum.Mix:
                                TextWrite(keyInfo.KeyChar);
                                break;
                            case InputTypeEnum.Fuel:
                                inputString = KeyWrite(int.TryParse(inputString, out int result) && result > 0
                                    && result <= (int)FuelEnum.Count - 1, inputString, keyInfo);
                                break;
                            case InputTypeEnum.Integer:
                                inputString = KeyWrite(int.TryParse(inputString, out int intResult) && intResult > 0, 
                                    inputString, keyInfo);
                                break;
                            default:
                                inputString = KeyWrite(double.TryParse(inputString, out _), inputString, keyInfo);
                                break;
                        }
                    }
                    else
                    {
                        if (inputString != "")
                        {
                            // Удаление символа из консоли
                            //
                            TextWrite("\b \b");
                            inputString = inputString.Substring(0, inputString.Length - 1);
                        }
                    }
                }

                if ((keyInfo.Key == ConsoleKey.Enter) && (inputString != ""))
                {
                    TextWriteLine(null, 0);
                    break;
                }
            }
            return inputString;
        }

        /// <summary>
        /// Метод для проверки ввода свойств
        /// </summary>
        /// <param name="action">Метод ввода свойства транспорта</param>
        /// <param name="message">Сообщение перед вводом</param>
        /// <param name="inputType">Тип ввода</param>
        private static void VehicleRead(Action<string> action, string message, InputTypeEnum inputType)
        {
            while (true)
            {
                try
                {
                    action(Input(message, inputType));
                    break;
                }
                catch (Exception ex)
                {
                    TextWriteLine(ex.Message, ConsoleColor.Red);
                    continue;
                }
            }
        }

        /// <summary>
        /// Метод ввода транспорта
        /// </summary>
        /// <param name="inputVehicle">Вводимый транспорт</param>
        /// <returns>Транспорт с введённой информацией</returns>
        public static VehicleBase InputVehicle(VehicleBase inputVehicle)
        {
            
            VehicleRead(inputString => inputVehicle.Name = inputString,
                "Имя: ", InputTypeEnum.Mix);
            VehicleRead(inputString => inputVehicle.Weight = double.Parse(inputString),
                "Вес, т: ", InputTypeEnum.Digit);
            VehicleRead(inputString => inputVehicle.Power = double.Parse(inputString),
                "Мощность, л.с.: ", InputTypeEnum.Digit);
            string fuelInfo = "Тип топлива:" + "\n";
            Array fuelArray = Enum.GetValues(typeof(FuelEnum));
            for (int i = 1; i < (int)FuelEnum.Count; i++)
            {
                fuelInfo += $"{i} - " + FuelToString((FuelEnum)fuelArray.GetValue(i)) + "\n";
            }
            VehicleRead(inputString => inputVehicle.Fuel = FuelSetter(int.Parse(inputString)), fuelInfo, InputTypeEnum.Fuel);
            VehicleRead(inputString => inputVehicle.Waste = double.Parse(inputString),
                "Расход топлива, л/км: ", InputTypeEnum.Digit);

            return inputVehicle;
        }

        /// <summary>
        /// Функция для выхода из программы 
        /// </summary>
        /// <returns>
        /// true, если выбран выход из программы
        /// </returns>
        public static bool QuitOfProgram()
        {
            TextWriteLine("\n" + "Для продолжения работы программы нажмите Enter, " +
                "для выхода из программы нажмите любую другую клавишу" + "\n", ConsoleColor.Cyan);
            return Console.ReadKey().Key != ConsoleKey.Enter;
        }

        /// <summary>
        /// Метод для ввода данных
        /// </summary>
        /// <param name="message">Сообщение для ввода</param>
        /// <param name="inputType">Тип ввода</param>
        /// <returns>
        /// Введённая строка
        /// </returns>
        public static string Input(string message, InputTypeEnum inputType)
        {
            TextWrite(message);

            switch (inputType)
            {
                case InputTypeEnum.Digit:
                    {
                        return ConditionInput(_allPattern, byte.MaxValue, InputTypeEnum.Digit);
                    }
                case InputTypeEnum.Fuel:
                    {
                        return ConditionInput(_intDigitPattern, byte.MaxValue, InputTypeEnum.Fuel);
                    }
                case InputTypeEnum.Integer:
                    {
                        return ConditionInput(_intDigitPattern, byte.MaxValue, InputTypeEnum.Integer);
                    }
                default:
                    {
                        return ConditionInput(_allPattern, byte.MaxValue, InputTypeEnum.Mix);
                    }
            }
        }
    }
}
