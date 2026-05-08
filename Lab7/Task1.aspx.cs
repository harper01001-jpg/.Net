using System;
using System.Text.RegularExpressions; // Необхідно для перевірки Email

namespace Lab7
{
    public partial class Task1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 1. Отримуємо прізвище та видаляємо літери 'а' та 'о' (великі та малі)
            string surname = txtSurname.Text;
            string modifiedSurname = surname.Replace("а", "").Replace("о", "")
                                            .Replace("А", "").Replace("О", "");

            // 2. Перевіряємо email за допомогою регулярного виразу
            string email = txtEmail.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isEmailValid = Regex.IsMatch(email, emailPattern);

            // Формуємо результат для виводу
            string emailResultText = isEmailValid ? "є коректною адресою" : "НЕ є коректною адресою";

            // 3. Виводимо результат у Label1
            Label1.Text = $"Прізвище після видалення 'а' та 'о': {modifiedSurname} <br/>" +
                          $"Введений текст у полі email {emailResultText}.";
        }
    }
}