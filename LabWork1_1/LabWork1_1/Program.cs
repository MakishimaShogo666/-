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
                OutputInformation.TextWriteLine("Первые списки для экономии времени заполняются случайным образом, поэтому при вводе данных персон добавлена стоп-клавиша Enter");
                OutputInformation.TextWriteLine(null);
                //Console.WriteLine("Первые списки для экономии времени заполняются случайным образом, поэтому при вводе данных персон добавлена стоп-клавиша Enter");
                //Console.WriteLine();


                int PersonListQuantity = Int32.Parse(OutputInformation.Input("Введите число списков персон: ",1)); // Ввод числа списков персон
                PersonList[] People = new PersonList[PersonListQuantity]; // Инициализация массива списков персон
                Person person = new Person(); // инициализация объекта person класса Person конструктором по умолчанию

                // Заполнение списков персон случайными персонами
                // 
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    int PersonQuantity = Int32.Parse(OutputInformation.Input($"Введите число персон в {j+1}-м списке: ",1));
                    People[j] = new PersonList(PersonQuantity);
                    for (int i = 0; i < PersonQuantity; i++)
                    {
                        OutputInformation.TextWriteLine($"Ввод данных о {i + 1}-й персоне");
                        OutputInformation.TextWriteLine(null);
                        //Console.WriteLine($"Ввод данных о {i + 1}-й персоне");
                        //Console.WriteLine();

                        if (Console.ReadKey().Key == ConsoleKey.Enter) // Если нажата клавиша Enter, информация о персоне заполняется и выводится
                        {
                            person = Person.GetRandomPerson(); // Создание случайной персоны
                            People[j].data[i] = person; // Добавление случайной персоны в j-ый список
                            OutputInformation.PersonWrite(People[j].data[i]); // Вывод информации о персоне в консоль
                            OutputInformation.TextWriteLine(null);
                            //Console.WriteLine();
                        }
                    }
                }

                // Добавление персоны в заданный список вручную
                //
                int ListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1)); // Получение номера списка
                while(ListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    //Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1));
                }
                People[ListIndex-1].Add(Person.PersonRead()); // Добавление персоны в заданный список

                // Копирование заданной персоны в заданный список
                //
                int CopyIndexFrom = Int32.Parse(OutputInformation.Input($"Введите номер персоны для копирования из {ListIndex}-го списка: ",1)); // Получение номера персоны из ListIndex-го списка
                while (CopyIndexFrom > People[ListIndex-1].PersonCount()) // Ввод номера персоны до тех пор, пока не будет получено корректное значение 
                {
                    OutputInformation.TextWriteLine($"Введённый номер персоны для копирования из {ListIndex}-го списка больше числа персон в {ListIndex}-м списке!");
                    //Console.WriteLine($"Введённый номер персоны для копирования из {ListIndex}-го списка больше числа персон в {ListIndex}-м списке!");
                    CopyIndexFrom = Int32.Parse(OutputInformation.Input($"Введите номер персоны для копирования из {ListIndex}-го списка: ",1));
                }

                int CopyIndexTo = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для копирования в него персоны из {ListIndex}-го списка: ",1)); // Получение номера списка для копирования
                while (CopyIndexTo > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение 
                {
                   OutputInformation.TextWriteLine($"Введённый списка больше числа списков персон!");
                   //Console.WriteLine($"Введённый списка больше числа списков персон!");
                   CopyIndexTo = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для копирования в него персоны из {ListIndex}-го списка: ",1));
                }

                People[CopyIndexTo-1].Add(People[ListIndex-1].data[CopyIndexFrom-1]); // Добавление скопированной персоны в заданный список
                OutputInformation.TextWriteLine("Результат копирования");
                OutputInformation.TextWriteLine(null);
                OutputInformation.TextWriteLine($"Персона из {ListIndex}-го списка:");
                //Console.WriteLine("Результат копирования"); 
                //Console.WriteLine();
                //Console.WriteLine($"Персона из {ListIndex}-го списка:");
                OutputInformation.PersonWrite(People[ListIndex-1].data[CopyIndexFrom-1]); // Вывод копируемой персоны
                OutputInformation.TextWriteLine($"Персона из {CopyIndexTo}-го списка:");
                //Console.WriteLine($"Персона из {CopyIndexTo}-го списка:");
                OutputInformation.PersonWrite(People[CopyIndexTo-1].data[People[CopyIndexTo-1].PersonCount()-1]); // Вывод скопированной персоны
                

                int ListRemoveIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для удаления персоны: ",1));
                while (ListRemoveIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    //Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ListRemoveIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для удаления персоны: ", 1));
                }

                int RemoveIndex = Int32.Parse(OutputInformation.Input($"Введите номер персоны для удаления из {ListRemoveIndex}-го списка: ",1));
                while (RemoveIndex > People[ListRemoveIndex-1].PersonCount()) // Ввод номера персоны до тех пор, пока не будет получено корректное значение
                {
                    //Console.WriteLine($"Введённый номер персоны для удаления из {ListRemoveIndex}-го списка больше числа персон в {ListRemoveIndex}-м списке!");
                    OutputInformation.TextWriteLine($"Введённый номер персоны для удаления из {ListRemoveIndex}-го списка больше числа персон в {ListRemoveIndex}-м списке!");
                    RemoveIndex = Int32.Parse(OutputInformation.Input($"Введите номер персоны для удаления из {ListRemoveIndex}-го списка: ",1));
                }

                People[ListRemoveIndex-1].RemoveByIndex(RemoveIndex-1); // удаление персоны по индексу
                OutputInformation.TextWriteLine("Просмотр списков персон");
                OutputInformation.TextWriteLine(null);
                //Console.WriteLine("Просмотр списков персон");
                //Console.WriteLine();

                // Вывод информации из списков персон
                //
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    //Console.WriteLine($"{j+1}-й список персон:");
                    OutputInformation.TextWriteLine($"{j + 1}-й список персон:");
                    int PersonQuantity = People[j].PersonCount();
                    OutputInformation.ListWrite(PersonQuantity, People[j]);
                    //for (int i = 0; i < PersonQuantity; i++)
                    //{
                    //    Console.WriteLine($"Ввод данных о {i+1}-й персоне");
                    //    Console.WriteLine();
                    //    OutputInformation.PersonWrite(People[j].data[i]);
                    //    Console.WriteLine();
                    //}
                }

                int ClearListIndex = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для удаления: ",1));
                while (ClearListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    //Console.WriteLine("Введённый номер списка больше числа списков персон!");
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ClearListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1));
                }
                People[ClearListIndex-1].ClearList(); // Очистка заданного списка

                int PersonClearListQuantity = People[ClearListIndex-1].PersonCount(); // Подсчёт персон в очищенном списке
                //Console.WriteLine($"Вывод данных {ClearListIndex}-го списка:");
                OutputInformation.TextWriteLine($"Вывод данных {ClearListIndex}-го списка:");
                
                // Если число персон в очищенном списке не равно 0, то они выводятся в консоль, иначе выводится сообщение о том, что список пуст
                if (PersonClearListQuantity != 0)
                {
                    OutputInformation.ListWrite(PersonClearListQuantity,People[ClearListIndex - 1]);
                    //for (int i = 0; i < PersonClearListQuantity; i++)
                    //{
                    //    Console.WriteLine($"Ввод данных о {i + 1}-й персоне");
                    //    Console.WriteLine();
                    //    OutputInformation.PersonWrite(People[ClearListIndex - 1].data[i]);
                    //    Console.WriteLine();
                    //}
                }
                else
                {
                    //Console.WriteLine($"{ClearListIndex}-й список персон очищен!");
                    OutputInformation.TextWriteLine($"{ClearListIndex}-й список персон очищен!");
                }
                //Console.WriteLine();
                OutputInformation.TextWriteLine(null);
                exit = OutputInformation.QuitOfProgram(exit); // Вызов функции выхода из программы
            }
        }

        /// <summary>
        /// Функция EndOfProgramm для выхода из запущенной программы
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// Возвращает true, если клавиша Enter не нажата, false - если нажата
        /// </returns>
        //public static bool EndOfProgramm(bool a)
        //{
        //    //Console.WriteLine("\n" + "Для продолжения работы программы нажмите Enter, для выхода из программы нажмите любую другую клавишу" + "\n");
        //    OutputInformation.TextWriteLine("\n" + "Для продолжения работы программы нажмите Enter, для выхода из программы нажмите любую другую клавишу" + "\n");
        //    return OutputInformation.QuitOfProgram(a);
        //}

    }
}
