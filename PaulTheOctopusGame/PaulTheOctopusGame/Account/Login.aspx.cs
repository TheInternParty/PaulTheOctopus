using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaulTheOctopusGame.Account
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
        public void login()
        {
            TextBox nameTextBox = (TextBox) Login.FindControl("userName");

            Session("username") = 
            Session("password") = Password.Value;
            Response.Redirect("");
        }
    }
}
