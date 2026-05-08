using System;

namespace Lab4
{
    // Оголошення делегатів
    delegate double MathFunction(double x);
    delegate void KeyPressEventHandler(ConsoleKeyInfo key);

    class Program
    {
        // 2. Оголошення події
        public static event KeyPressEventHandler OnKeyPressed;

        // 1.1 Метод обчислення інтеграла, де делегат MathFunction є параметром
        static double RightRectangleIntegral(MathFunction f, double a, double b, int n)
        {
            double dx = (b - a) / n;
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double x = a + i * dx; // Права межа прямокутника
                sum += f(x) * dx;
            }
            return sum;
        }

        // 2. Метод-обробник події, що виводить ім'я
        static void PrintName(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar == 'а' || keyInfo.KeyChar == 'А')
            {
                Console.WriteLine($"\nПодія спрацювала! Натиснуто клавішу: '{keyInfo.KeyChar}'");
                Console.WriteLine("Ваше ім'я: Андрій");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Межі інтегрування 
            double a = 1.0, b = 3.0;
            int n = 10000;

            Console.WriteLine("=== ЗАВДАННЯ 1: Інтеграли (Варіант 6) ===\n");

            // 1.3 Передаємо функції 6-го варіанта як лямбда-вирази
            double res1 = RightRectangleIntegral(x => 1.0 / Math.Cbrt(x), a, b, n);
            Console.WriteLine($"1) ∫ 1/∛x dx ≈ {res1:F5}");

            double res2 = RightRectangleIntegral(x => 1.0 / Math.Sqrt(x * x), a, b, n);
            Console.WriteLine($"2) ∫ 1/√(x²) dx ≈ {res2:F5}");

            double res3 = RightRectangleIntegral(x => Math.Pow(Math.Sin(x), 2), a, b, n);
            Console.WriteLine($"3) ∫ sin²(x) dx ≈ {res3:F5}\n");

            // 1.2 Аналітичне значення та похибка для f(x) = x^2
            Console.WriteLine("--- Аналітичне значення та похибка для f(x) = x^2 ---");

            double numVal = RightRectangleIntegral(x => x * x, a, b, n);
            double analVal = (Math.Pow(b, 3) / 3.0) - (Math.Pow(a, 3) / 3.0);
            double error = Math.Abs(analVal - numVal);

            Console.WriteLine($"Аналітичне значення: {analVal:F6}");
            Console.WriteLine($"Числове значення:    {numVal:F6}");
            Console.WriteLine($"Похибка:             {error:F6}\n");

            Console.WriteLine("=== ЗАВДАННЯ 2: Подія ===");
            Console.WriteLine("Натисніть першу літеру вашого імені ('А'). Для виходу натисніть Escape.");

            // Підписуємо метод-обробник на подію
            OnKeyPressed += PrintName;

            // Цикл для перевірки натискань (ініціювання події)
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Вихід з програми
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                // Якщо на подію хтось підписаний, викликаємо її
                if (OnKeyPressed != null)
                {
                    OnKeyPressed(keyInfo);
                }
            }
        }
    }
}