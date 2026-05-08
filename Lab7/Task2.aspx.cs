using System;
using System.IO;

namespace Lab7
{
    public partial class Task2 : System.Web.UI.Page
    {
        // Встановлюємо максимальну кількість спроб
        private const int MaxAttempts = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ініціалізуємо лічильник при першому завантаженні сторінки
            if (!IsPostBack)
            {
                if (Session["LoginAttempts"] == null)
                {
                    Session["LoginAttempts"] = 0;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int attempts = (int)Session["LoginAttempts"];

            // Перевіряємо, чи не перевищено ліміт спроб
            if (attempts >= MaxAttempts)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Спроби вичерпано! Форму заблоковано.";
                btnRegister.Enabled = false; // Блокуємо кнопку
                return;
            }

            try
            {
                // Зчитуємо правильні логін і пароль з файлів
                string loginFilePath = Server.MapPath(@"login.txt");
                string passFilePath = Server.MapPath(@"pass.txt");

                string correctLogin = File.ReadAllText(loginFilePath).Trim();
                string correctPass = File.ReadAllText(passFilePath).Trim();

                string inputLogin = txtLogin.Text.Trim();
                string inputPass = txtPassword.Text.Trim();

                // Перевіряємо правильність введених даних
                if (inputLogin == correctLogin && inputPass == correctPass)
                {
                    // Логін і пароль вірні
                    string userDataFilePath = Server.MapPath(@"userdata.txt");
                    string dataToSave = $"ПІБ: {txtUserData.Text}, Логін: {inputLogin}, Час: {DateTime.Now}\n";

                    // Записуємо дані у файл
                    File.AppendAllText(userDataFilePath, dataToSave);

                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Успішне завершення реєстрації! Дані збережено.";

                    // Скидаємо лічильник після успішного входу
                    Session["LoginAttempts"] = 0;
                }
                else
                {
                    // Логін або пароль невірні
                    attempts++;
                    Session["LoginAttempts"] = attempts;

                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = $"Пароль або логін невірні! Залишилось спроб: {MaxAttempts - attempts}";

                    // Якщо це була остання спроба, блокуємо одразу
                    if (attempts >= MaxAttempts)
                    {
                        lblResult.Text = "Пароль або логін невірні! Спроби вичерпано. Форму заблоковано.";
                        btnRegister.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Помилка роботи з файлами: " + ex.Message +
                                 " (Переконайтесь, що файли login.txt та pass.txt існують).";
            }
        }
    }
}