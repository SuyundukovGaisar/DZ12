using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1(Необходимо создать программу, где будет реализовано 3 потока с выводом чисел от 1 до 10)");
            Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread2 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread3 = new Thread(new ThreadStart(PrintNumbers));
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(1500);
            Console.WriteLine("Задача 2(Необходимо создать программу, которая будет вычислять факториал и квадрат от введенного числа)");
            Console.WriteLine("Введите число для вычисления факториала и квадрата:");
            int number = int.Parse(Console.ReadLine());
            Task<int> factorialTask = Task.Run(() =>
            {
                return CalculateFactorial(number);
            });
            int square = number * number;
            Console.WriteLine($"Квадрат числа {number} = {square}");
            Console.WriteLine("Ожидайте вычисление факториала...");
            int factorialResult = factorialTask.Result;
            Console.WriteLine($"Факториал числа {number} = {factorialResult}");

            Console.WriteLine("Задача 3(получить объект и вернуть имена всех методов для этого объекта) ");
            Refl refl = new Refl();
            MethodInfo[] methods = refl.GetType().GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        static int CalculateFactorial(int n)
        {
            Thread.Sleep(8000);
            int factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
