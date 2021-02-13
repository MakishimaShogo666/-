using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace LabWork1_1
{
    class Randomizer
    {
        /// <summary>
        /// Функция GetRandomPerson для ввода случайной персоны
        /// </summary>
        /// <returns>
        /// Возвращается случайная персона
        /// </returns>
        public static Person GetRandomPerson()
        {
            Timer();

            Random RandomNumber = new Random();
            int age = RandomNumber.Next(PersonLibrary.MaxAge);
            GenderList gender = (GenderList)RandomNumber.Next(0, 2);
            string surname = null;
            string name = null;

            switch (gender) // выбор стандартных фамилии и имени на основе пола
            {
                case GenderList.Male:
                    surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    break;
                case GenderList.Female:
                    surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    break;
            }

            Person person = new Person(surname,name,age,gender);
            return person;
        }

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
        /// Метод Timer для отсчёта времени для корректной работы GetRandomPerson
        /// </summary>
        public static void Timer()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(5);
            stopwatch.Stop();
        }
    }
}
