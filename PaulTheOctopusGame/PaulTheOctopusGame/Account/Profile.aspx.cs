using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PaulTheOctopusGame.Account
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //SqlConnection sql_con;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       /* protected void Open_Connection()
        {
            sql_con = new SqlConnection("Data Source=ciqgur-atd133\\sqlexpress;Initial Catalog=ptogame;Integrated Security=SSPI");
            sql_con.Open();
        }*/
        public void profile(object sender, EventArgs e)
        {
            SqlDataReader rdr;
            using (SqlConnection sql_con = new SqlConnection("Data Source=ciqgur-atd133\\sqlexpress;Initial Catalog=ptogame;Integrated Security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("select top 10 name, points from User_tbl order by points desc ");
                rdr = cmd.ExecuteReader();
                int i = 1;
                for (i = 1; i <= 10; i++) {
                    if (rdr.Read())
                    {
                        if (i == 1) {
                            Label1.Text = rdr.GetString(0);
                            Label2.Text = rdr.GetString(1);
                        } else if (i == 2) {
                            Label3.Text = rdr.GetString(0);
                            Label4.Text = rdr.GetString(1);
                        } else if (i == 3) {
                            Label5.Text = rdr.GetString(0);
                            Label6.Text = rdr.GetString(1);
                        } else if (i == 4) {
                            Label7.Text = rdr.GetString(0);
                            Label8.Text = rdr.GetString(1);
                        } else if (i == 5) {
                            Label9.Text = rdr.GetString(0);
                            Label10.Text = rdr.GetString(1);
                        } else if (i == 6) {
                            Label11.Text = rdr.GetString(0);
                            Label12.Text = rdr.GetString(1);
                        } else if (i == 7) {
                            Label13.Text = rdr.GetString(0);
                            Label14.Text = rdr.GetString(1);
                        } else if (i == 8) {
                            Label15.Text = rdr.GetString(0);
                            Label16.Text = rdr.GetString(1);
                        } else if (i == 9) {
                            Label17.Text = rdr.GetString(0);
                            Label18.Text = rdr.GetString(1);
                        } else if (i == 10) {
                            Label19.Text = rdr.GetString(0);
                            Label20.Text = rdr.GetString(1);
                        }  
                    } else {
                        break;
                    }
                }
                table1.Style["display"] = "block";
            }
        }
    }
}