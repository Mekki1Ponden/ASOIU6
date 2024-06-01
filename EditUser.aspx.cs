using System;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Загрузка данных пользователя при первой загрузке страницы
                LoadUserData();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Сохранение измененных данных пользователя
            int userId = Convert.ToInt32(Session["UserId"]);
            string newName = NameTextBox.Text;
            string newEmail = EmailTextBox.Text;

            // Обновление данных в базе данных
            string connectionString = "Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE клиенты SET имя = @имя, email = @email WHERE код_клиента = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@имя", newName);
                    command.Parameters.AddWithValue("@email", newEmail);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            // Если данные успешно обновлены, перенаправляем пользователя на страницу профиля
                            Response.Redirect("UserProfile.aspx");
                        }
                        else
                        {
                            // В случае ошибки выводим сообщение
                            Response.Write("<script>alert('Ошибка при сохранении данных пользователя. Пожалуйста, попробуйте еще раз.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Произошла ошибка: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        private void LoadUserData()
        {
            // Загрузка данных пользователя для отображения на странице
            int userId = Convert.ToInt32(Session["UserId"]);
            string connectionString = "Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT имя, email FROM клиенты WHERE код_клиента = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполнение текстовых полей текущими данными пользователя
                            NameTextBox.Text = reader["имя"].ToString();
                            EmailTextBox.Text = reader["email"].ToString();
                        }
                    }
                }
            }
        }
    }
}
