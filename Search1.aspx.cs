using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2

    {
        public partial class Search1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }



            protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
            {
                Session["IDT"] = this.DropDownList1.SelectedIndex;
            }

            protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
            {
                if (GridView1.SelectedIndex >= 0)
                {
                    // Получите выбранное значение IDG из GridView
                    string selectedIDG = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();

                    // Сохраните выбранное значение IDG в сессии
                    Session["IDG"] = selectedIDG;

                    // Обновите данные в DetailsView
                    //DetailsView1.DataBind();
                }
            }


            protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
            {

            }

            protected void SqlDataSource3_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
            {

            }

            protected void SqlDataSource4_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
            {

            }

            protected void SqlDataSource5_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
            {

            }
        }
    }