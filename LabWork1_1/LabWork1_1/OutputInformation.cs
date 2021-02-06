using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;

public class OutputInformation
{
    public static void TextWriteLine(object text)
    {
        if (text != null)
        {
            Console.WriteLine(text);
        }
        else Console.WriteLine();
    }
    public static void TextWrite(object text)
    {
        if (text != null)
        {
            Console.Write(text);
        }
        else Console.Write("");
    }
    public static bool QuitOfProgram(bool a)
    {
        TextWriteLine("\n" + "Для продолжения работы программы нажмите Enter, для выхода из программы нажмите любую другую клавишу" + "\n");
        if (Console.ReadKey().Key != ConsoleKey.Enter)//условие для выхода из программы
        {
            a = true;//выход из цикла (завершение работы программы)
        }
        return a;
    }
    public static void PersonWrite(Person person)
    {
        TextWriteLine(PersonTemplate.SurnameOutputTemplate + person.Surname);
        TextWriteLine(PersonTemplate.NameOutputTemplate + person.Name);
        TextWriteLine(PersonTemplate.AgeOutputTemplate + person.Age);
        TextWriteLine(PersonTemplate.GenderOutputTemplate + person.Gender);
        //Console.WriteLine(PersonTemplate.SurnameOutputTemplate + person.Surname);
        //Console.WriteLine(PersonTemplate.NameOutputTemplate + person.Name);
        //Console.WriteLine(PersonTemplate.AgeOutputTemplate + person.Age);
        //Console.WriteLine(PersonTemplate.GenderOutputTemplate + person.Gender);
    }
    public static void ListWrite(int PersonQuantity,PersonList People)
    {
        for (int i = 0; i < PersonQuantity; i++)
        {
            TextWriteLine($"Ввод данных о {i + 1}-й персоне");
            TextWriteLine(null);
            PersonWrite(People.data[i]);
            TextWriteLine(null);
        }
    }
    public static string Input(string condition, byte type)
    {
        string InputString = ""; // Инициализация переменной для записи в неё введённых в консоль значений
        string DigitPattern = @"[0-9]"; // Шаблон для ввода цифр
        string GenderPattern = @"[mfMFмжМЖ]"; // Шаблон для ввода цифр
        string NamePattern = @"([a-zA-Z]|[а-яА-Я]|[ -])"; // Шаблон для ввода текста
        string NameException = @"(- |  | -|--)"; // Шаблон для исключения повторения разделителей слов
        char[] Delimiters = new char[] { ' ', '-' }; // Массив символов разделителей слов
        TextWrite(condition);
            switch (type)
            {
                case 1:
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), DigitPattern) == true)
                        && (InputString.Length < 3))
                        || (keyInfo.Key == ConsoleKey.Backspace))
                    {
                        if (keyInfo.Key != ConsoleKey.Backspace) // Если введённая клавиша не BackSpace, то осуществляется ввод в консоль и переменную InputString
                        {
                            InputString = InputString + keyInfo.KeyChar;
                            if (InputString != "0") // Если переменная InputString не содержит только 0, то вводится значение с клавиатуры
                            {
                                TextWrite(keyInfo.KeyChar);
                            }
                            else // Иначе в консоль и переменную ничего не записывается
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
                                InputString = InputString.Substring(0, InputString.Length - 1); // Удаление последнего символа из InputString
                            }
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter) // Если нажата клавиша Enter, то ввод цифр завершён
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
                case 2:
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), GenderPattern) == true) & (InputString.Length < 1)) | (keyInfo.Key == ConsoleKey.Backspace))
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
                        if (keyInfo.Key == ConsoleKey.Enter)
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
                        if ((Regex.IsMatch(keyInfo.KeyChar.ToString(), NamePattern) == true) | (keyInfo.Key == ConsoleKey.Backspace))
                        {
                            if (keyInfo.Key != ConsoleKey.Backspace) // Если нажатая клавиша не Backspace, то данные вводятся в InputString и консоль
                            {
                                InputString = InputString + keyInfo.KeyChar;

                                // Если введён пробел или дефис после пробела или дефиса, то данные не заисываются
                                //
                                if (Regex.IsMatch(InputString, NameException) == true)
                                {
                                    InputString = InputString.Substring(0, InputString.Length - 1);
                                    TextWrite("");
                                }
                                else // Иначе - записываются
                                {
                                    TextWrite(keyInfo.KeyChar);
                                }
                            }
                            else // Иначе - удаляется последний символ из консоли и InputString
                            {
                                if ((InputString != "") & (InputString.Length != 0)) // Если InputString - не пустая строка, то последний символ удаляется
                                {
                                    TextWrite("\b \b");
                                    InputString = InputString.Substring(0, InputString.Length - 1);
                                }
                            }
                        }
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        // Изменение регистра введённых данных
                    }
                if (InputString!="")
                {
                    InputString = Person.RegisterChanger(InputString, Delimiters);
                }
                //InputString = Person.RegisterChanger(InputString, Delimiters);
                TextWriteLine(null);
                return InputString;
        }
        }
    }
