using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        // Оголошуємо графічні інструменти
        public Graphics graph;
        public Pen pen1;

        public Form1()
        {
            InitializeComponent();

            // Ініціалізуємо перо 
            pen1 = new Pen(Color.Red, 2);
            // Створюємо "полотно" для малювання
            graph = this.CreateGraphics();
        }

        
       

        private void button1_Click(object sender, EventArgs e)
        {
            // Розмір та розташування обчислюються автоматично за порядковим номером
            int currentCount = Star.StarCount;

            // З кожним кліком зсуваємо центр зірки вправо та вниз
            Point center = new Point(100 + currentCount * 50, 100 + currentCount * 30);

            // Збільшуємо розміри a та b з кожною новою фігурою
            int a = 80 + currentCount * 20;
            int b = 30 + currentCount * 10;

            // Створюємо новий екземпляр зірки 
            Star newStar = new Star(center, a, b, this);
        }
    }
}