using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace LabWork1_1
{
    public class Randomizer
    {
        /// <summary>
        /// Приватный экземпляр класса Random для генерации случайной персоны
        /// </summary>
        private static readonly Random _randomNumber = new Random();

        #region Методы
        /// <summary>
        /// Функция для генерации случайных паспортных данных
        /// </summary>
        /// <returns>
        /// Строка с папортными данными
        /// </returns>
        public static string GeneratePassport()
        {
            int maxLength = PersonLibrary.PassportLength;
            string passportDigit = _randomNumber.Next(1, maxLength).ToString();

            for (int i = 1; i < maxLength; i++)
            {
                passportDigit += _randomNumber.Next(0, maxLength).ToString();
            }
            return passportDigit;
        }

        /// <summary>
        /// Функция генерации случайного ребёнка
        /// </summary>
        /// <returns>Случайный ребёнок</returns>
        public static Child GetRandomChild()
        {
            Child child = new Child();
            GetRandomPerson(child, 1, PersonLibrary.PassportAge);

            int index = _randomNumber.Next(PersonLibrary.StandardEducationCenterNameCount);
            child.EducationCenter = PersonLibrary.StandardEducationCenterNameLibrary[index];
            child.Mother = new Adult();
            child.Father = new Adult();
            return child;
        }
        /// <summary>
        /// Функция генерации случайного взрослого
        /// </summary>
        /// <returns>Случайный взрослый</returns>
        public static Adult GetRandomAdult()
        {
            Adult adult = new Adult();
            GetRandomPerson(adult, PersonLibrary.PassportAge, PersonLibrary.MaxAge);

            adult.Passport = GeneratePassport();

            int index = _randomNumber.Next(PersonLibrary.StandardJobNameCount);
            adult.Job = PersonLibrary.StandardJobNameLibrary[index];
            adult.Spouse = null;
            return adult;
        }
        /// <summary>
        /// Функция генерации случайного супруга для adult
        /// </summary>
        /// <param name="adult">Взрослый, которому нужен(на) супруг(а)</param>
        /// <returns>Взрослого со сгенерированной супругой</returns>
        public static void GetRandomSpouse(Adult adult)
        {
            adult.Spouse = new Adult();
            while ((adult.Spouse.Gender == GenderEnum.NotDefined)
                || (adult.Spouse.Gender == adult.Gender))
            {
                adult.Spouse = GetRandomAdult();
                adult.Spouse.Spouse = adult;
            }
        }
        /// <summary>
        /// Процедура женитьбы двух взрослых men и women
        /// </summary>
        /// <param name="men">Мужчина</param>
        /// <param name="women">Женщина</param>
        public static void GetSpouse(Adult men, Adult women)
        {
            men.Spouse = women;
            women.Spouse = men;
        }
        /// <summary>
        /// Функция генерации случайного родителя
        /// </summary>
        /// <param name="child">Ребёнок, которому нужен родитель</param>
        /// <param name="gender">Пол ребёнка</param>
        /// <returns></returns>
        public static Adult GetRandomParent(Child child, GenderEnum gender)
        {
            Adult adult = new Adult();
            while ((adult.Gender != gender) || (adult.Age - child.Age < 16))
            {
                adult = GetRandomAdult();
            }
            return adult;
        }
        /// <summary>
        /// Функция генерации случайных параметров для персоны person
        /// </summary>
        /// <param name="person">Персона</param>
        /// <param name="minAge">минимальный возраст</param>
        /// <param name="maxAge">максимальный возраст</param>
        /// <returns>Персона со сгенерированными параметрами</returns>
        public static PersonBase GetRandomPerson(PersonBase person,int minAge,int maxAge)
        {
            person.Age = _randomNumber.Next(minAge, maxAge);
            person.Gender = (GenderEnum)_randomNumber.Next(0, 2);

            switch (person.Gender)
            {
                case GenderEnum.Male:
                    person.Surname = PersonLibrary.StandardMaleSurnameLibrary
                        [_randomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    person.Name = PersonLibrary.StandardMaleNameLibrary
                        [_randomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    break;
                case GenderEnum.Female:
                    person.Surname = PersonLibrary.StandardFemaleSurnameLibrary
                        [_randomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    person.Name = PersonLibrary.StandardFemaleNameLibrary
                        [_randomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    break;
            }
            return person;
        }

        /// <summary>
        /// Функция GetRandomList для вывода списка со случайными персонами
        /// </summary>
        /// <param name="personCount">Число персон в списке</param>
        /// <returns>
        /// Возвращается случайная персона
        /// </returns>
        public static PersonList GetRandomList(int personCount)
        {
            PersonList personList = new PersonList(personCount);
            for (int i = 0; i < personCount; i++)
            {
                var childOrAdult = _randomNumber.Next(0, 2);
                switch (childOrAdult)
                {
                    case 0:
                        ChildInRandomList(ref personList, ref i, personCount);
                        break;
                    case 1:
                        AdultInRandomList(ref personList, ref i, personCount);
                        break;
                }
            }
            return personList;
        }

        /// <summary>
        /// Процедура создания ребёнка в списке персон personList
        /// </summary>
        /// <param name="personList">Список персон</param>
        /// <param name="index">Текущий индекс</param>
        /// <param name="personCount">Число персон в списке</param>
        private static void ChildInRandomList(ref PersonList personList, ref int index, int personCount)
        {
            Child child = GetRandomChild();
            child.Mother = GetRandomParent(child, GenderEnum.Female);
            child.Father = GetRandomParent(child, GenderEnum.Male);

            personList.Data[index] = child;
            index++;

            if (personCount - index > 1)
            {
                personList.Data[index] = child.Mother;
                index++;
                personList.Data[index] = child.Father;

                GetSpouse((Adult)child.Father, (Adult)child.Mother);
            }
            else if (personCount - index == 1)
            {
                var motherOrFather = _randomNumber.Next(0, 2);
                switch (motherOrFather)
                {
                    case 0:
                        child.Father = null;
                        personList.Data[index] = child.Mother;
                        break;
                    case 1:
                        child.Mother = null;
                        personList.Data[index] = child.Father;
                        break;
                }
            }
            else
            {
                child.Father = null;
                child.Mother = null;
            }
        }
        /// <summary>
        /// Процедура создания взрослого в списке персон personList
        /// </summary>
        /// <param name="personList">Список персон</param>
        /// <param name="index">Текущий индекс персоны</param>
        /// <param name="personCount">Число персон в списке</param>
        private static void AdultInRandomList(ref PersonList personList, ref int index, int personCount)
        {
            Adult adult = GetRandomAdult();
            var loveOrNot = _randomNumber.Next(0, 2);
            if (personCount - index > 1)
            {
                switch (loveOrNot)
                {
                    case 0:
                        GetRandomSpouse(adult);
                        personList.Data[index] = adult;
                        index++;
                        personList.Data[index] = adult.Spouse;
                        break;
                    case 1:
                        adult.Spouse = null;
                        personList.Data[index] = adult;
                        break;
                }
            }
            else
            {
                adult.Spouse = null;
                personList.Data[index] = adult;
            }
        }     
        
        #endregion
    }
}
