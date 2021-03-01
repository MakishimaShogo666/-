using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork1_1;

namespace MainProject
{
    internal class Program
    {
        internal static void Main()
        {
            bool exit = true;
            while (exit)
            {
                InputOutput.TextWriteLine("Первые списки для экономии " +
                "времени заполняются случайным образом!", ConsoleColor.DarkCyan);
                InputOutput.TextWriteLine(null, 0);

                PersonList[] people;
                int personListQuantity;

                try
                {
                    personListQuantity = int.Parse(InputOutput.Input
                    ("Введите число списков персон: ", InputType.Digit));
                    people = new PersonList[personListQuantity];
                }
                catch (Exception)
                {
                    InputOutput.TextWriteLine($"Создано {PersonList.maxListQuantity} " +
                    $"списков персон.", ConsoleColor.DarkYellow);
                    personListQuantity = PersonList.maxListQuantity;
                    people = new PersonList[personListQuantity];
                }

                // Заполнение списков персон случайными персонами
                // 
                for (int j = 0; j < personListQuantity; j++)
                {
                    int personQuantity;
                    try
                    {
                        personQuantity = int.Parse(InputOutput.Input($"Введите число персон " +
                        $"в {j + 1}-м списке: ", InputType.Digit));
                        people[j] = new PersonList(personQuantity);
                    }
                    catch (Exception)
                    {
                        InputOutput.TextWriteLine($"Создан {j + 1}-й список персон " +
                        $"на {Person.maxPersonQuantity} человек.", ConsoleColor.DarkYellow);
                        personQuantity = Person.maxPersonQuantity;
                        people[j] = new PersonList(personQuantity);
                    }

                    people[j] = Randomizer.GetRandomList(personQuantity);

                    InputOutput.ListWrite(personQuantity, people[j]);
                }

                // Добавление персоны в заданный список вручную
                //
                int listIndex = CheckCount(personListQuantity,
                    $"Введённый номер списка больше числа списков персон! ({personListQuantity})",
                    "Введите номер списка для добавления персоны: ");

                string surname = (string)InputOutput.CheckInput
                (Pattern.SurnameInputTemplate, InputType.Text);
                string name = (string)InputOutput.CheckInput
                (Pattern.NameInputTemplate, InputType.Text);
                int age = (int)InputOutput.CheckInput
                (Pattern.AgeInputTemplate, InputType.Digit);
                GenderList gender = Person.GenderSetter((string)
                InputOutput.CheckInput(Pattern.GenderInputTemplate, InputType.Gender));

                people[listIndex - 1].Add(new Person(surname, name, age, gender));

                InputOutput.PersonWrite($"Ввод данных о добавленной персоне:",
                    people[listIndex - 1].data[people[listIndex - 1].PersonCount() - 1]);

                // Копирование заданной персоны в заданный список
                //
                int copyIndexListFrom = CheckCount(personListQuantity,
                $"Введённый номер списка больше числа списков персон! ({personListQuantity}))",
                $"Введите номер списка для копирования из него персоны: ");

                int copyIndexFrom = CheckCount(people[copyIndexListFrom - 1].PersonCount(),
                $"Введённый номер персоны для копирования из " +
                $"{copyIndexListFrom}-го списка больше числа персон в {copyIndexListFrom}-м списке! " +
                $"({people[copyIndexListFrom - 1].PersonCount()})",
                $"Введите номер персоны " +
                $"для копирования из {copyIndexListFrom}-го списка: ");

                // Ввод номера персоны до тех пор, пока не будет получено корректное значение 
                //
                int copyIndexListTo = CheckCount(personListQuantity,
                $"Введённый номер списка больше числа списков персон! ({personListQuantity})",
                $"Введите номер списка персон " +
                $"для копирования в него персоны из {copyIndexListFrom}-го списка: ");

                people[copyIndexListTo - 1].Add(people[copyIndexListFrom - 1].data[copyIndexFrom - 1]);

                InputOutput.ListPrint("Результат копирования", personListQuantity, people);

                int listRemoveIndex = CheckCount(personListQuantity,
                $"Введённый номер списка больше числа списков персон! ({personListQuantity})",
                "Введите номер списка для удаления персоны: ");

                int removeIndex = CheckCount(people[listRemoveIndex - 1].PersonCount(),
                $"Введённый номер персоны для удаления из " +
                $"{listRemoveIndex}-го списка больше числа персон в {listRemoveIndex}-м списке! " +
                $"({people[listRemoveIndex - 1].PersonCount()})",
                $"Введите номер персоны для удаления из {listRemoveIndex}-го списка: ");

                people[listRemoveIndex - 1].RemoveByIndex(removeIndex - 1);

                InputOutput.ListPrint("Просмотр списков персон", personListQuantity, people);

                int clearlistIndex = CheckCount(personListQuantity,
                $"Введённый номер списка больше числа списков персон! ({personListQuantity})",
                "Введите номер списка персон для удаления: ");

                people[clearlistIndex - 1].ClearList();

                InputOutput.ListPrint("Просмотр списков персон", personListQuantity, people);

                InputOutput.TextWriteLine(null, 0);
                exit = InputOutput.QuitOfProgram();
            }
        }
        /// <summary>
        /// Функция проверки величины введённого числа
        /// </summary>
        /// <param name="comparedVar">Число, с которым сравнивается вводимое число</param>
        /// <param name="awareMessage">Сообщение в случае превышения вводимым числом comparedVar</param>
        /// <param name="inputMessage">Сообщение для ввода</param>
        /// <returns>
        /// Введённое число, удовлетворяющее условию 
        /// </returns>
        private static int CheckCount(int comparedVar, string awareMessage, string inputMessage)
        {
            int primeVar = int.Parse(InputOutput.Input(inputMessage, InputType.Digit));
            while (primeVar > comparedVar)
            {
                InputOutput.TextWriteLine(awareMessage, ConsoleColor.Red);
                primeVar = int.Parse(InputOutput.Input(inputMessage, InputType.Digit));
            }
            return primeVar;
        }
    }
}
