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
    public static class PersonLibrary
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

        public static readonly string[] StandardEducationCenterNameLibrary = new string[]
        {
            "Школа №1",
            "Школа №2",
            "Школа №8",
            "Лицей №15",
            "Школа №16",
            "Лицей №17",
            "Детский сад \"Рябинка\"",
            "Центр дошкольного развития \"Тормозок\"",
            "Центр развития детей \"Дети солнца\"",
            "Детский сад \"Берёзка\"",
            "Центр дошкольного развития \"Dawn\"",
            "Детский сад №1"
        };

        public static readonly string[] StandardJobNameLibrary = new string[]
        {
            "ООО \"Берёзовские электрические сети\"",
            "АО \"Системный оператор Единой энергетической системы\"",
            "Кемеровское РДУ",
            "ОДУ Сибири",
            "Горводоканал",
            "ОГАУЗ \"Межвузовская поликлиника\""
        };

        public static readonly int StandardMaleNameCount = StandardMaleNameLibrary.Length;
        public static readonly int StandardMaleSurnameCount = StandardMaleSurnameLibrary.Length;
        public static readonly int StandardFemaleNameCount = StandardFemaleNameLibrary.Length;
        public static readonly int StandardFemaleSurnameCount = StandardFemaleSurnameLibrary.Length;
        public static readonly int StandardEducationCenterNameCount = StandardEducationCenterNameLibrary.Length;
        public static readonly int StandardJobNameCount = StandardJobNameLibrary.Length;

        public const int MaxAge = 118; 
        public const int PassportAge = 14; 
        public const int PassportLength = 10;

        public const string MaleGender = "мужской";
        public const string FemaleGender = "женский";
        public const string MaleMarriageStatus = "женат";
        public const string FemaleMarriageStatus = "замужем";
        public const string Negation = "не";
    }
}
