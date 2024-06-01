using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ErrorLabel.Text = "Введите логин и пароль";
                return;
            }
            using (SqlConnection connection = new SqlConnection("Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM клиенты WHERE логин = @login", connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            ErrorLabel.Text = "Пользователь не найден";
                            return;
                        }
                        string hash = reader["пароль"].ToString();
                        string inputHash = HashPassword(password); // Хешируем введенный пароль
                        if (hash != inputHash)
                        {
                            ErrorLabel.Text = "Неверный пароль";
                            return;
                        }

                        // Сохраняем имя пользователя в сессию
                        Session["UserName"] = reader["имя"].ToString();
                        Session["Email"] = reader["email"].ToString();

                        // Сохраняем код клиента в сессию
                        int userId = (int)reader["код_клиента"];
                        Session["UserId"] = userId;
                        Response.Redirect("UserProfile.aspx");
                    }
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

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
