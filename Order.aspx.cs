using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Заполняем DropDownList данными из таблицы представлений
                FillDropDownList();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении выбора в DropDownList можно выполнить дополнительные действия,
            // например, отобразить дополнительную информацию о выбранном представлении
            // Здесь можно реализовать необходимую логику
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // При нажатии на кнопку "Забронировать" добавляем запись в таблицу заказов
            string connectionString = "Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO заказы (код_представления, код_клиента, количество, дата) VALUES (@код_представления, @код_клиента, @количество, @дата)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Получаем выбранное значение из DropDownList
                    int код_представления = Convert.ToInt32(DropDownList1.SelectedValue);

                    // Получаем код клиента из сессии (предполагается, что он уже установлен после входа в личный кабинет)
                    int код_клиента = Convert.ToInt32(Session["UserId"]);

                    // Получаем количество билетов из TextBox
                    int количество = Convert.ToInt32(TextBox1.Text);

                    // Устанавливаем параметры для команды SQL
                    command.Parameters.AddWithValue("@код_представления", код_представления);
                    command.Parameters.AddWithValue("@код_клиента", код_клиента);
                    command.Parameters.AddWithValue("@количество", количество);
                    command.Parameters.AddWithValue("@дата", DateTime.Now);

                    // Открываем подключение и выполняем запрос
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        // В случае успешного добавления заказа можно выполнить дополнительные действия
                        // Например, перенаправить пользователя на другую страницу или вывести сообщение об успешном заказе
                        Response.Write("<script>alert('Бронирование успешно!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Ошибка бронирования. Пожалуйста, попробуйте еще раз.');</script>");
                    }
                }
            }
        }

        private void FillDropDownList()
        {
            string connectionString = "Data Source=nowtbykes;Initial Catalog=theatre;Integrated Security=True";
            string query = "SELECT код_представления, название FROM представления";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        DropDownList1.DataSource = table;
                        DropDownList1.DataTextField = "название"; // Отображаемое поле
                        DropDownList1.DataValueField = "код_представления"; // Значение поля
                        DropDownList1.DataBind();
                    }
                }
            }
        }
    }
}