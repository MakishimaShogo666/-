using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    class Program
    {
        static void SimpleNumbersFunction(int n,List<int> SimpleNumbers)
        {
            int k;
            for (int i = 1; i < n; i++)
            {
                k = 0;
                for (int j = 1; j <= i; j++)
                {
                    if ((i % j == 0) & (i != j) & (j != 1))
                    {
                        k++;
                    }
                }
                if (k == 0)
                {
                    SimpleNumbers.Add(i);
                }
            }
        }
        static bool EndOfProgramm(bool a)
        {
            Console.WriteLine("\n" + "Для продолжения работы программы нажмите Enter, для выхода из программы нажмите любую другую клавишу" + "\n");
            if (Console.ReadKey().Key != ConsoleKey.Enter)//условие для выхода из программы
            {
                a = true;//выход из цикла (завершение работы программы)
            }
            return a;
        }
        static int Input(string condition) //функция ввода числа в консоль
        {
            int N0;//объявление переменной, соответствующей числу
            Console.Write(condition); //ввод числа в консоль
            string N = Console.ReadLine().Replace(".", ",");//присвоение строковой переменной значения из консоли
            while (int.TryParse(N, out N0) == false | N0 < 0) //условие проверки корректности введённых данных
            {
                Console.Write("Введите положительное целое число: "); //строка для ввода положительного целого числа
                N = Console.ReadLine().Replace(".", ",");
            }
            return N0; //возврат числа
        }
        static void Main(string[] args)
        {
            bool exit = false; //задание признака окончания программы
            while (exit == false)
            {
                int n = Input("Введите максимальное число из диапазона натуральных чисел: ");
                List<int> SimpleNumbers = new List<int>();
                Console.WriteLine("Простые числа от 1 до {0}:", n);
                SimpleNumbersFunction(n, SimpleNumbers);
                foreach (int h in SimpleNumbers)
                {
                    Console.WriteLine(h);
                }
                exit = EndOfProgramm(exit); //процедура для выхода из программы
            }
        }
    }
}
