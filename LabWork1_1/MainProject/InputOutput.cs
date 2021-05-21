using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork1_1;

namespace MainProject
{
    /// <summary>
    /// Перечисление типов ввода
    /// </summary>
    public enum InputTypeEnum
    {
        Digit, //число (цифра)
        Gender, //пол
        Text, //текст
        Mix //ввод всего
    }

    /// <summary>
    /// Класс для ввода-вывода данных
    /// </summary>
    public class InputOutput
    {
        #region Методы

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
        public static void PersonWrite(string message, PersonBase person)
        {
            TextWriteLine(message, ConsoleColor.Blue);
            TextWriteLine(null, 0);
            TextWriteLine(Pattern.SurnameOutputMessage + person.Surname, ConsoleColor.White);
            TextWriteLine(Pattern.NameOutputMessage + person.Name, ConsoleColor.White);
            TextWriteLine(Pattern.AgeOutputMessage + person.Age, ConsoleColor.White);

            
            TextWriteLine(Pattern.GenderOutputMessage + GenderToString(person.Gender), ConsoleColor.White);
            TextWriteLine(null, 0);
        }

        //TODO: XML+
        /// <summary>
        /// Функция преобразования пола в строковую переменную
        /// </summary>
        /// <param name="gender">Пол</param>
        /// <returns>Строка, соответствующая полу</returns>
        public static string GenderToString(GenderEnum gender)
        {
            switch (gender)
            {
                case GenderEnum.Female:
                {
                    return PersonLibrary.FemaleGender;                   
                }
                case GenderEnum.Male:
                {
                    return PersonLibrary.MaleGender;
                }
            }
            throw new ArgumentException("Такого пола нет!");
        }
        /// <summary>
        /// Функция для задания пола в соответствии с введённым символом
        /// </summary>
        /// <param name="genderString">Строка ввода пола</param>
        /// <returns>
        /// Пол
        /// </returns>
        public static GenderEnum GenderSetter(string genderString)
        {
            switch (genderString)
            {
                case "м":
                case "М":
                case "M":
                case "m":
                    return GenderEnum.Male;
                case "ж":
                case "Ж":
                case "F":
                case "f":
                    return GenderEnum.Female;
            }
            return GenderEnum.NotDefined;
        }
        /// <summary>
        /// Процедура для вывода списка персон
        /// </summary>
        /// <param name="people">Список персон</param>
        public static void ListWrite(PersonList people)
        {
            TextWriteLine(null, 0);
            var personQuantity = people.PersonCount();

            for (int i = 0; i < personQuantity; i++)
            {
                string message = $"Ввод данных о {i + 1}-й персоне";
                TextWriteLine(message, ConsoleColor.White);
                TextWriteLine(people.Data[i].GetPersonInfo(), ConsoleColor.White);
                TextWriteLine(null, 0);
            }
        }

