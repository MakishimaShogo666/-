using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using LabWork1_1;

#region Перечисление
/// <summary>
/// Перечисление полов, NotDefined - неопределённый пол
/// </summary>
public enum GenderList
{
    Male, 
    Female, 
    NotDefined
}
#endregion

/// <summary>
/// Класс Person
/// </summary>
public class Person
{
    #region Поля

    #region Непубличные поля
    /// <summary>
    /// Фамилия
    /// </summary>
    private string _surname;
    /// <summary>
    /// Имя
    /// </summary>
    private string _name;
    /// <summary>
    /// Пол
    /// </summary>
    private GenderList _gender;
    /// <summary>
    /// Возраст
    /// </summary>
    private int _age;
    #endregion

    #region Публичные поля
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname
    {
        get
        {
            return _surname;
        }
        private set
        {
            _surname = RegisterChanger(value, Pattern.Delimiters);
        }
    }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {
            _name = RegisterChanger(value, Pattern.Delimiters);
        }
    }
    /// <summary>
    /// Пол
    /// </summary>
    public GenderList Gender
    {
        get
        {
            return _gender;
        }
        private set
        {
            _gender = value;
        }
    }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age 
    {
        get
        {
            return _age;
        }
        private set
        {
            if (value > PersonLibrary.MaxAge)
            {
                throw new OverflowException($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
            }
            else 
            {
                _age = value;
            }
        }
    }

    /// <summary>
    /// Максимальное число персон в списке
    /// </summary>
    public static readonly int maxPersonQuantity = 200000000;
    #endregion

    #endregion

    #region Конструктор
    /// <summary>
    /// Конструктор класса Person по умолчанию
    /// </summary>
    public Person() : this("Нет данных", "Нет данных", 0, GenderList.NotDefined) { }

    /// <summary>
    /// Конструктор класса Person для создания персоны вручную
    /// </summary>
    public Person(string surnameInput, string nameInput, int ageInput, GenderList genderInput)
    {
        Surname = surnameInput;
        Name = nameInput;
        Age = ageInput;
        Gender = genderInput;
    }
    #endregion

    #region Методы

    /// <summary>
    /// Функция для обнаружения совпадения символа с шаблоном
    /// </summary>
    /// <param name="inputString">Строка ввода</param>
    /// <param name="keyInfo">Клавиша</param>
    /// <param name="pattern">Шаблон ввода</param>
    /// <param name="stringMaxLength">Максимальная длина строки</param>
    /// <returns>
    /// true, если клавиша совпадает с шаблоном и число символов в строке меньше stringMaxLength
    /// </returns>
    public static bool PatternCoincidence(string inputString, object keyInfo, string pattern, byte stringMaxLength)
    {
        return (Regex.IsMatch(keyInfo.ToString(), pattern) == true) && (inputString.Length < stringMaxLength);
    }
    /// <summary>
    /// Функция для обнаружения совпадения строки с шаблоном исключения
    /// </summary>
    /// <param name="inputString">Строка ввода</param>
    /// <returns>
    /// true, если строка ввода содержит символы из шаблона исключения
    /// </returns>
    public static bool ExceptionCoincidence(string inputString)
    {
        return Regex.IsMatch(inputString, Pattern.TextException);
    }
    /// <summary>
    /// Функция для задания пола в соответствии с введённым символом
    /// </summary>
    /// <param name="genderString">Строка ввода пола</param>
    /// <returns>
    /// Пол
    /// </returns>
    public static GenderList GenderSetter(string genderString)
    {
        // выбор пола на основе введённого в консоль символа
        switch (genderString)
        {
            case "м":
            case "М":
            case "M":
            case "m":
                return GenderList.Male;
            case "ж":
            case "Ж":
            case "F":
            case "f":
                return GenderList.Female;
        }
        return GenderList.NotDefined;
    }
    /// <summary>
    /// Функция RegisterChanger для изменения регистра введённых фамилии или имени персоны
    /// </summary>
    /// <param name="inputString">Строка ввода</param>
    /// <param name="delimiters">Массив разделителей</param>
    /// <returns>
    /// Строка с изменённым регистром фамилии или имени персоны
    /// </returns>
    public static string RegisterChanger(string inputString, char[] delimiters)
    {
        if (Regex.IsMatch(inputString, Pattern.DigitPattern) || (Regex.IsMatch(inputString, Pattern.TextPattern) == false))
        {
            throw new FormatException($"Строка '{inputString}' содержит недопустимые символы!");
        }
        else
        {
            // Разбиение введённой строки на слова
            //
            string[] SplittedInputString = inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Для каждого слова в строке осуществляется изменение регистра
            //
            foreach (string s in SplittedInputString)
            {
                string s0 = s.ToLower();

                if (s0.Length < 2)
                {
                    s0 = char.ToUpper(s0[0]).ToString();
                }
                else
                {
                    s0 = char.ToUpper(s0[0]) + s0.Substring(1);
                }
                // Замена слова в исходной строке
                //
                inputString = inputString.Replace(s, s0);
            }
            return inputString;
        }
    }
    /// <summary>
    /// Функция для получения числового значения возраста из введённой строки
    /// </summary>
    /// <param name="inAge">Строка ввода возраста</param>
    /// <returns>
    /// Числовое значение возраста
    /// </returns>
    public static int AgeCompare(string inAge)
    {
        if (Regex.IsMatch(inAge, Pattern.TextPattern) == true)
        {
            throw new FormatException("При вводе возраста введён недопустимый символ!");
        }
        if (int.TryParse(inAge, out int outAge) == false)
        {
            throw new OverflowException($"Слишком большое число!");
        }
        else if (outAge > PersonLibrary.MaxAge)
        {
            throw new OverflowException($"Введённый возраст больше максимального ({PersonLibrary.MaxAge})!");
        }
        return outAge;
    }
    #endregion
}