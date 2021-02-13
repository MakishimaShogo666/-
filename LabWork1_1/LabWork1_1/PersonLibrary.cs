using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    /// <summary>
    /// Класс PersonLibrary - библиотека стандартных имён и фамилий
    /// </summary>
    class PersonLibrary
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
}
