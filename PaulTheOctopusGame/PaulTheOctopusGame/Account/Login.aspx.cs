using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PaulTheOctopusGame.Account
{
    public partial class Login : System.Web.UI.UserControl
    {
        SqlConnection sql_con;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
        protected void Open_Connection()
        {
            sql_con = new SqlConnection(@"Data Source=ciqgur-atd133\sqlexpress;Initial Catalog=ptogame;Integrated Security=SSPI");
            sql_con.Open();
        }
        public void login()
        {
            String username = ((TextBox) LoginUser.FindControl("userName")).Text;
            String password = ((TextBox)LoginUser.FindControl("Password")).Text;
            SqlDataReader rdr;
            Open_Connection();
            SqlCommand cmd = new SqlCommand("select name,password from User_tbl where user_tbl");
            rdr = cmd.ExecuteReader();
            Session["username"] = username;
            Session["password"] = password;
            if(rdr.HasRows)
            while(rdr.Read())
            {
                if(rdr.GetString(0)==username&&rdr.GetString(1)==password)
                {
                    Response.Redirect("");
                    break;
                }
            }

        }
    }
}
