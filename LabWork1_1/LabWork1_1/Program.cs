using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace LabWork1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false; // Индикатор выхода из программы (true - выход из программы)

            // Пока exit = false, код продолжает выполняться
            //
            while (exit == false)
            {
                Console.WriteLine("Первые списки для экономии времени заполняются случайным образом, поэтому при вводе данных персон добавлена стоп-клавиша Enter");
                Console.WriteLine();


                int PersonListQuantity = Person.InputDigit("Введите число списков персон: "); // Ввод числа списков персон
                PersonList[] People = new PersonList[PersonListQuantity]; // Инициализация массива списков персон
                Person person = new Person(); // инициализация объекта person класса Person конструктором по умолчанию

                // Заполнение списков персон случайными персонами
                // 
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    int PersonQuantity = Person.InputDigit($"Введите число персон в {j+1}-м списке: ");
                    People[j] = new PersonList(PersonQuantity);
                    for (int i = 0; i < PersonQuantity; i++)
                    {
                        Console.WriteLine($"Ввод данных о {i + 1}-й персоне");
                        Console.WriteLine();

                        if (Console.ReadKey().Key == ConsoleKey.Enter) // Если нажата клавиша Enter, информация о персоне заполняется и выводится
                        {
                            person = Person.GetRandomPerson(); // Создание случайной персоны
                            People[j].Add(person); // Добавление случайной персоны в j-ый список
                            Person.PersonWrite(People[j].data[i]); // Вывод информации о персоне в консоль
                            Console.WriteLine();
                        }
                    }
                }

                // Добавление персоны в заданный список вручную
                //
                int ListIndex = Person.InputDigit("Введите номер списка для добавления персоны: "); // Получение номера списка
                while(ListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    ListIndex = Person.InputDigit("Введите номер списка для добавления персоны: ");
                }
                People[ListIndex-1].Add(Person.PersonRead()); // Добавление персоны в заданный список

                // Копирование заданной персоны в заданный список
                //
                int CopyIndexFrom = Person.InputDigit($"Введите номер персоны для копирования из {ListIndex}-го списка: "); // Получение номера персоны из ListIndex-го списка
                while (CopyIndexFrom > People[ListIndex-1].PersonCount()) // Ввод номера персоны до тех пор, пока не будет получено корректное значение 
                {
                    Console.WriteLine($"Введённый номер персоны для копирования из {ListIndex}-го списка больше числа персон в {ListIndex}-м списке!");
                    CopyIndexFrom = Person.InputDigit($"Введите номер персоны для копирования из {ListIndex}-го списка: ");
                }

                int CopyIndexTo = Person.InputDigit($"Введите номер списка персон для копирования в него персоны из {ListIndex}-го списка: "); // Получение номера списка для копирования
                while (CopyIndexTo > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение 
                {
                    Console.WriteLine($"Введённый списка больше числа списков персон!");
                    CopyIndexTo = Person.InputDigit($"Введите номер списка персон для копирования в него персоны из {ListIndex}-го списка: ");
                }

                People[CopyIndexTo-1].Add(People[ListIndex-1].data[CopyIndexFrom-1]); // Добавление скопированной персоны в заданный список
                Console.WriteLine("Результат копирования"); 
                Console.WriteLine();
                Console.WriteLine($"Персона из {ListIndex}-го списка:");
                Person.PersonWrite(People[ListIndex-1].data[CopyIndexFrom-1]); // Вывод копируемой персоны
                Console.WriteLine($"Персона из {CopyIndexTo}-го списка:");
                Person.PersonWrite(People[CopyIndexTo-1].data[People[CopyIndexTo-1].PersonCount()-1]); // Вывод скопированной персоны
                

                int ListRemoveIndex = Person.InputDigit("Введите номер списка для удаления персоны: ");
                while (ListRemoveIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    ListRemoveIndex = Person.InputDigit("Введите номер списка для добавления персоны: ");
                }

                int RemoveIndex = Person.InputDigit($"Введите номер персоны для удаления из {ListRemoveIndex}-го списка: ");
                while (RemoveIndex > People[ListRemoveIndex-1].PersonCount()) // Ввод номера персоны до тех пор, пока не будет получено корректное значение
                {
                    Console.WriteLine($"Введённый номер персоны для удаления из {ListRemoveIndex}-го списка больше числа персон в {ListRemoveIndex}-м списке!");
                    RemoveIndex = Person.InputDigit($"Введите номер персоны для копирования из {ListRemoveIndex}-го списка: ");
                }

                People[ListRemoveIndex-1].RemoveByIndex(RemoveIndex-1); // удаление персоны по индексу
                Console.WriteLine("Просмотр списков персон");
                Console.WriteLine();

                // Вывод информации из списков персон
                //
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    Console.WriteLine($"{j+1}-й список персон:");
                    int PersonQuantity = People[j].PersonCount();
                    for (int i = 0; i < PersonQuantity; i++)
                    {
                        Console.WriteLine($"Ввод данных о {i+1}-й персоне");
                        Console.WriteLine();
                        Person.PersonWrite(People[j].data[i]);
                        Console.WriteLine();
                    }
                }

                int ClearListIndex = Person.InputDigit($"Введите номер списка персон для удаления: ");
                while (ClearListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    ClearListIndex = Person.InputDigit("Введите номер списка для добавления персоны: ");
                }
                People[ClearListIndex-1].ClearList(); // Очистка заданного списка

                int PersonClearListQuantity = People[ClearListIndex-1].PersonCount(); // Подсчёт персон в очищенном списке
                Console.WriteLine($"Вывод данных {ClearListIndex}-го списка:"); 
                
                // Если число персон в очищенном списке не равно 0, то они выводятся в консоль, иначе выводится сообщение о том, что список пуст
                if (PersonClearListQuantity != 0)
                {
                    for (int i = 0; i < PersonClearListQuantity; i++)
                    {
                        Console.WriteLine($"Ввод данных о {i + 1}-й персоне");
                        Console.WriteLine();
                        Person.PersonWrite(People[ClearListIndex - 1].data[i]);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"{ClearListIndex}-й список персон очищен!");
                }
                Console.WriteLine();
                exit = EndOfProgramm(exit); // Вызов функции выхода из программы
            }
        }

        /// <summary>
        /// Функция EndOfProgramm для выхода из запущенной программы
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// Возвращает true, если клавиша Enter не нажата, false - если нажата
        /// </returns>
        public static bool EndOfProgramm(bool a)
        {
            Console.WriteLine("\n" + "Для продолжения работы программы нажмите Enter, для выхода из программы нажмите любую другую клавишу" + "\n");
            if (Console.ReadKey().Key != ConsoleKey.Enter)//условие для выхода из программы
            {
                a = true;//выход из цикла (завершение работы программы)
            }
            return a;
        }
    }
}