        /// <summary>
        /// Процедура вывода всех списков
        /// </summary>
        /// <param name="message">Сообщение при выводе</param>
        /// <param name="peopleList">Массив списков персон</param>
        public static void AllListWrite(string message, PersonList[] peopleList)
        {
            int personListQuantity = peopleList.Length;
            TextWriteLine(message, ConsoleColor.DarkCyan);
            TextWriteLine(null, 0);

            for (int i = 0; i < personListQuantity; i++)
            {
                TextWriteLine($"{i + 1}-ый список", ConsoleColor.Green);
                TextWriteLine(null, 0);
                if (peopleList[i].PersonCount() == 0)
                {
                    TextWriteLine($"{i + 1}-ый список очищен!", ConsoleColor.Red);
                    TextWriteLine(null, 0);
                }
                else
                {
                    ListWrite(peopleList[i]);
                }
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
                if (PersonBase.PatternCoincidence(inputString, keyInfo.KeyChar, pattern, stringMaxLength)
                   || (keyInfo.Key == ConsoleKey.Backspace))
                {
                    if (keyInfo.Key != ConsoleKey.Backspace)
                    {
                        inputString += keyInfo.KeyChar;

                        if (inputType != InputTypeEnum.Text)
                        {
                            if (inputString != "0")
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                            else
                            {
                                inputString = "";
                                TextWrite("");
                            }
                        }
                        else
                        {
                            if (PersonBase.ExceptionCoincidence(inputString))
                            {
                                inputString = inputString.Substring(0, inputString.Length - 1);
                                TextWrite("");
                            }
                            else
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
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
        private static void PersonRead(Action<string> action, string message, InputTypeEnum inputType)
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
                    return ConditionInput(Pattern.DigitPattern, byte.MaxValue, InputTypeEnum.Digit);
                }
                case InputTypeEnum.Gender:
                {
                    return ConditionInput(Pattern.GenderPattern, 1, InputTypeEnum.Gender); ;
                }
                case InputTypeEnum.Text:
                {
                    return ConditionInput(Pattern.TextPattern, byte.MaxValue, InputTypeEnum.Text); 
                }
                default:
                {
                    return ConditionInput(@".", byte.MaxValue, InputTypeEnum.Mix);
                }
            }
        }

        /// <summary>
        /// Функция выбора строки, описывающей пол персоны в какой-либо ситуации
        /// </summary>
        /// <param name="gender">Пол персоны</param>
        /// <param name="maleString">Строка, характеризующая персону как мужчину</param>
        /// <param name="femaleString">Строка, характеризующая персону как женщину</param>
        /// <returns>Строка, описывающая пол персоны в какой-либо ситуации</returns>
        public static string GenderChoice(GenderEnum gender, string maleString, string femaleString)
        {
            string genderString = null;
            switch (gender)
            {
                case GenderEnum.Male:
                    genderString = maleString;
                    break;
                case GenderEnum.Female:
                    genderString = femaleString;
                    break;
            }
            return genderString;
        }

        /// <summary>
        /// Функция InputPerson для ввода персоны
        /// </summary>
        /// <returns>Введённая персона</returns>
        public static object InputPerson(PersonBase inputPerson)
        {
            PersonRead(inputString => inputPerson.Surname = inputString,
                Pattern.SurnameInputMessage, InputTypeEnum.Text);
            PersonRead(inputString => inputPerson.Name = inputString,
                Pattern.NameInputMessage, InputTypeEnum.Text);
            PersonRead(inputString => inputPerson.Age = int.Parse(inputString),
                Pattern.AgeInputMessage, InputTypeEnum.Digit);
            PersonRead(inputString => inputPerson.Gender = GenderSetter(inputString),
                Pattern.GenderInputMessage, InputTypeEnum.Gender);

            return inputPerson;
        }
        public static Adult InputAdult()
        {
            Adult inputPerson = new Adult();

            inputPerson = (Adult)InputPerson(inputPerson);
            TextWriteLine("Супруг(а) выбран(а) случайным образом", ConsoleColor.DarkCyan);
            inputPerson.Spouse = Randomizer.GetRandomAdult();
            PersonRead(inputString => inputPerson.Job = inputString,
                Pattern.JobOutputMessage, InputTypeEnum.Mix);

            return inputPerson;
        }

        public static Child InputChild()
        {
            Child inputPerson = new Child();
            inputPerson = (Child)InputPerson(inputPerson);

            TextWriteLine("Мать ребёнка сгенерирована случайным образом", ConsoleColor.DarkCyan);
            inputPerson.Mother = Randomizer.GetRandomAdult();
            TextWriteLine("Отец ребёнка сгенерирован случайным образом", ConsoleColor.DarkCyan);
            inputPerson.Father = Randomizer.GetRandomAdult();
            PersonRead(inputString => inputPerson.EducationCenter = inputString,
                Pattern.EducationCenterOutputMessage, InputTypeEnum.Mix);

            return inputPerson;
        }
        #endregion
    }
}
