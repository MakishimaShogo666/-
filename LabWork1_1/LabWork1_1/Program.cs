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
                OutputInformation.TextWriteLine("Первые списки для экономии времени заполняются случайным образом, " +
                    "поэтому при вводе данных персон добавлена стоп-клавиша Enter");
                OutputInformation.TextWriteLine(null);
                PersonList[] People = null;

                // Создание списков персон
                // 
                int PersonListQuantity = Int32.Parse(OutputInformation.Input("Введите число списков персон: ",1));
                try
                {
                    People = new PersonList[PersonListQuantity];
                }
                catch (Exception)
                {
                    OutputInformation.TextWriteLine($"Создано {PersonList.maxListQuantity} списков персон.");
                    People = new PersonList[PersonList.maxListQuantity];
                }
                
                Person person = new Person();

                // Заполнение списков персон случайными персонами
                // 
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    int PersonQuantity = Int32.Parse(OutputInformation.Input($"Введите число персон в {j+1}-м списке: ",1));
                    try 
                    {
                        People[j] = new PersonList(PersonQuantity);
                    }
                    catch (Exception)
                    {
                        PersonQuantity = Person.maxPersonQuantity;
                        OutputInformation.TextWriteLine($"Создан {j+1}-й список персон {PersonQuantity} человек.");
                        People[j] = new PersonList(PersonQuantity);
                    }
                    for (int i = 0; i < PersonQuantity; i++)
                    {
                        OutputInformation.TextWriteLine($"Ввод данных о {i + 1}-й персоне");
                        OutputInformation.TextWriteLine(null);
                        OutputInformation.Timer();
                        person = Person.GetRandomPerson(); 
                        People[j].data[i] = person; 
                        OutputInformation.PersonWrite(People[j].data[i]); 
                        OutputInformation.TextWriteLine(null);
                    }
                }

                // Добавление персоны в заданный список вручную
                //
                int ListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1));

                while(ListIndex > PersonListQuantity)
                {
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1));
                }

                People[ListIndex-1].Add(Person.PersonRead()); // Добавление персоны в заданный список


                // Копирование заданной персоны в заданный список
                //
                int CopyIndexFrom = Int32.Parse(OutputInformation.Input($"Введите номер персоны для копирования из" +
                    $" {ListIndex}-го списка: ",1)); // Получение номера персоны из ListIndex-го списка

                // Ввод номера персоны до тех пор, пока не будет получено корректное значение 
                //
                while (CopyIndexFrom > People[ListIndex-1].PersonCount())
                {
                    OutputInformation.TextWriteLine($"Введённый номер персоны для копирования из " +
                        $"{ListIndex}-го списка больше числа персон в {ListIndex}-м списке!");
                    CopyIndexFrom = Int32.Parse(OutputInformation.Input($"Введите номер персоны для " +
                        $"копирования из {ListIndex}-го списка: ",1));
                }

                int CopyIndexTo = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для " +
                    $"копирования в него персоны из {ListIndex}-го списка: ",1)); // Получение номера списка для копирования
                while (CopyIndexTo > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение 
                {
                   OutputInformation.TextWriteLine($"Введённый списка больше числа списков персон!");
                   CopyIndexTo = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для " +
                       $"копирования в него персоны из {ListIndex}-го списка: ",1));
                }

                People[CopyIndexTo-1].Add(People[ListIndex-1].data[CopyIndexFrom-1]); // Добавление скопированной персоны в заданный список
                OutputInformation.TextWriteLine("Результат копирования");
                OutputInformation.TextWriteLine(null);
                OutputInformation.TextWriteLine($"Персона из {ListIndex}-го списка:");
                OutputInformation.PersonWrite(People[ListIndex-1].data[CopyIndexFrom-1]); // Вывод копируемой персоны
                OutputInformation.TextWriteLine($"Персона из {CopyIndexTo}-го списка:");
                OutputInformation.PersonWrite(People[CopyIndexTo-1].data[People[CopyIndexTo-1].PersonCount()-1]); // Вывод скопированной персоны
                
                //Удаление заданной персоны
                //
                int ListRemoveIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для удаления персоны: ",1));
                while (ListRemoveIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ListRemoveIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для удаления персоны: ", 1));
                }

                int RemoveIndex = Int32.Parse(OutputInformation.Input($"Введите номер персоны для удаления из " +
                    $"{ListRemoveIndex}-го списка: ",1));
                while (RemoveIndex > People[ListRemoveIndex-1].PersonCount()) 
                {
                    OutputInformation.TextWriteLine($"Введённый номер персоны для удаления из " +
                        $"{ListRemoveIndex}-го списка больше числа персон в {ListRemoveIndex}-м списке!");
                    RemoveIndex = Int32.Parse(OutputInformation.Input($"Введите номер персоны для " +
                        $"удаления из {ListRemoveIndex}-го списка: ",1));
                }

                People[ListRemoveIndex-1].RemoveByIndex(RemoveIndex-1); // Удаление персоны по индексу
                OutputInformation.TextWriteLine("Просмотр списков персон");
                OutputInformation.TextWriteLine(null);

                // Вывод информации из списков персон
                //
                for (int j = 0; j < PersonListQuantity; j++)
                {
                    OutputInformation.TextWriteLine($"{j + 1}-й список персон:");
                    int PersonQuantity = People[j].PersonCount();
                    OutputInformation.ListWrite(PersonQuantity, People[j]);
                }

                int ClearListIndex = Int32.Parse(OutputInformation.Input($"Введите номер списка персон для удаления: ",1));
                while (ClearListIndex > PersonListQuantity) // Ввод номера списка до тех пор, пока не будет получено корректное значение
                {
                    OutputInformation.TextWriteLine("Введённый номер списка больше числа списков персон!");
                    ClearListIndex = Int32.Parse(OutputInformation.Input("Введите номер списка для добавления персоны: ",1));
                }

                People[ClearListIndex-1].ClearList(); // Очистка заданного списка

                int PersonClearListQuantity = People[ClearListIndex-1].PersonCount(); // Подсчёт персон в очищенном списке
                OutputInformation.TextWriteLine($"Вывод данных {ClearListIndex}-го списка:");
                
                if (PersonClearListQuantity != 0) // Если число персон в очищенном списке не равно 0
                {
                    OutputInformation.ListWrite(PersonClearListQuantity,People[ClearListIndex - 1]);
                }
                else //иначе выводится сообщение о том, что список пуст
                {
                    OutputInformation.TextWriteLine($"{ClearListIndex}-й список персон очищен!");
                }

                OutputInformation.TextWriteLine(null);

                exit = OutputInformation.QuitOfProgram(exit); // Вызов функции выхода из программы
            }
        }
    }
}
