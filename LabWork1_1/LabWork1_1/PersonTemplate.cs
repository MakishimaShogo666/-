using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    /// <summary>
    /// Класс PersonTemplate - библиотека шаблонов строк для вывода информации о персоне
    /// </summary>
    public class PersonTemplate
    {
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
