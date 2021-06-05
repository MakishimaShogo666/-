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
    public class InputOutput
    {
        private const string _allPattern = @".";
        private const string _intDigitPattern = @"\d";
        public enum InputTypeEnum
        {
            Digit, //число (цифра)
            Integer,
            Fuel, //текст
            Mix //ввод всего
        }
        /// <summary>
        /// Процедура для записи символов в новую строку
        /// </summary>
        /// <param name="text">Вводимый символ</param>
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
        /// Процедура для записи в текущую строку 
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
        /// Процедура для вывода персоны
        /// </summary>
        /// <param name="person">Персона</param>
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
        /// Процедура для вывода персоны
        /// </summary>
        /// <param name="person">Персона</param>
        public static void VehicleReadFromConsole(string message, VehicleBase vehicle)
        {
            TextWriteLine(message, ConsoleColor.Blue);
            TextWriteLine(null, 0);
            vehicle.Name = Input("Имя: ", InputTypeEnum.Mix);
            vehicle.Weight = Double.Parse(Input("Вес: ", InputTypeEnum.Digit));
            vehicle.Power = Double.Parse(Input("Мощность: ",InputTypeEnum.Digit));
            string fuelInfo = "Тип топлива" + "\n";
            Array fuelArray = Enum.GetValues(typeof(FuelEnum));
            for (int i = 1; i < (int)FuelEnum.Count; i++)
            {
                fuelInfo += $"{i} - " + FuelToString((FuelEnum)fuelArray.GetValue(i)) + "\n";
            }
            vehicle.Fuel = FuelSetter(int.Parse(Input(fuelInfo, InputTypeEnum.Fuel)));
            vehicle.Waste = Double.Parse(Input("Расход топлива: ", InputTypeEnum.Digit));
        }

        //TODO: XML+
        /// <summary>
        /// Функция преобразования пола в строковую переменную
        /// </summary>
        /// <param name="gender">Пол</param>
        /// <returns>Строка, соответствующая полу</returns>
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
               default:
                    {
                        return "не определён";
                    }
            }
            throw new ArgumentException("Такого топлива нет!");
        }
        /// <summary>
        /// Функция для задания пола в соответствии с введённым символом
        /// </summary>
        /// <param name="genderString">Строка ввода пола</param>
        /// <returns>
        /// Пол
        /// </returns>
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
        /// Процедура PersonRead для проверки ввода свойств
        /// </summary>
        /// <param name="action">Метод ввода свойства персоны</param>
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
        public static object InputVehicle(VehicleBase inputVehicle)
        {
            TextWriteLine(inputVehicle.GetType().Name, ConsoleColor.Yellow);
            VehicleRead(inputString => inputVehicle.Name = inputString,
                "Имя: ", InputTypeEnum.Mix);
            VehicleRead(inputString => inputVehicle.Weight = double.Parse(inputString),
                "Вес: ", InputTypeEnum.Digit);
            VehicleRead(inputString => inputVehicle.Power = double.Parse(inputString),
                "Мощность: ", InputTypeEnum.Digit);
            string fuelInfo = "Тип топлива" + "\n";
            Array fuelArray = Enum.GetValues(typeof(FuelEnum));
            for (int i = 1; i < (int)FuelEnum.Count; i++)
            {
                fuelInfo += $"{i} - " + FuelToString((FuelEnum)fuelArray.GetValue(i)) + "\n";
            }
            VehicleRead(inputString => inputVehicle.Fuel = FuelSetter(int.Parse(inputString)), fuelInfo, InputTypeEnum.Fuel);
            VehicleRead(inputString => inputVehicle.Waste = double.Parse(inputString),
                "Расход топлива: ", InputTypeEnum.Digit);

            return inputVehicle;
        }
        public static Type VehicleTypeChoice(int vehicleType)
        {
            Type[] typeList = Assembly.GetAssembly(typeof(VehicleBase)).GetTypes()
                .Where(type => type.Namespace == "VehicleModel" && type.Name != "VehicleBase").ToArray();
            string vehicleInfo = "";
            for (int i = 0; i < typeList.Length; i++)
            {
                vehicleInfo += $"{i + 1} - " + typeList[i].Name + "\n";
            }
            TextWriteLine(vehicleInfo, ConsoleColor.Yellow);
            try
            {
                return typeList[vehicleType];
            }
            catch
            {
                throw new Exception($"Введённое число превышает число известных типов транспорта! ({typeList.Length - 2})");
            }
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
        /// Функция Input для ввода данных
        /// </summary>
        /// <param name="message">Сообщение для ввода</param>
        /// <param name="inputType">Тип ввода</param>
        /// <returns>
        /// inputString - введённая строка
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
