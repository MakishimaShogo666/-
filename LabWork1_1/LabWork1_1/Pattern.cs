using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    /// <summary>
    /// Библиотека шаблонов строк для ввода и вывода
    /// </summary>
    public static class Pattern
    {
        public const string DigitPattern = @"[0-9]";
        public const string GenderPattern = @"[mfMFмжМЖ]";
        public const string TextPattern = @"([a-zA-Z]|[а-яА-Я]|[ -])";
        public const string TextException = @"(^ |^-|- |  | -|--)";
        public static readonly char[] Delimiters = new char[] { ' ', '-' };

        public const string SurnameInputMessage = "Введите фамилию персоны: ";
        public const string NameInputMessage = "Введите имя персоны: ";
        public const string AgeInputMessage = "Введите возраст персоны: ";
        public const string GenderInputMessage = "Введите пол персоны (м/М/m/M - мужской, ж/Ж/f/F - женский): ";

        public const string SurnameOutputMessage = "Фамилия: ";
        public const string NameOutputMessage = "Имя: ";
        public const string AgeOutputMessage = "Возраст: ";
        public const string GenderOutputMessage = "Пол: ";
    }
}
