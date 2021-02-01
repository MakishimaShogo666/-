using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;

/// <summary>
/// Перечисление полов, nd - not defined (неопределённый пол)
/// </summary>
public enum GenderList
{
    //TODO: RSDN +
    мужской, 
    женский, 
    nd
}

/// <summary>
/// Класс Person
/// </summary>
public class Person
{
    //TODO: Properties
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname; 
    public string Name; // Имя
    public int Age; // Возраст
    public GenderList Gender; // Пол
    
    /// <summary>
    /// Конструктор класса Person по умолчанию
    /// </summary>
    public Person() : this("Нет данных", "Нет данных", 0, GenderList.nd) { }

    // Конструктор класса Person для создания персоны вручную
    //
    public Person(string SurnameInput, string NameInput, int AgeInput, GenderList GenderInput)
    {
        Surname = SurnameInput;
        Name = NameInput;
        Age = AgeInput;
        Gender = GenderInput;
    }

    // Конструктор класса Person для создания случайной персоны заданного пола с указанным предпочтительным возрастом (выбирается случайный)
    //
    public Person(int average_age, GenderList GenderInput)
    {
        Random RandomNumber = new Random();
        Age = RandomNumber.Next(average_age/2 + 1, average_age * 2);
        Gender = GenderInput;
        
        
        switch (Gender)
        {
            case GenderList.мужской:
                // Выбор фамилии из библиотеки мужских фамилий
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)]; 
                Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                break;
            case GenderList.женский:
                Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                break;
        }
    }

    // Конструктор класса Person для создания случайной персоны заданного возраста
    //
    public Person(int AgeInput)
    {
        Random RandomNumber = new Random();
        Age = AgeInput;
        Gender = (GenderList)RandomNumber.Next(0, 2);
        //TODO: RSDN 
        switch (Gender)
        {
            case GenderList.мужской:
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                break;
            case GenderList.женский:
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                break;
        }
    }

    // Метод PersonWrite для записи информации о персоне в консоль
    //
    public static void PersonWrite(Person person)
    {
        Console.WriteLine(PersonTemplate.SurnameOutputTemplate + person.Surname);
        Console.WriteLine(PersonTemplate.NameOutputTemplate + person.Name);
        Console.WriteLine(PersonTemplate.AgeOutputTemplate + person.Age);
        Console.WriteLine(PersonTemplate.GenderOutputTemplate + person.Gender);
    }

    // Функция InputDigit для ввода цифр в консоль с предлагаемым пользователю условием
    //
    public static int InputDigit(string condition) 
    {
        string InputString = ""; // Инициализация переменной для записи в неё введённых в консоль значений
        string DigitPattern = @"[0-9]"; // Шаблон для ввода цифр
        Console.Write(condition);

        // Цикл выполняется до тех пор, пока пользователь не введёт клавишу Enter
        //
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Объясвление и инициализация переменной, соответствующей нажатой клавише без отображения в консоли (true)

            // Если или введена цифра и длина строки в консоли меньше 3-х символов, или нажата клавиша Backspace,
            // то данные клавиши вводятся в консоль
            //
            if (((Regex.IsMatch(keyInfo.KeyChar.ToString(), DigitPattern) == true)
                && (InputString.Length < 3)) 
                || (keyInfo.Key == ConsoleKey.Backspace))
            {
                if (keyInfo.Key != ConsoleKey.Backspace) // Если введённая клавиша не BackSpace, то осуществляется ввод в консоль и переменную InputString
                {
                    InputString = InputString + keyInfo.KeyChar;
                    if (InputString != "0") // Если переменная InputString не содержит только 0, то вводится значение с клавиатуры
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                    else // Иначе в консоль и переменную ничего не записывается
                    {
                        InputString = "";
                        Console.Write("");
                    }
                }
                else // Иначе удаляется предыдущий символ
                {
                    if (InputString != "") // Если переменная InputString не пустая, то удаляется один символ
                    {
                        Console.Write("\b \b"); // Удаление последнего символа из консоли
                        InputString = InputString.Substring(0, InputString.Length - 1); // Удаление последнего символа из InputString
                    }
                }
            }
            if (keyInfo.Key == ConsoleKey.Enter) // Если нажата клавиша Enter, то ввод цифр завершён
            {
                break;
            }
        }

        Console.WriteLine();
        
        // Обработка исключения на случай ввода пустой строки
        //
        try
        {
            return Int32.Parse(InputString);
        }
        catch(FormatException)
        {
            InputString = "0";
            return Int32.Parse(InputString);
        }
    }

    /// <summary>
    /// Функция InputGender для ввода определённых символов в консоль с предлагаемым пользователю условием
    /// </summary>
    /// <param name="condition"> - Условие, предъявляемое пользователю</param>
    /// <returns> 
    /// Возвращается пол персоны 
    /// </returns>
    public static string InputGender(string condition)
    {
        string InputString = ""; // Инициализация переменной для записи в неё введённых в консоль значений
        string GenderPattern = @"[mfMFмжМЖ]"; // Шаблон для ввода цифр
        Console.Write(condition);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Если или введены соответствующие шаблону цифры и длина строки в консоли меньше 1-го символа,
            // или нажата клавиша Backspace, то данные клавиши вводятся в консоль
            // (остальное - аналогично InputDigit())
            // TODO: Логические операторы
            if (((Regex.IsMatch(keyInfo.KeyChar.ToString(),GenderPattern)==true) &(InputString.Length < 1))|(keyInfo.Key == ConsoleKey.Backspace))
            {
                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    InputString = InputString + keyInfo.KeyChar;
                    if (InputString != "0")
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                    else
                    {
                        InputString = "";
                        Console.Write("");
                    }
                }
                else
                {
                    if (InputString != "")
                    {
                        Console.Write("\b \b");
                        InputString = InputString.Substring(0, InputString.Length - 1);
                    }
                }
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
        Console.WriteLine();
        return InputString;
    }

    /// <summary>
    /// Функция InputName для ввода определённых символов в консоль с предлагаемым пользователю условием
    /// </summary>
    /// <param name="condition"> - Условие, предъявляемое пользователю </param>
    /// <returns> 
    /// Строка с фамилией или именем 
    /// </returns>
    public static string InputName(string condition)
    {
        string InputString = ""; // Инициализация переменной для записи в неё введённых в консоль значений
        string NamePattern = @"([a-zA-Z]|[а-яА-Я]|[ -])"; // Шаблон для ввода текста
        string NameException = @"(- |  | -|--)"; // Шаблон для исключения повторения разделителей слов
        char[] Delimiters = new char[] { ' ', '-' }; // Массив символов разделителей слов

        Console.Write(condition);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Если введены соответствующие шаблону цифры или нажата клавиша Backspace, то данные клавиши вводятся в консоль
            // TODO: Логические операторы
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
                        Console.Write("");
                    }
                    else // Иначе - записываются
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else // Иначе - удаляется последний символ из консоли и InputString
                {
                    if ((InputString != "")&(InputString.Length!=0)) // Если InputString - не пустая строка, то последний символ удаляется
                    {
                        Console.Write("\b \b");
                        InputString = InputString.Substring(0, InputString.Length - 1);
                    }
                }
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
        Console.WriteLine();
        InputString = RegisterChanger(InputString, Delimiters); // Изменение регистра введённых данных
        return InputString;
    }

    /// <summary>
    /// Функция PersonRead для ввода данных о персоне из консоли
    /// </summary>
    /// <returns>
    /// Возвращается персона с заданными параметрами
    /// </returns>
    public static Person PersonRead()
    {
        Person Person = new Person(); // Создание экземпляра класса Person конструктором по умолчанию
        
        // Задание параметров персоны через консоль
        //
        Person.Surname = InputName(PersonTemplate.SurnameInputTemplate);
        Person.Name = InputName(PersonTemplate.NameInputTemplate);
        Person.Age = 0;
        Person.Age = InputDigit(PersonTemplate.AgeInputTemplate);
        
        // Если введённый возраст больше максимально возможного (118), то необходимо ввести возраст заново
        //
        while (Person.Age> PersonLibrary.MaxAge)
        {
            Console.WriteLine($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            Person.Age = InputDigit(PersonTemplate.AgeInputTemplate);
        }

        // Ввод пола
        //
        string GenderString = InputGender(PersonTemplate.GenderInputTemplate);
        
        switch (GenderString) // выбор цифры на основе введённого в консоль символа 
        {
            case "м":
            case "М":
            case "M":
            case "m":
                Person.Gender = GenderList.мужской;
                break;
            case "ж":
            case "Ж":
            case "F":
            case "f":
                Person.Gender = GenderList.женский;
                break;
        }

        return Person;
    }

    /// <summary>
    /// Функция RegisterChanger для изменения регистра введённых фамилии или имени персоны
    /// </summary>
    /// <param name="InputString"></param>
    /// <param name="Delimiters"></param>
    /// <returns>
    /// Возвращается строка с изменённым регистром фамилии или имени персоны
    /// </returns>
    public static string RegisterChanger(string InputString,char[] Delimiters)
    {
        string[] SplittedInputString = InputString.Split(Delimiters); // Разбиение введённой строки на слова (в случае сложных имени или фамилии)
        foreach (string s in SplittedInputString) // Для каждого слова в строке осуществляется изменение регистра
        {
            string s0 = s;
            s0 = s.ToLower(); // Перевод всего слова в нижний регистр
            s0 = Char.ToUpper(s0[0]) + s0.Substring(1); // Перевод первого символа слова в верхний регистр
            InputString = InputString.Replace(s, s0); // Замена слова в исходной строке
        }
        return InputString;
    }

    /// <summary>
    /// Функция GetRandomPerson для ввода случайной персоны
    /// </summary>
    /// <returns>
    /// Возвращается случайная персона
    /// </returns>
    public static Person GetRandomPerson()
    {
        Person Person = new Person();
        Random RandomNumber = new Random(); // создание экземппляра объекта класса Random для генерации случайных (псевдослучайных) чисел
        Person.Age = RandomNumber.Next(PersonLibrary.MaxAge); // задание случайного возраста в диапазоне от 0 до максимально возможного возраста
        Person.Gender = (GenderList)RandomNumber.Next(0, 2); // задание случайного пола

        switch (Person.Gender) // выбор стандартных фамилии и имени на основе пола
        {
            case GenderList.мужской:
                Person.Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                Person.Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                break;
            case GenderList.женский:
                Person.Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                Person.Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                break;
        }
        return Person;
    }
}

