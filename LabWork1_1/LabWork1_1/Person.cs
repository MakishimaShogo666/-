using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using LabWork1_1;

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
    /// <summary>
    /// Максимальный число персон в списке
    /// </summary>
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
        Age = RandomNumber.Next(averageAge / 2, averageAge + averageAge / 2 + 1);
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

        Person.Surname = InputOutput.Input(PersonTemplate.SurnameInputTemplate, InputType.Text);
        Person.Name = InputOutput.Input(PersonTemplate.NameInputTemplate, InputType.Text);
        Person.Age = Int32.Parse(InputOutput.Input(PersonTemplate.AgeInputTemplate, InputType.Digit));

        while (Person.Age > PersonLibrary.MaxAge)
        {
            InputOutput.TextWriteLine($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            Person.Age = Int32.Parse(InputOutput.Input(PersonTemplate.AgeInputTemplate, InputType.Digit));
        }

        string GenderString = InputOutput.Input(PersonTemplate.GenderInputTemplate, InputType.Gender);

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
    public static string RegisterChanger(string InputString, char[] Delimiters)
    {
        string[] SplittedInputString = InputString.Split(Delimiters,StringSplitOptions.RemoveEmptyEntries); // Разбиение введённой строки на слова
        foreach (string s in SplittedInputString) // Для каждого слова в строке осуществляется изменение регистра
        {
            string s0 = s.ToLower();

            try
            {
                s0 = Char.ToUpper(s0[0]) + s0.Substring(1); // Перевод первого символа слова в верхний регистр
            }
            catch (IndexOutOfRangeException ex)
            {
                InputOutput.TextWriteLine(ex.Message);
            }
            InputString = InputString.Replace(s, s0); // Замена слова в исходной строке
        }
        return InputString;
    }
}