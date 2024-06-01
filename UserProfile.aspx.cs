using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Получение информации о пользователе из базы данных
                if (Session["UserId"] == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                int userId = Convert.ToInt32(Session["UserId"]);
                using (SqlConnection connection = new SqlConnection("Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT имя, email FROM клиенты WHERE код_клиента = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Присваивание значений элементам Label
                                NameLabel.Text = reader["имя"].ToString();
                                EmailLabel.Text = reader["email"].ToString();
                            }
                        }
                    }

                    // Загрузка заказов пользователя
                    LoadUserOrders(userId);
                }
            }
        }

        private void LoadUserOrders(int userId)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True"))
            {
                string query = "SELECT представления.название, заказы.количество, заказы.дата FROM заказы INNER JOIN представления ON заказы.код_представления = представления.код_представления WHERE заказы.код_клиента = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
            }
        }
    }
}