/// <summary>
/// Класс PersonLibrary - библиотека стандартных имён и фамилий
/// </summary>
public class PersonLibrary
{
    public static string[] StandardMaleSurnameLibrary = new string[] { "Иванов", "Петров", "Сидоров", "Сергеев" }; // Мужские фамилии
    public static string[] StandardFemaleSurnameLibrary = new string[] { "Иванова", "Петрова", "Сидорова", "Сергеева" }; // Женские фамилии
    public static string[] StandardMaleNameLibrary = new string[] { "Иван", "Андрей", "Александр", "Константин", "Сергей", "Дмитрий" }; // Мужские имена
    public static string[] StandardFemaleNameLibrary = new string[] { "Татьяна", "Светлана", "Наталья", "Александра", "Элла", "Дарья" }; // Женские имена

    public static int StandardMaleNameCount = StandardMaleNameLibrary.Length; // Число стандартных мужских имён
    public static int StandardMaleSurnameCount = StandardMaleSurnameLibrary.Length; // Число стандартных мужских фамилий
    public static int StandardFemaleNameCount = StandardFemaleNameLibrary.Length; // Число стандартных женских имён
    public static int StandardFemaleSurnameCount = StandardFemaleSurnameLibrary.Length; // Число стандартных женских фамилий

    public static int MaxAge = 118; // Максимально возможный возраст персоны
}

/// <summary>
/// Класс PersonTemplate - библиотека шаблонов строк для вывода в консоль информации о персоне
/// </summary>
public class PersonTemplate
{
    public static string SurnameInputTemplate = "Введите фамилию персоны: ";
    public static string NameInputTemplate = "Введите имя персоны: ";
    public static string AgeInputTemplate = "Введите возраст персоны: ";
    public static string GenderInputTemplate = "Введите пол персоны (м/М/m/M - мужской, ж/Ж/f/F - женский): ";

    public static string SurnameOutputTemplate = "Фамилия: ";
    public static string NameOutputTemplate = "Имя: ";
    public static string AgeOutputTemplate = "Возраст: ";
    public static string GenderOutputTemplate = "Пол: ";
}