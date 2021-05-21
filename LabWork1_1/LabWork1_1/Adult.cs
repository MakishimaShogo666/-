using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    //TODO: XML+
    /// <summary>
    /// Класс Adult
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Паспортные данные (серия/номер)
        /// </summary>
        private string _passport;

        /// <summary>
        /// Супруг
        /// </summary>
        private Adult _spouse;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _job;

        /// <summary>
        /// Паспортные данные (серия/номер)
        /// </summary>
        public string Passport
        {
            get
            {
                return _passport;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Данные паспорта не могут быть пустыми!");
                }
                else
                {
                    _passport = string.Format("{0} {1}", value.Substring(0, 4), value.Substring(4, 6)) ;
                }
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public string Job
        {
            get
            {
                return _job;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == null)
                {
                    _job = "Безработный";
                }
                else
                {
                    _job = value;
                }
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public Adult Spouse
        {
            get
            {
                return _spouse;
            }
            set
            {
                _spouse = value;
            }
        }
        /// <summary>
        /// Возраст
        /// </summary>
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value < PersonLibrary.PassportAge)
                {
                    throw new OverflowException($"Введённый возраст соответствует детскому возрасту" +
                    $" (<{PersonLibrary.PassportAge})!");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Конструктор класса Adult по умолчанию
        /// </summary>
        public Adult() : this("Нет данных", "Нет данных", PersonLibrary.PassportAge, GenderEnum.NotDefined,"0000000000",null,null) { }

        /// <summary>
        /// Конструктор класса Adult
        /// </summary>
        public Adult(string surname, string name, int age, GenderEnum gender, string passport, Adult spouse, string job)
            :base(surname,name,age,gender)
        {
            Spouse = spouse;
            Passport = passport;
            Job = job;
        }
        /// <summary>
        /// Функция заключения брака персоны adult со случайной персоной
        /// </summary>
        /// <returns>Семейное положение</returns>
        public string AdultMarriage()
        {
            string mariageStatus;

            if (Spouse == null)
            {
                Randomizer.GetRandomSpouse(this);
                mariageStatus = $"Поздравляем со свадьбой, {Surname} {Name} " +
                    $"и {Spouse.Surname} {Spouse.Name}!";
            }
            else
            {
                mariageStatus = $"{Surname} {Name} уже " +
                    $"{(Gender == GenderEnum.Male ? PersonLibrary.MaleMarriageStatus : PersonLibrary.FemaleMarriageStatus)}!";
            }
            return mariageStatus;
        }

        /// <summary>
        /// Функция получения информации о взрослом
        /// </summary>
        /// <returns>Строка с информацией о взрослом</returns>
        public override string GetPersonInfo()
        {
            string marriageStatus = (Gender == GenderEnum.Male 
                ? PersonLibrary.Negation + ' ' + PersonLibrary.MaleMarriageStatus
                : PersonLibrary.Negation + ' ' + PersonLibrary.FemaleMarriageStatus);

            return Pattern.SurnameOutputMessage + Surname + '\n'
                + Pattern.NameOutputMessage + Name + '\n'
                + Pattern.AgeOutputMessage + Age + '\n'
                + Pattern.GenderOutputMessage + (Gender == GenderEnum.Male 
                    ? PersonLibrary.MaleGender 
                    : PersonLibrary.FemaleGender) 
                + '\n'
                + Pattern.PassportOutputMessage + Passport + '\n'
                + Pattern.SpouseOutputMessage + (Spouse is null 
                    ? marriageStatus 
                    : Spouse.Surname + ' ' + Spouse.Name) 
                + '\n'
                + Pattern.JobOutputMessage + Job;
        }
    }
}
