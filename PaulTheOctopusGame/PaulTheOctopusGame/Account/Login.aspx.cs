using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PaulTheOctopusGame.Account
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection sql_con;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
       /* protected void Open_Connection()
        {
            sql_con = new SqlConnection("Data Source=ciqgur-atd133\\sqlexpress;Initial Catalog=ptogame;Integrated Security=SSPI");
            sql_con.Open();
        }*/
        public void login(object sender, EventArgs e)
        {
            String username = ((TextBox) LoginUser.FindControl("userName")).Text;
            String password = ((TextBox)LoginUser.FindControl("Password")).Text;
            SqlDataReader rdr;
            Session["username"] = username;
            Session["password"] = password;
            //Open_Connection();
            using (sql_con = new SqlConnection("Data Source=ciqgur-atd133\\sqlexpress;Initial Catalog=ptogame;Integrated Security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from User_tbl where name=\'"+username+"\' and password=\'"+password+"\'");
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows && rdr.Read())
                    Response.Redirect("Profile.aspx");
                else
                    Response.Redirect("Login.aspx");
            }

        }
        
    }
}
