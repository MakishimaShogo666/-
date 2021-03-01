using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

///// <summary>
///// Перечисление типов ввода
///// </summary>
//public enum InputType
//{
//    Digit, //число (цифра)
//    Gender, //пол
//    Text //текст
//}

///// <summary>
///// Класс для ввода-вывода данных
///// </summary>
//public class InputOutput
//{
//    #region Процедуры
//    /// <summary>
//    /// Процедура для записи символов в новую строку
//    /// </summary>
//    /// <param name="text">Вводимый символ</param>
//    public static void TextWriteLine(object text, ConsoleColor color)
//    {
//        if (text != null)
//        {
//            Console.ForegroundColor = color;
//            Console.WriteLine(text);
//            Console.ResetColor();
//        }
//        else Console.WriteLine();
//    }
//    /// <summary>
//    /// Процедура для записи в текущую строку 
//    /// </summary>
//    /// <param name="text">Вводимый символ</param>
//    public static void TextWrite(object text)
//    {
//        if (text != null)
//        {
//            Console.Write(text);
//        }
//        else Console.Write("");
//    }
//    /// <summary>
//    /// Процедура для вывода персоны
//    /// </summary>
//    /// <param name="person">Персона</param>
//    public static void PersonWrite(string message, Person person)
//    {
//        TextWriteLine(message, ConsoleColor.Blue);
//        TextWriteLine(null, 0);
//        TextWriteLine(Pattern.SurnameOutputTemplate + person.Surname, ConsoleColor.White);
//        TextWriteLine(Pattern.NameOutputTemplate + person.Name, ConsoleColor.White);
//        TextWriteLine(Pattern.AgeOutputTemplate + person.Age, ConsoleColor.White);
//        switch (person.Gender)
//        {
//            case GenderList.Male:
//                TextWriteLine(Pattern.GenderOutputTemplate + "мужской", ConsoleColor.White);
//                break;
//            case GenderList.Female:
//                TextWriteLine(Pattern.GenderOutputTemplate + "женский", ConsoleColor.White);
//                break;
//        }
//        TextWriteLine(null, 0);
//    }
//    /// <summary>
//    /// Процедура для вывода списка персон
//    /// </summary>
//    /// <param name="personQuantity">Число персон в списке</param>
//    /// <param name="people">Список персон</param>
//    public static void ListWrite(int personQuantity, PersonList people)
//    {
//        for (int i = 0; i < personQuantity; i++)
//        {
//            PersonWrite($"Ввод данных о {i + 1}-й персоне", people.data[i]);
//        }
//    }

//    public static void ListPrint(string message, int personListQuantity, PersonList[] people)
//    {
//        TextWriteLine(message, ConsoleColor.DarkCyan);
//        TextWriteLine(null, 0);

//        for (int i = 0; i < personListQuantity; i++)
//        {
//            TextWriteLine($"{i + 1}-ый список", ConsoleColor.Green);
//            TextWriteLine(null, 0);
//            if (people[i].PersonCount() == 0)
//            {
//                TextWriteLine($"{i + 1}-ый список очищен!", ConsoleColor.Red);
//                TextWriteLine(null, 0);
//            }
//            else
//            {
//                ListWrite(people[i].PersonCount(), people[i]);
//            }
//        }
//    }
//    /// <summary>
//    /// Процедура проверки условий ввода символов
//    /// </summary>
//    /// <param name="inputString">Выходная строка ввода</param>
//    /// <param name="pattern">Шаблон ввода</param>
//    /// <param name="stringMaxLength">Максимальная длина строки</param>
//    /// <param name="inputType">Тип ввода</param>
//    private static void ConditionInput(out string inputString, string pattern, byte stringMaxLength, InputType inputType)
//    {
//        inputString = "";
//        while (true)
//        {
//            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//            //Если символ клавиши совпадает с шаблоном ввода и число символов в строке меньше максимального
//            //или нажата клавиша Backspace, то выполняется процедура проверки ввода
//            //
//            if (Person.PatternCoincidence(inputString, keyInfo.KeyChar, pattern, stringMaxLength)
//               || (keyInfo.Key == ConsoleKey.Backspace))
//            {
//                // Если введённая клавиша не BackSpace, то осуществляется ввод в inputString
//                //
//                if (keyInfo.Key != ConsoleKey.Backspace)
//                {
//                    inputString += keyInfo.KeyChar;

