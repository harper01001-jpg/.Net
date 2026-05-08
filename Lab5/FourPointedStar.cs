using System;
using System.Drawing;

namespace Lab5
{
    // Атрибут Serializable дозволяє зберігати об'єкт у файл
    [Serializable]
    public class FourPointedStar
    {
        // Властивості (розміри a та b)
        public float A { get; set; }
        public float B { get; set; }

        // Конструктор без параметрів (створює екземпляр зі значенням 0)
        public FourPointedStar()
        {
            A = 0;
            B = 0;
        }

        // Конструктор з параметрами
        public FourPointedStar(float a, float b)
        {
            A = a;
            B = b;
        }

        // Метод для малювання фігури
        public void Draw(Graphics g, float centerX, float centerY)
        {
            float outerRadius = A / 2; // Відстань до дальніх кінців зірки
            float innerRadius = B / 2; // Відстань до внутрішніх кутів

            // Створюємо масив з 8 точок для малювання зірки
            PointF[] points = new PointF[8];

            // Верхня точка
            points[0] = new PointF(centerX, centerY - outerRadius);
            // Верхній правий внутрішній кут
            points[1] = new PointF(centerX + innerRadius, centerY - innerRadius);
            // Права точка
            points[2] = new PointF(centerX + outerRadius, centerY);
            // Нижній правий внутрішній кут
            points[3] = new PointF(centerX + innerRadius, centerY + innerRadius);
            // Нижня точка
            points[4] = new PointF(centerX, centerY + outerRadius);
            // Нижній лівий внутрішній кут
            points[5] = new PointF(centerX - innerRadius, centerY + innerRadius);
            // Ліва точка
            points[6] = new PointF(centerX - outerRadius, centerY);
            // Верхній лівий внутрішній кут
            points[7] = new PointF(centerX - innerRadius, centerY - innerRadius);

            // Малюємо контур зірки чорним кольором
            g.DrawPolygon(Pens.Black, points);
        }
    }
}