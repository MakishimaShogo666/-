using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    /// <summary>
    /// Библиотека стандартных имён и фамилий, а также стандартных свойств персон
    /// </summary>
    public class PersonLibrary
    {
        public static readonly string[] StandardMaleSurnameLibrary = new string[] 
        { 
            "Иванов",
            "Петров",
            "Сидоров",
            "Сергеев"
        };
        public static readonly string[] StandardFemaleSurnameLibrary = new string[]
        {
            "Иванова", 
            "Петрова", 
            "Сидорова", 
            "Сергеева" 
        };
        public static readonly string[] StandardMaleNameLibrary = new string[] 
        {
            "Иван", 
            "Андрей", 
            "Александр", 
            "Константин", 
            "Сергей", 
            "Дмитрий"
        };
        public static readonly string[] StandardFemaleNameLibrary = new string[]
        {
            "Татьяна",
            "Светлана",
            "Наталья",
            "Александра",
            "Элла",
            "Дарья"
        };

        public static readonly int StandardMaleNameCount = StandardMaleNameLibrary.Length;
        public static readonly int StandardMaleSurnameCount = StandardMaleSurnameLibrary.Length;
        public static readonly int StandardFemaleNameCount = StandardFemaleNameLibrary.Length;
        public static readonly int StandardFemaleSurnameCount = StandardFemaleSurnameLibrary.Length;

        public static readonly int MaxAge = 118; // Максимально возможный возраст персоны
    }
}
