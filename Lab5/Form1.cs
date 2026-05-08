using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab5
{
    public partial class Form1 : Form
    {
        //поточний об'єкт зірки
        FourPointedStar currentStar = new FourPointedStar();

        public Form1()
        {
            InitializeComponent();
        }

        // 1. КНОПКА МАЛЮВАННЯ
        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtA.Text, out float a) && float.TryParse(txtB.Text, out float b))
            {
                currentStar = new FourPointedStar(a, b);
                pictureBox1.Invalidate(); // Даємо команду перемалювати
            }
            else
            {
                MessageBox.Show("Введіть коректні числа для A та B.");
            }
        }

        // ПОДІЯ МАЛЮВАННЯ В PICTUREBOX
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Малюємо, тільки якщо об'єкт існує і має розмір більше 0
            if (currentStar != null && currentStar.A > 0)
            {
                float cx = pictureBox1.Width / 2f;
                float cy = pictureBox1.Height / 2f;
                currentStar.Draw(e.Graphics, cx, cy);
            }
        }

        // 2. БІНАРНА СЕРІАЛІЗАЦІЯ (ЗБЕРЕЖЕННЯ)
        private void btnSaveBin_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("star.bin", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, currentStar);
                }
                MessageBox.Show("Стан об'єкта успішно збережено у бінарний файл!");
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        // БІНАРНА ДЕСЕРІАЛІЗАЦІЯ (ЗАВАНТАЖЕННЯ)
        private void btnLoadBin_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("star.bin"))
                {
                    using (FileStream fs = new FileStream("star.bin", FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        currentStar = (FourPointedStar)formatter.Deserialize(fs);
                    }
                    // Оновлюємо текстові поля і малюнок
                    txtA.Text = currentStar.A.ToString();
                    txtB.Text = currentStar.B.ToString();
                    pictureBox1.Invalidate();
                    MessageBox.Show("Об'єкт відновлено з бінарного файлу!");
                }
                else MessageBox.Show("Файл не знайдено.");
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        // 3. XML СЕРІАЛІЗАЦІЯ (ЗБЕРЕЖЕННЯ)
        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("star.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FourPointedStar));
                    serializer.Serialize(fs, currentStar);
                }
                MessageBox.Show("Стан об'єкта успішно збережено у XML файл!");
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        // XML ДЕСЕРІАЛІЗАЦІЯ (ЗАВАНТАЖЕННЯ)
        private void btnLoadXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("star.xml"))
                {
                    using (FileStream fs = new FileStream("star.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(FourPointedStar));
                        currentStar = (FourPointedStar)serializer.Deserialize(fs);
                    }
                    txtA.Text = currentStar.A.ToString();
                    txtB.Text = currentStar.B.ToString();
                    pictureBox1.Invalidate();
                    MessageBox.Show("Об'єкт відновлено з XML файлу!");
                }
                else MessageBox.Show("Файл не знайдено.");
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        // 4. РЕФЛЕКСІЯ (ВИВІД ІНФОРМАЦІЇ У RichTextBox)
        private void btnReflection_Click(object sender, EventArgs e)
        {
            // Отримуємо тип нашого класу
            Type type = typeof(FourPointedStar);

            // Використовуємо System.Text.StringBuilder для ефективного формування тексту
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("=== ІНФОРМАЦІЯ ПРО КЛАС (РЕФЛЕКСІЯ) ===");
            sb.AppendLine($"Повна назва: {type.FullName}");
            sb.AppendLine($"Базовий тип: {type.BaseType.Name}");
            sb.AppendLine();

            sb.AppendLine("--- ВЛАСТИВОСТІ ---");
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                sb.AppendLine($"{prop.PropertyType.Name} {prop.Name}");
            }
            sb.AppendLine();

            sb.AppendLine("--- КОНСТРУКТОРИ ---");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo ctor in constructors)
            {
                sb.AppendLine($"{type.Name} (параметрів: {ctor.GetParameters().Length})");
            }
            sb.AppendLine();

            sb.AppendLine("--- МЕТОДИ КЛАСУ ---");
            // Отримуємо тільки методи, оголошені безпосередньо в нашому класі (без успадкованих від Object)
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine($"{method.ReturnType.Name} {method.Name}()");
            }

            // Виводимо весь зібраний текст у ваш RichTextBox
            rtbReflection.Text = sb.ToString();
        }
    }
}