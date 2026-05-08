using System;
using System.Linq;

public class LabFunctions
{
    // Функція 1: повертає значення, скільки разів зустрічається вказаний символ у реченні.
    public int CountChar(string text, char symbol)
    {
        if (string.IsNullOrEmpty(text))
            return 0;

        // Використовуємо LINQ для зручного підрахунку символів
        return text.Count(c => c == symbol);
    }

    // Функція 2: міняє місцями значення змінних a і b, c і d.
    // Використовуємо ключове слово ref, щоб зміни відобразились в оригінальних змінних
    public void SwapVariables(ref int a, ref int b, ref int c, ref int d)
    {
        // Міняємо місцями a та b
        int tempAB = a;
        a = b;
        b = tempAB;

        // Міняємо місцями c та d
        int tempCD = c;
        c = d;
        d = tempCD;
    }
}