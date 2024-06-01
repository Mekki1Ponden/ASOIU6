using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True";
            bool userExists = CheckUserExists(connectionString, TextBoxLogin.Text, TextBoxEmail.Text);

            if (userExists)
            {
                // Установить текст сообщения об ошибке
                ErrorLabel.Text = "Пользователь с таким логином или электронной почтой уже существует.";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO клиенты (имя, email, логин, пароль) VALUES (@Имя, @Электронная_почта, @Логин, @Пароль)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Имя", TextBoxName.Text);                  
                        command.Parameters.AddWithValue("@Логин", TextBoxLogin.Text);
                        command.Parameters.AddWithValue("@Пароль", HashPassword(TextBoxPassword.Text));
                        command.Parameters.AddWithValue("@Электронная_почта", TextBoxEmail.Text);
                        command.ExecuteNonQuery();
                    }
                }
                Response.Redirect("Search1.aspx");
            }
        }

        private bool CheckUserExists(string connectionString, string login, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM клиенты WHERE логин = @Логин OR email = @Электронная_почта ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Логин", login);
                    command.Parameters.AddWithValue("@Электронная_почта", email);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}