using System;
using System.Windows;

namespace EnergyCalculatorWPF
{
    public partial class MainWindow : Window
    {
        // Прискорення вільного падіння (м/с²)
        private const double g = 9.81;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Перевіряємо, чи користувач ввів коректні числа
            if (double.TryParse(txtMass.Text, out double m) &&
                double.TryParse(txtVelocity.Text, out double v) &&
                double.TryParse(txtHeight.Text, out double h))
            {
                // Перевірка на від'ємні значення маси та висоти (фізично некоректні)
                if (m < 0 || h < 0)
                {
                    MessageBox.Show("Маса та висота не можуть бути від'ємними.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Обчислення кінетичної енергії: E = (m * v^2) / 2
                double kineticEnergy = (m * Math.Pow(v, 2)) / 2;

                // Обчислення потенційної енергії: P = m * g * h
                double potentialEnergy = m * g * h;

                // Вивід результатів із заокругленням до 2 знаків після коми
                txtKinetic.Text = $"{kineticEnergy:F2} Дж";
                txtPotential.Text = $"{potentialEnergy:F2} Дж";
            }
            else
            {
                // Повідомлення про помилку вводу (наприклад, введення літер замість цифр)
                MessageBox.Show("Будь ласка, введіть коректні числові значення у всі поля.", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}