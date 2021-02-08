using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

public class OutputInformation
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
    /// Метод Timer для отсчёта времени для корректной работы GetRandomPerson
    /// </summary>
    public static void Timer()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Thread.Sleep(5);
        stopwatch.Stop();
    }
    /// <summary>
    /// Функция Input для ввода данных
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="type"></param>
    /// <returns>
    /// Возвращается InputString - введённая строка
    /// </returns>
    public static string Input(string condition, byte type)
    {
        string InputString = ""; 
        string DigitPattern = @"[0-9]"; // Шаблон для ввода цифр
        string GenderPattern = @"[mfMFмжМЖ]"; // Шаблон для ввода пола
        string NamePattern = @"([a-zA-Z]|[а-яА-Я]|[ -])"; // Шаблон для ввода текста (имён и фамилий)
        string NameException = @"(- |  | -|--)"; // Шаблон для исключения повторения разделителей слов
        char[] Delimiters = new char[] { ' ', '-' }; // Массив символов разделителей слов
        TextWrite(condition);
        switch (type)
        {
            case 1:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    //Если вводятся клавиши, удовлетворяющие шаблону или клавиша Backspace
                    //
                    if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), DigitPattern) == true)
                       || (keyInfo.Key == ConsoleKey.Backspace)))
                    {
                        // Если введённая клавиша не BackSpace, то осуществляется ввод в InputString
                        //
                        if (keyInfo.Key != ConsoleKey.Backspace)
                        {
                            InputString = InputString + keyInfo.KeyChar;

                            // Если переменная InputString не содержит только 0, то вводится значение с клавиатуры
                            //
                            if (InputString != "0") 
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                            else // Иначе ничего не записывается
                            {
                                InputString = "";
                                TextWrite("");
                            }
                        }
                        else // Иначе удаляется предыдущий символ
                        {
                            if (InputString != "") // Если переменная InputString не пустая, то удаляется один символ
                            {
                                TextWrite("\b \b"); // Удаление последнего символа из консоли
                                InputString = InputString.Substring(0, InputString.Length - 1); 
                            }
                        }
                    }
                    // Если нажата клавиша Enter и строка не пустая, то ввод завершён
                    //
                    if ((keyInfo.Key == ConsoleKey.Enter) && (InputString != "")) 
                    {
                        break;
                    }
                }
                TextWriteLine(null);
                try
                {
                    return Int32.Parse(InputString).ToString();
                }
                catch (FormatException)
                {
                    InputString = "0";
                    return Int32.Parse(InputString).ToString();
                }
                catch (OverflowException)
                {
                    InputString = $"{Int32.MaxValue}";
                    return Int32.Parse(InputString).ToString();
                }
            case 2:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), GenderPattern) == true) 
                       && (InputString.Length < 1)) || (keyInfo.Key == ConsoleKey.Backspace))
                    {
                        if (keyInfo.Key != ConsoleKey.Backspace)
                        {
                            InputString = InputString + keyInfo.KeyChar;
                            if (InputString != "0")
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                            else
                            {
                                InputString = "";
                                TextWrite("");
                            }
                        }
                        else
                        {
                            if (InputString != "")
                            {
                                TextWrite("\b \b");
                                InputString = InputString.Substring(0, InputString.Length - 1);
                            }
                        }
                    }
                    if ((keyInfo.Key == ConsoleKey.Enter) && (InputString != ""))
                        {
                        break;
                    }
                }
                TextWriteLine(null);
                return InputString;
            default:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if ((Regex.IsMatch(keyInfo.KeyChar.ToString(), NamePattern) == true) 
                       || (keyInfo.Key == ConsoleKey.Backspace))
                    {
                        if (keyInfo.Key != ConsoleKey.Backspace) 
                        {
                            InputString = InputString + keyInfo.KeyChar;
                            if (Regex.IsMatch(InputString, NameException) == true)
                            {
                                InputString = InputString.Substring(0, InputString.Length - 1);
                                TextWrite("");
                            }
                            else
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                        }
                        else
                        {
                            if ((InputString != "") & (InputString.Length != 0))
                            {
                                TextWrite("\b \b");
                                InputString = InputString.Substring(0, InputString.Length - 1);
                            }
                        }
                    }
                    if ((keyInfo.Key == ConsoleKey.Enter) && (InputString != ""))
                    {
                        break;
                    }
                }
                if (InputString!="")
                {
                    InputString = Person.RegisterChanger(InputString, Delimiters);
                }
                TextWriteLine(null);
                return InputString;
        }
    }
}
