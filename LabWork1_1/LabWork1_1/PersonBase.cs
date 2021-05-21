using System;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;
using LabWork1_1;

#region Перечисление

/// <summary>
/// Перечисление полов, NotDefined - неопределённый пол
/// </summary>
public enum GenderEnum
{
    Male, 
    Female, 
    NotDefined
}

#endregion

/// <summary>
/// Базовый абстрактный класс PersonBase
/// </summary>
public abstract class PersonBase
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
    private GenderEnum _gender;

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
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Фамилия не может быть пустой!");
            }
            else
            {
                _surname = RegisterChanger(value, Pattern.Delimiters);
            }
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
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым!");
            }
            else
            {
                _name = RegisterChanger(value, Pattern.Delimiters);
            }
        }
    }

    /// <summary>
    /// Возраст
    /// </summary>
    public virtual int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value > PersonLibrary.MaxAge)
            {
                throw new OverflowException($"Введённый возраст больше максимального" +
                $" ({PersonLibrary.MaxAge})!");
            }
            else if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Возраст не может быть меньше 0!");
            }
            else
            {
                _age = value;
            }
        }
    }

    /// <summary>
    /// Пол
    /// </summary>
    public GenderEnum Gender
    {
        get
        {
            return _gender;
        }
        set
        {
            _gender = value;
        }
    }

    /// <summary>
    /// Максимальное число персон в списке
    /// </summary>
    public const int maxPersonQuantity = 200000000;

    #endregion

    #endregion

    #region Конструктор
    /// <summary>
    /// Конструктор класса Person по умолчанию
    /// </summary>
    public PersonBase() : this("Нет данных", "Нет данных", 0, GenderEnum.NotDefined) { }

    /// <summary>
    /// Конструктор класса Person для создания персоны вручную
    /// </summary>
    public PersonBase(string surnameInput, string nameInput, int ageInput, GenderEnum genderInput)
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
    public static bool PatternCoincidence(string inputString, object keyInfo,
        string pattern, byte stringMaxLength)
    {
        return (Regex.IsMatch(keyInfo.ToString(), pattern) == true)
            && (inputString.Length < stringMaxLength);
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
    /// Функция RegisterChanger для изменения регистра введённых фамилии или имени персоны
    /// </summary>
    /// <param name="inputString">Строка ввода</param>
    /// <param name="delimiters">Массив разделителей</param>
    /// <returns>
    /// Строка с изменённым регистром фамилии или имени персоны
    /// </returns>
    public static string RegisterChanger(string inputString, char[] delimiters)
    {
        if (Regex.IsMatch(inputString, Pattern.DigitPattern)
            || (Regex.IsMatch(inputString, Pattern.TextPattern) == false))
        {
            throw new FormatException($"Строка '{inputString}' содержит недопустимые символы!");
        }
        else
        {
            // Разбиение введённой строки на слова
            //
            string[] splittedInputString = inputString.Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);

            // Для каждого слова в строке осуществляется изменение регистра
            //
            foreach (string splitString in splittedInputString)
            {
                string lowerSplitString = splitString.ToLower();

                if (lowerSplitString.Length < 2)
                {
                    lowerSplitString = char.ToUpper(lowerSplitString[0]).ToString();
                }
                else
                {
                    lowerSplitString = char.ToUpper(lowerSplitString[0]) + lowerSplitString.Substring(1);
                }
                // Замена слова в исходной строке
                //
                inputString = inputString.Replace(splitString, lowerSplitString);
            }
            return inputString;
        }
    }
    /// <summary>
    /// Функция для получения числового значения возраста из введённой строки
    /// </summary>
    /// <param name="inputAge">Строка ввода возраста</param>
    /// <returns>
    /// Числовое значение возраста, прошедшее проверки
    /// </returns>
    public static int AgeCheck(string inputAge)
    {
        if (Regex.IsMatch(inputAge, Pattern.TextPattern) == true)
        {
            throw new FormatException("При вводе возраста введён недопустимый символ!");
        }
        if (int.TryParse(inputAge, out int outputAge) == false)
        {
            throw new OverflowException("Слишком большое число!");
        }
        else if (outputAge > PersonLibrary.MaxAge)
        {
            throw new OverflowException($"Введённый возраст больше максимального" +
            $" ({PersonLibrary.MaxAge})!");
        }
        return outputAge;
    }

    /// <summary>
    /// Абстрактный метод для получения информации о персоне
    /// </summary>
    /// <returns>Строка с информацией о персоне</returns>
    public abstract string GetPersonInfo();

    /// <summary>
    /// Функция выбора строки, описывающей пол персоны в какой-либо ситуации
    /// </summary>
    /// <param name="gender">Пол персоны</param>
    /// <param name="maleString">Строка, характеризующая персону как мужчину</param>
    /// <param name="femaleString">Строка, характеризующая персону как женщину</param>
    /// <returns>Строка, описывающая пол персоны в какой-либо ситуации</returns>
    public static string GenderChoice(GenderEnum gender, string maleString, string femaleString)
    {
        string genderString = null;
        switch (gender)
        {
            case GenderEnum.Male:
                genderString = maleString;
                break;
            case GenderEnum.Female:
                genderString = femaleString;
                break;
        }
        return genderString;
    }
    #endregion
}