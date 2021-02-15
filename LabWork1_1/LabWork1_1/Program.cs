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
                InputOutput.TextWriteLine("Первые списки для экономии времени заполняются случайным образом, " +
                    "поэтому при вводе данных персон добавлена стоп-клавиша Enter");
                InputOutput.TextWriteLine(null);
                PersonList[] People = null;

                // Создание списков персон
                // 
                int PersonListQuantity = Int32.Parse(InputOutput.Input("Введите число списков персон: ", InputType.Digit));
                try
                {
                    People = new PersonList[PersonListQuantity];
                }
                catch (Exception)
                {
                    InputOutput.TextWriteLine($"Создано {PersonList.maxListQuantity} списков персон.");
                    People = new PersonList[PersonList.maxListQuantity];
                }
                
                Person person = new Person();

                // Заполнение списков персон случайными персонами
                // 
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    int personQuantity = Int32.Parse(InputOutput.Input($"Введите число персон в {j+1}-м списке: ", InputType.Digit));
                    try 
                    {
                        People[j] = new PersonList(personQuantity);
                    }
                    catch (Exception)
                    {
                        personQuantity = Person.maxPersonQuantity;
                        InputOutput.TextWriteLine($"Создан {j+1}-й список персон {personQuantity} человек.");
                        People[j] = new PersonList(personQuantity);
                    }

                    People[j] = Randomizer.GetRandomList(personQuantity);

                    for (int i = 0; i < personQuantity; i++)
                    {
                        InputOutput.TextWriteLine($"Ввод данных о {i + 1}-й персоне");
                        InputOutput.TextWriteLine(null);
                        InputOutput.PersonWrite(People[j].data[i]); 
                        InputOutput.TextWriteLine(null);
                    }
                }

                // Добавление персоны в заданный список вручную
                //
                int ListIndex = Int32.Parse(InputOutput.Input("Введите номер списка для добавления персоны: ", InputType.Digit));

                while(ListIndex > PersonListQuantity)
                {
                    InputOutput.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ListIndex = Int32.Parse(InputOutput.Input("Введите номер списка для добавления персоны: ", InputType.Digit));
                }

                People[ListIndex-1].Add(Person.PersonRead()); // Добавление персоны в заданный список

                InputOutput.TextWriteLine($"Ввод данных о добавленной персоне:");
                InputOutput.TextWriteLine(null);
                InputOutput.PersonWrite(People[ListIndex - 1].data[People[ListIndex - 1].PersonCount()-1]);
                InputOutput.TextWriteLine(null);

                // Копирование заданной персоны в заданный список
                //
                int CopyIndexFrom = Int32.Parse(InputOutput.Input($"Введите номер персоны для копирования из" +
                    $" {ListIndex}-го списка: ", InputType.Digit)); // Получение номера персоны из ListIndex-го списка

                // Ввод номера персоны до тех пор, пока не будет получено корректное значение 
                //
                while (CopyIndexFrom > People[ListIndex-1].PersonCount())
                {
                    InputOutput.TextWriteLine($"Введённый номер персоны для копирования из " +
                        $"{ListIndex}-го списка больше числа персон в {ListIndex}-м списке! ({People[ListIndex - 1].PersonCount()})");
                    CopyIndexFrom = Int32.Parse(InputOutput.Input($"Введите номер персоны для " +
                        $"копирования из {ListIndex}-го списка: ", InputType.Digit));
                }

                int CopyIndexTo = Int32.Parse(InputOutput.Input($"Введите номер списка персон для " +
                    $"копирования в него персоны из {ListIndex}-го списка: ", InputType.Digit)); // Получение номера списка для копирования
                while (CopyIndexTo > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение 
                {
                   InputOutput.TextWriteLine($"Введённый номер списка больше числа списков персон! ({PersonListQuantity})");
                   CopyIndexTo = Int32.Parse(InputOutput.Input($"Введите номер списка персон для " +
                       $"копирования в него персоны из {ListIndex}-го списка: ", InputType.Digit));
                }

                People[CopyIndexTo-1].Add(People[ListIndex-1].data[CopyIndexFrom-1]); // Добавление скопированной персоны в заданный список
                InputOutput.TextWriteLine("Результат копирования");
                InputOutput.TextWriteLine(null);
                InputOutput.TextWriteLine($"Персона из {ListIndex}-го списка:");
                InputOutput.PersonWrite(People[ListIndex-1].data[CopyIndexFrom-1]); // Вывод копируемой персоны
                InputOutput.TextWriteLine($"Персона из {CopyIndexTo}-го списка:");
                InputOutput.PersonWrite(People[CopyIndexTo-1].data[People[CopyIndexTo-1].PersonCount()-1]); // Вывод скопированной персоны
                
                //Удаление заданной персоны
                //
                int ListRemoveIndex = Int32.Parse(InputOutput.Input("Введите номер списка для удаления персоны: ", InputType.Digit));
                while (ListRemoveIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    InputOutput.TextWriteLine($"Введённый номер списка больше числа списков персон! ({PersonListQuantity})");
                    ListRemoveIndex = Int32.Parse(InputOutput.Input("Введите номер списка для удаления персоны: ", InputType.Digit));
                }

                int RemoveIndex = Int32.Parse(InputOutput.Input($"Введите номер персоны для удаления из " +
                    $"{ListRemoveIndex}-го списка: ", InputType.Digit));
                while (RemoveIndex > People[ListRemoveIndex-1].PersonCount()) 
                {
                    InputOutput.TextWriteLine($"Введённый номер персоны для удаления из " +
                        $"{ListRemoveIndex}-го списка больше числа персон в {ListRemoveIndex}-м списке! " +
                        $"({People[ListRemoveIndex - 1].PersonCount()})");
                    RemoveIndex = Int32.Parse(InputOutput.Input($"Введите номер персоны для " +
                        $"удаления из {ListRemoveIndex}-го списка: ", InputType.Digit));
                }

                People[ListRemoveIndex-1].RemoveByIndex(RemoveIndex-1); // Удаление персоны по индексу
                InputOutput.TextWriteLine("Просмотр списков персон");
                InputOutput.TextWriteLine(null);

                // Вывод информации из списков персон
                //
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    InputOutput.TextWriteLine($"{j + 1}-й список персон:");
                    int PersonQuantity = People[j].PersonCount();
                    InputOutput.ListWrite(PersonQuantity, People[j]);
                }

                int ClearListIndex = Int32.Parse(InputOutput.Input($"Введите номер списка персон для удаления: ", InputType.Digit));
                while (ClearListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    InputOutput.TextWriteLine($"Введённый номер списка больше числа списков персон! ({PersonListQuantity})");
                    ClearListIndex = Int32.Parse(InputOutput.Input("Введите номер списка для добавления персоны: ", InputType.Digit));
                }

                People[ClearListIndex-1].ClearList(); // Очистка заданного списка

                int PersonClearListQuantity = People[ClearListIndex-1].PersonCount(); // Подсчёт персон в очищенном списке
                InputOutput.TextWriteLine($"Вывод данных {ClearListIndex}-го списка:");
                
                if (PersonClearListQuantity != 0) // Если число персон в очищенном списке не равно 0, выводится список
                {
                    InputOutput.ListWrite(PersonClearListQuantity,People[ClearListIndex - 1]);
                }
                else //иначе выводится сообщение о том, что список пуст
                {
                    InputOutput.TextWriteLine($"{ClearListIndex}-й список персон очищен!");
                }

                InputOutput.TextWriteLine(null);

                exit = InputOutput.QuitOfProgram(exit); // Вызов функции выхода из программы
            }
        }
    }
}