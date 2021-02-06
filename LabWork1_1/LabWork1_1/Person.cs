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
        Person.Surname = OutputInformation.Input(PersonTemplate.SurnameInputTemplate,3);
        Person.Name = OutputInformation.Input(PersonTemplate.NameInputTemplate,3);
        Person.Age = 0;
        Person.Age = Int32.Parse(OutputInformation.Input(PersonTemplate.AgeInputTemplate,1));
        
        // Если введённый возраст больше максимально возможного (118), то необходимо ввести возраст заново
        //
        while (Person.Age> PersonLibrary.MaxAge)
        {
            Console.WriteLine($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            Person.Age = Int32.Parse(OutputInformation.Input(PersonTemplate.AgeInputTemplate,1));
        }

        // Ввод пола
        //
        string GenderString = OutputInformation.Input(PersonTemplate.GenderInputTemplate,2);
        
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
            try
            {
                s0 = Char.ToUpper(s0[0]) + s0.Substring(1); // Перевод первого символа слова в верхний регистр
            }
            catch (IndexOutOfRangeException Exception)
            {
                OutputInformation.TextWriteLine(Exception.Message);
            }
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