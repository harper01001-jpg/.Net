using System;
using System.Reflection; // для роботи з dll
using System.Text;

namespace Lab2_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                // підключення dll
                Assembly a = Assembly.LoadFrom("DLL_Lab2.dll");
                // створення об'єкту
                Object o = a.CreateInstance("LabFunctions");
                Type t = a.GetType("LabFunctions");

                Console.WriteLine("=== 1. Підрахунок символу ===");

                string sentence = "тест перший";
                char searchChar = 'е';

                // параметри
                Object[] args1 = new Object[] { sentence, searchChar };

                // дістаємо метод
                MethodInfo miCount = t.GetMethod("CountChar");

                // виклик
                object countResult = miCount.Invoke(o, args1);

                Console.WriteLine($"Текст: \"{sentence}\"");
                Console.WriteLine($"Символ '{searchChar}' зустрічається {countResult} разів.\n");


                Console.WriteLine("=== 2. Обмін значень ===");

                // масив з a, b, c, d
                Object[] args2 = new Object[] { 1, 2, 88, 99 };
                Console.WriteLine($"ДО: a = {args2[0]}, b = {args2[1]}, c = {args2[2]}, d = {args2[3]}");

                MethodInfo miSwap = t.GetMethod("SwapVariables");

                // тут масив args2 зміниться сам через ref
                miSwap.Invoke(o, args2);

                Console.WriteLine($"ПІСЛЯ: a = {args2[0]}, b = {args2[1]}, c = {args2[2]}, d = {args2[3]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка! Перевір чи файл DLL_Lab2.dll закинуто в папку bin/Debug.");
                Console.WriteLine(ex.Message);
            }

        }
    }
}