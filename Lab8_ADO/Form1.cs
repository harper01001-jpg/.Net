using System;
using System.Data;
using System.Data.SqlClient; //для роботи з ADO.NET
using System.Windows.Forms;

namespace Lab8_ADO
{
    public partial class Form1 : Form
    {
        // Рядок підключення до локальної бази даних
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopDB.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            PopulateInitialData(); // Автоматично додаємо 5 записів, якщо база порожня
            LoadData(); // Завантажуємо дані при запуску програми
        }

        // МЕТОД ДЛЯ АВТОМАТИЧНОГО ЗАПОВНЕННЯ 5 ЗАПИСАМИ
        private void PopulateInitialData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Перевіряємо, скільки записів зараз у таблиці
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Products", conn);
                    int count = (int)checkCmd.ExecuteScalar();

                    // Якщо таблиця порожня (0 записів), додаємо 5 тестових
                    if (count == 0)
                    {
                        string insertSql = @"
                            INSERT INTO Products (Code, Name, Type, Price, Manufacturer, Country, Cost) VALUES
                            (101, N'Ноутбук Acer Aspire 7', N'Електроніка', 25999.50, N'Acer', N'Тайвань', 21000.00),
                            (102, N'Кавомашина Philips', N'Побутова техніка', 12499.00, N'Philips', N'Румунія', 9500.00),
                            (103, N'Стілець офісний Марк', N'Меблі', 3200.00, N'Новий Стиль', N'Україна', 2150.00),
                            (104, N'Смартфон Samsung Galaxy', N'Електроніка', 35000.00, N'Samsung', N'Південна Корея', 28000.00),
                            (105, N'Мікрохвильова піч LG', N'Побутова техніка', 4500.00, N'LG', N'Китай', 3200.00)";

                        SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Якщо таблиці ще не існує, ігноруємо помилку (щоб програма не падала)
                }
            }
        }

        // Метод для читання даних з БД і виведення їх у DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Запит на вибірку всіх даних
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);

                    // Використовуємо DataReader для читання рядків
                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr); // Завантажуємо прочитані дані в таблицю

                    dgvProducts.DataSource = dt; // Показуємо на екрані
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження даних: " + ex.Message);
                }
            }
        }

        // КНОПКА: ДОДАВАННЯ ЗАПИСУ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // SQL запит на додавання (INSERT)
                    string query = "INSERT INTO Products (Code, Name, Type, Price, Manufacturer, Country, Cost) " +
                                   "VALUES (@Code, @Name, @Type, @Price, @Manufacturer, @Country, @Cost)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Передаємо параметри з текстових полів
                    cmd.Parameters.AddWithValue("@Code", int.Parse(txtCode.Text));
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Type", txtType.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));

                    // Виконуємо запит
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Товар успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Оновлюємо таблицю на екрані
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        // КНОПКА: ОНОВЛЕННЯ ЗАПИСУ
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // SQL запит на оновлення (UPDATE)
                    string query = "UPDATE Products SET Name=@Name, Type=@Type, Price=@Price, " +
                                   "Manufacturer=@Manufacturer, Country=@Country, Cost=@Cost WHERE Code=@Code";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Code", int.Parse(txtCode.Text));
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Type", txtType.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));

                    // Виконуємо запит та отримуємо кількість змінених рядків
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Товар успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Товар із таким Кодом не знайдено! Виберіть товар зі списку.",
                                        "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    LoadData();
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        // КНОПКА: ВИДАЛЕННЯ ЗАПИСУ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // SQL запит на видалення (DELETE)
                    SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE Code=@Code", conn);
                    cmd.Parameters.AddWithValue("@Code", int.Parse(txtCode.Text));

                    // Виконуємо запит та отримуємо кількість видалених рядків
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Товар успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Очищаємо текстові поля
                        txtCode.Clear(); txtName.Clear(); txtType.Clear();
                        txtPrice.Clear(); txtManufacturer.Clear(); txtCountry.Clear(); txtCost.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Товар із таким Кодом не знайдено для видалення!",
                                        "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    LoadData();
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        // КЛІК ПО ТАБЛИЦІ: перенесення даних у текстові поля
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                txtCode.Text = row.Cells["Code"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtType.Text = row.Cells["Type"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtManufacturer.Text = row.Cells["Manufacturer"].Value.ToString();
                txtCountry.Text = row.Cells["Country"].Value.ToString();
                txtCost.Text = row.Cells["Cost"].Value.ToString();
            }
        }
    }
}
