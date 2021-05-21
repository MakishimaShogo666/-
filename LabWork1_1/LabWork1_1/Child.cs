using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_1
{
    /// <summary>
    /// Класс Child
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Мать
        /// </summary>
        private PersonBase _mother;

        /// <summary>
        /// Отец
        /// </summary>
        private PersonBase _father;

        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        private string _educationCenter;

        /// <summary>
        /// Мать
        /// </summary>
        public PersonBase Mother
        {
            get
            {
                return _mother;
            }
            set
            {
                _mother = value;
            }
        }

        /// <summary>
        /// Отец
        /// </summary>
        public PersonBase Father
        {
            get
            {
                return _father;
            }
            set
            {
                _father = value;
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
                if (value >= PersonLibrary.PassportAge)
                {
                    throw new OverflowException($"Введённый возраст соответствует взрослому" +
                    $" (>{PersonLibrary.PassportAge})!");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        public string EducationCenter
        {
            get
            {
                return _educationCenter;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == null)
                {
                    _educationCenter = "Домашнее обучение";
                }
                else
                {
                    _educationCenter = value;
                }
            }
        }

        /// <summary>
        /// Конструктор класса Child по умолчанию
        /// </summary>
        public Child() : this("Нет данных", "Нет данных", 0, GenderEnum.NotDefined, null, null, null) { }

        /// <summary>
        /// Конструктор класса Child
        /// </summary>
        public Child(string surname, string name, int age, GenderEnum gender, 
            PersonBase mother, PersonBase father, string educationalInstitution)
            : base(surname, name, age, gender)
        {
            Mother = mother;
            Father = father;
            EducationCenter = educationalInstitution;
        }
        
        /// <summary>
        /// Функция усыновления/удочерения ребёнка
        /// </summary>
        /// <returns>Статус усыновления</returns>
        public string AdoptionStatus()
        {
            string adoptionStatus = null;
            if (Mother != null && Father != null)
            {
                adoptionStatus = $"У ребёнка {Surname} {Name} уже есть родители!";
            }
            if (Mother == null)
            {
                Mother = Randomizer.GetRandomParent(this,GenderEnum.Female);
                adoptionStatus = $"У ребёнка {Surname} {Name} появилась мама, " +
                    $"{Mother.Surname} {Mother.Name}!";
            }
            if (Father == null)
            {
                Father = Randomizer.GetRandomParent(this, GenderEnum.Male);
                adoptionStatus = adoptionStatus + '\n' + $"У ребёнка {Surname} {Name} появился папа, " +
                    $"{Father.Surname} {Father.Name}!";
            }
            return adoptionStatus;
        }
        /// <summary>
        /// Функция получения информации о ребёнке
        /// </summary>
        /// <returns>Строка с информацией о ребёнке</returns>
        public override string GetPersonInfo()
        {
            return Pattern.SurnameOutputMessage + Surname + '\n'
                + Pattern.NameOutputMessage + Name + '\n'
                + Pattern.AgeOutputMessage + Age + '\n'
                + Pattern.GenderOutputMessage
                + (Gender == GenderEnum.Male ? PersonLibrary.MaleGender : PersonLibrary.FemaleGender) +'\n'
                + Pattern.MotherOutputMessage 
                + (Mother == null 
                    ? "-" 
                    : Mother.Surname + ' ' + Mother.Name) 
                + '\n'
                + Pattern.FatherOutputMessage + (Father == null 
                    ? "-" 
                    : Father.Surname + ' ' + Father.Name) 
                + '\n'
                + Pattern.EducationCenterOutputMessage + EducationCenter;
        }
    }
}
