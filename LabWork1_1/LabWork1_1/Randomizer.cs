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
        /// Функция для ввода случайной персоны
        /// </summary>
        /// <returns>
        /// Cлучайная персона
        /// </returns>
        public static Person GetRandomPerson()
        {
            int age = _randomNumber.Next(1, PersonLibrary.MaxAge);
            GenderList gender = (GenderList)_randomNumber.Next(0, 2);
            string surname = null;
            string name = null;

            switch (gender) // выбор стандартных фамилии и имени на основе пола
            {
                case GenderList.Male:
                    surname = PersonLibrary.StandardMaleSurnameLibrary[_randomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    name = PersonLibrary.StandardMaleNameLibrary[_randomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    break;
                case GenderList.Female:
                    surname = PersonLibrary.StandardFemaleSurnameLibrary[_randomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    name = PersonLibrary.StandardFemaleNameLibrary[_randomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    break;
            }

            Person person = new Person(surname, name, age, gender);
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
                personList.data[i] = GetRandomPerson();
            }
            return personList;
        }
        /// <summary>
        /// Процедура Timer для отсчёта времени для корректной работы GetRandomPerson
        /// </summary>
        public static void Timer()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(5);
            stopwatch.Stop();
        }
        #endregion
    }
}
