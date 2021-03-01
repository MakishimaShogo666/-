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
        public static readonly string DigitPattern = @"[0-9]";
        public static readonly string GenderPattern = @"[mfMFмжМЖ]";
        public static readonly string TextPattern = @"([a-zA-Z]|[а-яА-Я]|[ -])";
        public static readonly string TextException = @"(- |  | -|--)";
        public static readonly char[] Delimiters = new char[] { ' ', '-' };

        public static readonly string SurnameInputTemplate = "Введите фамилию персоны: ";
        public static readonly string NameInputTemplate = "Введите имя персоны: ";
        public static readonly string AgeInputTemplate = "Введите возраст персоны: ";
        public static readonly string GenderInputTemplate = "Введите пол персоны (м/М/m/M - мужской, ж/Ж/f/F - женский): ";

        public static readonly string SurnameOutputTemplate = "Фамилия: ";
        public static readonly string NameOutputTemplate = "Имя: ";
        public static readonly string AgeOutputTemplate = "Возраст: ";
        public static readonly string GenderOutputTemplate = "Пол: ";
    }
}
