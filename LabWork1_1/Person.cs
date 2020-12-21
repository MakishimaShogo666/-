using System;
//enum Person_Gender : bool
//{
//    male = true,
//    female = false,
//};
enum SurnameRandom {Иванов, Иванова}
enum NameRandom {Иван, Мария}
enum GenderList {мужской, женский, nd}
//enum PersonAttribute { Surname, Name, Age, Gender}

public class Person
    {
        public string Surname;
        public string Name;
        public int Age;
        public GenderList Gender;
        public Random RandomNumber = new Random();
        public Person()
        {
            Surname = "Нет данных";
            Name = "Нет данных";
            Age = 0;
            Gender = GenderList.nd;
        }
        public Person(string SurnameInput, string NameInput, int AgeInput, GenderList GenderInput)
        {
            Surname = SurnameInput;
            Name = NameInput;
            Age = AgeInput;
            Gender = GenderInput;
        }
        public Person(int average_age, GenderList GenderInput)
        {
            Age = RandomNumber.Next(average_age * 2);
            Gender = GenderInput;
            switch (Gender)
            {
                case GenderList.мужской:
                    Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                    break;
                case GenderList.женский:
                    Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                    break;
            }
        }
        public Person(int AgeInput)
        {
            Age = AgeInput;
            Gender = (GenderList)RandomNumber.Next(0,2);
            switch (Gender)
            {
                case GenderList.мужской:
                    Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleNameCount)];
                    break;
                case GenderList.женский:
                    Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleNameCount)];
                    break;
            }
        }
        public void PersonWrite(string Surname, string Name, int Age, GenderList Gender)
        {
            Console.WriteLine(PersonTemplate.SurnameOutputTemplate + Surname);
            Console.WriteLine(PersonTemplate.NameOutputTemplate + Name);
            Console.WriteLine(PersonTemplate.AgeOutputTemplate + Age);
            Console.WriteLine(PersonTemplate.GenderOutputTemplate + Gender);
            Console.ReadKey();
        }
        public static Person PersonRead()
        {
            Person Person = new Person();
            Console.WriteLine(PersonTemplate.SurnameInputTemplate);
            Person.Surname = Console.ReadLine();
            Console.WriteLine(PersonTemplate.NameInputTemplate);
            Person.Name = Console.ReadLine();
            Console.WriteLine(PersonTemplate.AgeInputTemplate);
            string AgeString = Console.ReadLine();
            int.TryParse(AgeString,out Person.Age);
            Console.WriteLine(PersonTemplate.GenderInputTemplate);
            string GenderString="";
            int GenderNumber = (int)GenderList.nd+1;
            //bool GenderParse = false;
            while ((GenderString!="м")&(GenderString != "ж"))
            {
                GenderString=Console.ReadLine();
            }
            switch (GenderString)
            {
                case "м":
                    GenderNumber = 0;
                    break;
                case "ж":
                    GenderNumber = 1;
                    break;
            }
            Person.Gender = (GenderList)GenderNumber;
            return Person;
        }
        public static Person GetRandomPerson()
        {
            Person Person = new Person();
            Random RandomNumber = new Random();
            Person.Age = RandomNumber.Next(118);
            Person.Gender = (GenderList)RandomNumber.Next(0, 2);
            switch (Person.Gender)
            {
                case GenderList.мужской:
                    Person.Surname = PersonLibrary.StandardMaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    Person.Name = PersonLibrary.StandardMaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardMaleSurnameCount)];
                    break;
                case GenderList.женский:
                    Person.Surname = PersonLibrary.StandardFemaleSurnameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    Person.Name = PersonLibrary.StandardFemaleNameLibrary[RandomNumber.Next(PersonLibrary.StandardFemaleSurnameCount)];
                    break;
            }
            return Person;
        }
    }
