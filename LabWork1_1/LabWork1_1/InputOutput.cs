using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using LabWork1_1;

/// <summary>
/// Перечисление типов ввода
/// </summary>
public enum InputType
{
    Digit,
    Gender,
    Text
}

public class InputOutput
{
    /// <summary>
    /// Метод TextWriteLine для записи в новую строку
    /// </summary>
    /// <param name="text"></param>
    public static void TextWriteLine(object text)
    {
        if (text != null)
        {
            Console.WriteLine(text);
        }
        else Console.WriteLine();
    }
    /// <summary>
    /// Метод TextWrite для записи в текущую строку 
    /// </summary>
    /// <param name="text"></param>
    public static void TextWrite(object text)
    {
        if (text != null)
        {
            Console.Write(text);
        }
        else Console.Write("");
    }
    /// <summary>
    /// Функция QuitOfProgram для выхода из программы 
    /// </summary>
    /// <param name="a"></param>
    /// <returns>
    /// Возвращается true, если выбран выход из программы
    /// </returns>
    public static bool QuitOfProgram(bool a)
    {
        TextWriteLine("\n" + "Для продолжения работы программы нажмите Enter, " +
            "для выхода из программы нажмите любую другую клавишу" + "\n");
        if (Console.ReadKey().Key != ConsoleKey.Enter)//если нажата не клавиша Enter, то выход из программы
        {
            a = true;
        }
        return a;
    }
    /// <summary>
    /// Метод PersonWrite для записи персоны 
    /// </summary>
    /// <param name="person"></param>
    public static void PersonWrite(Person person)
    {
        TextWriteLine(PersonTemplate.SurnameOutputTemplate + person.Surname);
        TextWriteLine(PersonTemplate.NameOutputTemplate + person.Name);
        TextWriteLine(PersonTemplate.AgeOutputTemplate + person.Age);
        switch (person.Gender)
        {
            case GenderList.Male:
                TextWriteLine(PersonTemplate.GenderOutputTemplate + "мужской");
                break;
            case GenderList.Female:
                TextWriteLine(PersonTemplate.GenderOutputTemplate + "женский");
                break;
        }
    }
    /// <summary>
    /// Метод ListWrite для записи списка персон
    /// </summary>
    /// <param name="personQuantity"></param>
    /// <param name="people"></param>
    public static void ListWrite(int personQuantity, PersonList people)
    {
        for (int i = 0; i < personQuantity; i++)
        {
            TextWriteLine($"Ввод данных о {i + 1}-й персоне");
            TextWriteLine(null);
            PersonWrite(people.data[i]);
            TextWriteLine(null);
        }
    }
    /// <summary>
    /// Функция Input для ввода данных
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="type"></param>
    /// <returns>
    /// Возвращается inputString - введённая строка
    /// </returns>
    public static string Input(string condition, InputType inputType)
    {
        string inputString = ""; 
        string digitPattern = @"[0-9]"; // Шаблон для ввода цифр
        string genderPattern = @"[mfMFмжМЖ]"; // Шаблон для ввода пола
        string namePattern = @"([a-zA-Z]|[а-яА-Я]|[ -])"; // Шаблон для ввода текста (имён и фамилий)
        string nameException = @"(- |  | -|--)"; // Шаблон для исключения повторения разделителей слов
        char[] delimiters = new char[] { ' ', '-' }; // Массив символов разделителей слов
        TextWrite(condition);
        switch (inputType)
        {
            case InputType.Digit:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    //Если вводятся клавиши, удовлетворяющие шаблону или клавиша Backspace
                    //
                    if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), digitPattern) == true)
                       || (keyInfo.Key == ConsoleKey.Backspace)))
                    {
                        // Если введённая клавиша не BackSpace, то осуществляется ввод в inputString
                        //
                        if (keyInfo.Key != ConsoleKey.Backspace)
                        {
                            inputString = inputString + keyInfo.KeyChar;

                            // Если переменная inputString не содержит только 0, то вводится значение с клавиатуры
                            //
                            if (inputString != "0") 
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                            else // Иначе ничего не записывается
                            {
                                inputString = "";
                                TextWrite("");
                            }
                        }
                        else // Иначе удаляется предыдущий символ
                        {
                            if (inputString != "") // Если переменная inputString не пустая, то удаляется один символ
                            {
                                TextWrite("\b \b"); // Удаление последнего символа из консоли
                                inputString = inputString.Substring(0, inputString.Length - 1); 
                            }
                        }
                    }
                    // Если нажата клавиша Enter и строка не пустая, то ввод завершён
                    //
                    if ((keyInfo.Key == ConsoleKey.Enter) && (inputString != "")) 
                    {
                        break;
                    }
                }
                TextWriteLine(null);
                try
                {
                    return Int32.Parse(inputString).ToString();
                }
                catch (FormatException)
                {
                    inputString = "0";
                    return Int32.Parse(inputString).ToString();
                }
                catch (OverflowException)
                {
                    inputString = $"{Int32.MaxValue}";
                    return Int32.Parse(inputString).ToString();
                }
            case InputType.Gender:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), genderPattern) == true) 
                       && (inputString.Length < 1)) || (keyInfo.Key == ConsoleKey.Backspace))
                    {
                        if (keyInfo.Key != ConsoleKey.Backspace)
                        {
                            inputString = inputString + keyInfo.KeyChar;
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
                            if (inputString != "")
                            {
                                TextWrite("\b \b");
                                inputString = inputString.Substring(0, inputString.Length - 1);
                            }
                        }
                    }
                    if ((keyInfo.Key == ConsoleKey.Enter) && (inputString != ""))
                        {
                        break;
                    }
                }
                TextWriteLine(null);
                return inputString;
            default:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if ((Regex.IsMatch(keyInfo.KeyChar.ToString(), namePattern) == true) 
                       || (keyInfo.Key == ConsoleKey.Backspace))
                    {
                        if (keyInfo.Key != ConsoleKey.Backspace) 
                        {
                            inputString = inputString + keyInfo.KeyChar;
                            if (Regex.IsMatch(inputString, nameException) == true)
                            {
                                inputString = inputString.Substring(0, inputString.Length - 1);
                                TextWrite("");
                            }
                            else
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                        }
                        else
                        {
                            if ((inputString != "") & (inputString.Length != 0))
                            {
                                TextWrite("\b \b");
                                inputString = inputString.Substring(0, inputString.Length - 1);
                            }
                        }
                    }
                    if ((keyInfo.Key == ConsoleKey.Enter) && (inputString != ""))
                    {
                        break;
                    }
                }
                if (inputString!="")
                {
                    inputString = Person.RegisterChanger(inputString, delimiters);
                }
                TextWriteLine(null);
                return inputString;
        }
    }
}
