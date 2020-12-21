using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
//enum Person_Gender : bool
//{
//    male = true,
//    female = false,
//};
public enum GenderList { мужской, женский, nd }

public class Person
{
    public string Surname;
    public string Name;
    public int Age;
    public GenderList Gender;

    public Person()
    {
        Surname = "Нет данных";
        Name = "Нет данных";
        Age = 0;
        Gender = GenderList.nd;
    }

    public Person(string SurnameInput, string NameInput, int AgeInput, GenderList GenderInput)
    {
        Surname = SurnameInput;
        Name = NameInput;
        Age = AgeInput;
        Gender = GenderInput;
    }

    public Person(int average_age, GenderList GenderInput)
    {
        Random RandomNumber = new Random();
        Age = RandomNumber.Next(average_age * 2);
        Gender = GenderInput;

        switch (Gender)
        {
            case GenderList.мужской:
                Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                break;
            case GenderList.женский:
                Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                break;
        }
    }

    public Person(int AgeInput)
    {
        Random RandomNumber = new Random();
        Age = AgeInput;
        Gender = (GenderList)RandomNumber.Next(0, 2);

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

    public static void PersonWrite(Person person)
    {
        Console.WriteLine(PersonTemplate.SurnameOutputTemplate + person.Surname);
        Console.WriteLine(PersonTemplate.NameOutputTemplate + person.Name);
        Console.WriteLine(PersonTemplate.AgeOutputTemplate + person.Age);
        Console.WriteLine(PersonTemplate.GenderOutputTemplate + person.Gender);
    }

    public static int InputDigit(string condition) 
    {
        string InputString = "";
        string DigitPattern = @"[0-9]";
        Console.Write(condition);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            
            if(((Regex.IsMatch(keyInfo.KeyChar.ToString(), DigitPattern) == true)
                &(InputString.Length < 3)) | (keyInfo.Key == ConsoleKey.Backspace))
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

    public static string InputGender(string condition)
    {
        string InputString = "";
        string GenderPattern = @"[mfMFмжМЖ]";
        Console.Write(condition);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);         
            if(((Regex.IsMatch(keyInfo.KeyChar.ToString(),GenderPattern)==true) &(InputString.Length < 1))|(keyInfo.Key == ConsoleKey.Backspace))
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
    public static string InputName(string condition)
    {
        string InputString = "";
        string NamePattern = @"([a-zA-Z]|[а-яА-Я]|[ -])";
        string NameException = @"(- |  | -|--)";
        char[] Delimiters = new char[] { ' ', '-' };

        Console.Write(condition);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if ((Regex.IsMatch(keyInfo.KeyChar.ToString(), NamePattern) == true) | (keyInfo.Key == ConsoleKey.Backspace))
            {
                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    InputString = InputString + keyInfo.KeyChar;
                    if (Regex.IsMatch(InputString, NameException) == true)
                    {
                        InputString = InputString.Substring(0, InputString.Length - 1);
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    if ((InputString != "")&(InputString.Length!=0))
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
        InputString = RegisterChanger(InputString, Delimiters);
        return InputString;
    }

    public static Person PersonRead()
    {
        Person Person = new Person();      
        Person.Surname = InputName(PersonTemplate.SurnameInputTemplate);
        Person.Name = InputName(PersonTemplate.NameInputTemplate);
        Person.Age = 0;
        Person.Age = InputDigit(PersonTemplate.AgeInputTemplate);

        while (Person.Age> PersonLibrary.MaxAge)
        {
            Console.WriteLine($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            Person.Age = InputDigit(PersonTemplate.AgeInputTemplate);
        }

        string GenderString = InputGender(PersonTemplate.GenderInputTemplate);
        int GenderNumber = (int)GenderList.nd;

        switch (GenderString)
        {
            case "м":
                GenderNumber = 0;
                break;
            case "М":
                GenderNumber = 0;
                break;
            case "M":
                GenderNumber = 0;
                break;
            case "m":
                GenderNumber = 0;
                break;
            case "ж":
                GenderNumber = 1;
                break;
            case "Ж":
                GenderNumber = 1;
                break;
            case "F":
                GenderNumber = 1;
                break;
            case "f":
                GenderNumber = 1;
                break;
        }
        Person.Gender = (GenderList)GenderNumber;
        return Person;
    }

    public static string RegisterChanger(string InputString,char[] Delimiters)
    {
        string[] SplittedInputString = InputString.Split(Delimiters);
        foreach (string s in SplittedInputString)
        {
            string s0, s1 = s;
            s0 = s.ToLower();
            s0 = Char.ToUpper(s0[0]) + s0.Substring(1);
            InputString = InputString.Replace(s1, s0);
        }
        return InputString;
    }

    public static Person GetRandomPerson()
    {
        Person Person = new Person();
        Random RandomNumber = new Random();
        Person.Age = RandomNumber.Next(PersonLibrary.MaxAge);
        Person.Gender = (GenderList)RandomNumber.Next(0, 2);
        switch (Person.Gender)
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

    public static int MaxAge = 118;
}
public class PersonTemplate
{
    public static string SurnameInputTemplate = "Введите фамилию персоны: ";
    public static string NameInputTemplate = "Введите имя персоны: ";
    public static string AgeInputTemplate = "Введите возраст персоны: ";
    public static string GenderInputTemplate = "Введите пол персоны (м - мужской, ж - женский): ";

    public static string SurnameOutputTemplate = "Фамилия: ";
    public static string NameOutputTemplate = "Имя: ";
    public static string AgeOutputTemplate = "Возраст: ";
    public static string GenderOutputTemplate = "Пол: ";
}