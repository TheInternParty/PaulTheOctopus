using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Diagnostics;
using Microsoft.Runtime;
namespace PaulTheOctopusGame
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getTeams();
        }

        public void getTeams()
        {
            //var search = umbraco.library.Request("search");
            string Url = "http://footballdb.herokuapp.com/api/v1//event/world.2014/teams";
            WebRequest webRequest = WebRequest.Create(Url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            var responseText = reader.ReadToEnd();

            Debug.Write(responseText);

            //dynamic res = JsonValue.Parse(responseText)




            
           


            return;
        }



    }
}