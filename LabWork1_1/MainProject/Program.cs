﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork1_1;

namespace MainProject
{
    /// <summary>
    /// Основная программа
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        internal static void Main()
        {
            while (true)
            {
                InputOutput.TextWriteLine("Первые списки для экономии " +
                    "времени заполняются случайным образом!", ConsoleColor.DarkCyan);
                InputOutput.TextWriteLine(null, 0);

                PersonList[] people = new PersonList[GetQuantity("Введите число списков персон: ", 
                    $"Создано {PersonList.maxListQuantity} " + $"списков персон.")];
                int personListQuantity = people.Length;
                GetPersonList(people);

                int listIndex = GetListIndex(personListQuantity, "добавления персоны");
                PersonBase person = InputOutput.InputAdult();
                people[listIndex - 1].Add(person);
                InputOutput.PersonWrite($"Ввод данных о добавленной персоне:",
                    people[listIndex - 1].Data[people[listIndex - 1].PersonCount() - 1]);

                int copyIndexListFrom = GetListIndex(personListQuantity, "копирования персоны");
                int personCount = people[copyIndexListFrom - 1].PersonCount();
                int copyIndexFrom = GetPersonIndex(personCount, copyIndexListFrom, "копирования персоны");
                int copyIndexListTo = GetListIndex(personListQuantity, "копирования в него персоны");
                people[copyIndexListTo - 1].Add(people[copyIndexListFrom - 1].Data[copyIndexFrom - 1]);
                InputOutput.AllListWrite("Результат копирования", people);

                int listRemoveIndex = GetListIndex(personListQuantity, "удаления персоны");
                int quantityInListRemove = people[listRemoveIndex - 1].PersonCount();
                int removeIndex = GetPersonIndex(quantityInListRemove, listRemoveIndex, "удаления персоны");
                people[listRemoveIndex - 1].RemoveByIndex(removeIndex - 1);               
                InputOutput.AllListWrite("Просмотр списков персон", people);

                int clearlistIndex = GetListIndex(personListQuantity, "удаления");
                people[clearlistIndex - 1].Clear();
                InputOutput.AllListWrite("Просмотр списков персон", people);

                InputOutput.TextWriteLine(null, 0);

                if (InputOutput.QuitOfProgram()) return;
            }
        }
        /// <summary>
        /// Получение индекса списка персон
        /// </summary>
        /// <param name="personListQuantity">Число списков персон</param>
        /// <param name="operation">Операция со списком</param>
        /// <returns></returns>
        private static int GetListIndex(int personListQuantity, string operation)
        {
            return CheckCount(personListQuantity,
                    $"Введённый номер списка больше числа списков персон! ({personListQuantity})",
                    $"Введите номер списка для {operation}: ");
        }

        /// <summary>
        /// Получения индекса персоны из listIndex-го списка персон
        /// </summary>
        /// <param name="personQuantity">Число персон в listIndex-м списке персон</param>
        /// <param name="listIndex">Номер списка персон</param>
        /// <param name="operation">Операция с персоной</param>
        /// <returns></returns>
        private static int GetPersonIndex(int personQuantity, int listIndex, string operation)
        {
            return CheckCount(personQuantity,
                    $"Введённый номер персоны для {operation} из " +
                    $"{listIndex}-го списка больше числа персон в {listIndex}-м списке! " +
                    $"({personQuantity})",
                    $"Введите номер персоны для {operation} из {listIndex}-го списка: ");
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
            int primeVar;

            while (!int.TryParse(InputOutput.Input(inputMessage, InputTypeEnum.Digit), out primeVar) 
                    || primeVar > comparedVar)
            {
                InputOutput.TextWriteLine(awareMessage, ConsoleColor.Red);
            }

            return primeVar;
        }

        /// <summary>
        /// Получение количества экземпляров
        /// </summary>
        /// <returns>Количество экземпляров</returns>
        private static int GetQuantity(string inputMessage, string awareMessage)
        {
            try
            {
                return int.Parse(InputOutput.Input(inputMessage, InputTypeEnum.Digit));
            }

            catch (Exception)
            {
                InputOutput.TextWriteLine(awareMessage, ConsoleColor.DarkYellow);
                return PersonList.maxListQuantity;                
            }
        }

        /// <summary>
        /// Процедура заполнения массива списков персон
        /// </summary>
        /// <param name="people">Инициализированный список персон</param>
        private static void GetPersonList(PersonList[] people)
        {
            int personListQuantity = people.Length;
            for (int j = 0; j < personListQuantity; j++)
            {
                int personQuantity = GetQuantity($"Введите число персон " +
                    $"в {j + 1}-м списке: ", $"Создан {j + 1}-й список персон " +
                    $"на {PersonBase.maxPersonQuantity} человек.");
                people[j] = Randomizer.GetRandomList(personQuantity);
                InputOutput.ListWrite(people[j]);
            }
        }
    }
}