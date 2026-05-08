using Lab_3;
using System;
using System.Drawing;
using System.Linq;

namespace Lab_3
{
    // Клас, що описує геометричну фігуру "чотирикутна зірка"
    public class Star
    {
        // Статичне поле для підрахунку кількості примірників
        public static int StarCount = 0;

        // Поля, що задають геометричні розміри фігури
        Point center; // Центр фігури
        int a;        // Розмах між зовнішніми кутами (ширина/висота)
        int b;        // Відстань між внутрішніми кутами
        Form1 form;   // Посилання на форму для відображення

        // Конструктор без параметрів 
        public Star()
        {
            a = 0;
            b = 0;
        }

        // Конструктор з параметрами
        public Star(Point c, int sizeA, int sizeB, Form1 form1)
        {
            // Збільшуємо лічильник при створенні нового екземпляра
            StarCount++;

            center = c;
            a = sizeA;
            b = sizeB;
            form = form1;

            // Одразу малюємо фігуру після створення
            Draw(form.pen1, form.graph);
        }

        // Метод для малювання зірки
        public void Draw(Pen pen, Graphics graph)
        {
            if (a == 0 || b == 0) return;

            int R = a / 2;   // зовнішній радіус (довгі промені)
            int r = b / 4;   // внутрішній радіус (впадини)

            Point[] star = new Point[]
            {
        new Point(center.X, center.Y - R),       // верх (довгий)
        new Point(center.X + r, center.Y - r),   // правий верх (внутрішній)
        new Point(center.X + R, center.Y),       // право (довгий)
        new Point(center.X + r, center.Y + r),   // правий низ (внутрішній)
        new Point(center.X, center.Y + R),       // низ (довгий)
        new Point(center.X - r, center.Y + r),   // лівий низ (внутрішній)
        new Point(center.X - R, center.Y),       // ліво (довгий)
        new Point(center.X - r, center.Y - r)    // лівий верх (внутрішній)
            };

            graph.DrawPolygon(pen, star);
        }
    }
}