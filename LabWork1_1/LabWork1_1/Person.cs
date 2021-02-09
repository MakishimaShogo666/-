using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;

/// <summary>
/// Перечисление полов, NotDefined - неопределённый пол
/// </summary>
public enum GenderList
{
    //TODO: RSDN +
    Male, 
    Female, 
    NotDefined
}

/// <summary>
/// Класс Person
/// </summary>
public class Person
{
    //TODO: Properties +
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; private set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; private set; }
    /// <summary>
    /// Пол
    /// </summary>
    public GenderList Gender { get; private set; }
    public static readonly int maxPersonQuantity = 1000;
    /// <summary>
    /// Конструктор класса Person по умолчанию
    /// </summary>
    public Person() : this("Нет данных", "Нет данных", 0, GenderList.NotDefined) { }

    /// <summary>
    /// Конструктор класса Person для создания персоны вручную
    /// </summary>
    public Person(string SurnameInput, string NameInput, int AgeInput, GenderList GenderInput)
    {
        Surname = SurnameInput;
        Name = NameInput;
        Age = AgeInput;
        Gender = GenderInput;
    }

    /// <summary>
    /// Конструктор класса Person для создания случайной персоны заданного пола с указанным предпочтительным возрастом
    /// </summary>
    public Person(int averageAge, GenderList GenderInput)
    {
        Random RandomNumber = new Random();
        Age = RandomNumber.Next(averageAge/2, averageAge + averageAge/2 + 1);
        Gender = GenderInput;
        
        switch (Gender)
        {
            case GenderList.Male:
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)]; 
                Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                break;
            case GenderList.Female:
                Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                break;
        }
    }

    /// <summary>
    /// Конструктор класса Person для создания случайной персоны заданного возраста
    /// </summary>
    public Person(int AgeInput)
    {
        Random RandomNumber = new Random();
        Age = AgeInput;
        Gender = (GenderList)RandomNumber.Next(0, 2);
        //TODO: RSDN 
        switch (Gender)
        {
            case GenderList.Male:
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                break;
            case GenderList.Female:
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
        Person Person = new Person(); 
        
        Person.Surname = OutputInformation.Input(PersonTemplate.SurnameInputTemplate,3);
        Person.Name = OutputInformation.Input(PersonTemplate.NameInputTemplate,3);
        Person.Age = Int32.Parse(OutputInformation.Input(PersonTemplate.AgeInputTemplate,1));
        
        while (Person.Age> PersonLibrary.MaxAge)
        {
            OutputInformation.TextWriteLine($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            Person.Age = Int32.Parse(OutputInformation.Input(PersonTemplate.AgeInputTemplate,1));
        }

        string GenderString = OutputInformation.Input(PersonTemplate.GenderInputTemplate,2);
        
        switch (GenderString) // выбор пола на основе введённого в консоль символа 
        {
            case "м":
            case "М":
            case "M":
            case "m":
                Person.Gender = GenderList.Male;
                break;
            case "ж":
            case "Ж":
            case "F":
            case "f":
                Person.Gender = GenderList.Female;
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
        string[] SplittedInputString = InputString.Split(Delimiters); // Разбиение введённой строки на слова
        foreach (string s in SplittedInputString) // Для каждого слова в строке осуществляется изменение регистра
        {
            string s0 = s.ToLower();

            try
            {
                s0 = Char.ToUpper(s0[0]) + s0.Substring(1); // Перевод первого символа слова в верхний регистр
            }
            catch (IndexOutOfRangeException ex)
            {
                OutputInformation.TextWriteLine(ex.Message);
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
        Random RandomNumber = new Random(); 
        Person.Age = RandomNumber.Next(PersonLibrary.MaxAge); 
        Person.Gender = (GenderList)RandomNumber.Next(0, 2); 

        switch (Person.Gender) // выбор стандартных фамилии и имени на основе пола
        {
            case GenderList.Male:
                Person.Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                Person.Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                break;
            case GenderList.Female:
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
    public static string[] StandardMaleSurnameLibrary = new string[] { "Иванов", "Петров", "Сидоров", "Сергеев" }; 
    public static string[] StandardFemaleSurnameLibrary = new string[] { "Иванова", "Петрова", "Сидорова", "Сергеева" };
    public static string[] StandardMaleNameLibrary = new string[] { "Иван", "Андрей", "Александр", "Константин", "Сергей", "Дмитрий" };
    public static string[] StandardFemaleNameLibrary = new string[] { "Татьяна", "Светлана", "Наталья", "Александра", "Элла", "Дарья" }; 

    public static int StandardMaleNameCount = StandardMaleNameLibrary.Length; 
    public static int StandardMaleSurnameCount = StandardMaleSurnameLibrary.Length; 
    public static int StandardFemaleNameCount = StandardFemaleNameLibrary.Length; 
    public static int StandardFemaleSurnameCount = StandardFemaleSurnameLibrary.Length; 

    public readonly static int MaxAge = 118; // Максимально возможный возраст персоны
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