//                    // Если вводится не текст, то строка ввода проверяется на наличие 0
//                    //
//                    if (inputType != InputType.Text)
//                    {
//                        // Если переменная inputString не содержит только 0, то вводится значение с клавиатуры
//                        //
//                        if (inputString != "0")
//                        {
//                            TextWrite(keyInfo.KeyChar);
//                        }
//                        // Иначе ничего не записывается
//                        //
//                        else
//                        {
//                            inputString = "";
//                            TextWrite("");
//                        }
//                    }
//                    // Иначе происходит проверка на повторение разделителей слов
//                    //
//                    else
//                    {
//                        if (Person.ExceptionCoincidence(inputString) == false)
//                        {
//                            TextWrite(keyInfo.KeyChar);
//                        }
//                        else
//                        {
//                            inputString = inputString.Substring(0, inputString.Length - 1);
//                            TextWrite("");
//                        }
//                    }
//                }
//                // Иначе удаляется предыдущий символ
//                //
//                else
//                {
//                    // Если переменная inputString не пустая, то удаляется один символ
//                    //
//                    if (inputString != "")
//                    {
//                        // Удаление последнего символа из консоли
//                        //
//                        TextWrite("\b \b");
//                        inputString = inputString.Substring(0, inputString.Length - 1);
//                    }
//                }
//            }
//            // Если нажата клавиша Enter и строка не пустая, то ввод завершён
//            //
//            if ((keyInfo.Key == ConsoleKey.Enter) && (inputString != ""))
//            {
//                TextWriteLine(null, 0);
//                break;
//            }
//        }
//    }
//    #endregion

//    #region Функции
//    /// <summary>
//    /// Функция для выхода из программы 
//    /// </summary>
//    /// <returns>
//    /// true, если выбран выход из программы
//    /// </returns>
//    public static bool QuitOfProgram()
//    {
//        TextWriteLine("\n" + "Для продолжения работы программы нажмите Enter, " +
//            "для выхода из программы нажмите любую другую клавишу" + "\n", ConsoleColor.Cyan);
//        return Console.ReadKey().Key == ConsoleKey.Enter;
//    }
//    /// <summary>
//    /// Функция Input для ввода данных
//    /// </summary>
//    /// <param name="message">Сообщение для ввода</param>
//    /// <param name="inputType">Тип ввода</param>
//    /// <returns>
//    /// inputString - введённая строка
//    /// </returns>
//    public static string Input(string message, InputType inputType)
//    {
//        string inputString;
//        TextWrite(message);
//        switch (inputType)
//        {
//            case InputType.Digit:
//                ConditionInput(out inputString, Pattern.DigitPattern, byte.MaxValue, InputType.Digit);
//                return inputString;
//            case InputType.Gender:
//                ConditionInput(out inputString, Pattern.GenderPattern, 1, InputType.Gender);
//                return inputString;
//            default:
//                ConditionInput(out inputString, Pattern.TextPattern, byte.MaxValue, InputType.Text);
//                if (inputString != "")
//                {
//                    inputString = Person.RegisterChanger(inputString, Pattern.Delimiters);
//                }
//                return inputString;
//        }
//    }
//    /// <summary>
//    /// Функция проверки ввода
//    /// </summary>
//    /// <param name="Template">Шаблон ввода</param>
//    /// <param name="inputType">Тип ввода</param>
//    /// <returns>
//    /// Проверенная введённая строка
//    /// </returns>
//    public static object CheckInput(string Template, InputType inputType)
//    {
//        if (inputType == InputType.Digit)
//        {
//            int varString;
//            while (true)
//            {
//                try
//                {
//                    varString = Person.AgeCompare(Input(Template, inputType));
//                    break;
//                }
//                catch (Exception ex)
//                {
//                    TextWriteLine(ex.Message, ConsoleColor.Red);
//                    continue;
//                }
//            }
//            return varString;
//        }
//        else
//        {
//            string varString;
//            while (true)
//            {
//                try
//                {
//                    varString = Input(Template, inputType);
//                    break;
//                }
//                catch (Exception ex)
//                {
//                    TextWriteLine(ex.Message, ConsoleColor.Red);
//                    continue;
//                }
//            }
//            return varString;
//        }
//    }
//    #endregion
//}