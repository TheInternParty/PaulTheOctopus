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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
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

            Debug.WriteLine(responseText);

            //dynamic res = JsonValue.Parse(responseText)

            //JObject res = JObject.Parse(responseText);


            MyGlobal.sqlConnection1.Open();

            SqlCommand cmd2 = new SqlCommand("truncate table Teams_tbl ", MyGlobal.sqlConnection1);
            cmd2.ExecuteNonQuery();
            var res = JsonConvert.DeserializeObject<dynamic>(responseText);
            foreach(var item in  res.teams.Children())
            {
                string teamkey = item.key;
                string teamname = item.title;
                SqlCommand cmd = new SqlCommand("insert into Teams_tbl (teamkey, teamname) values(@teamkey,@teamname);", MyGlobal.sqlConnection1);
                SqlParameter param = new SqlParameter();
                param.ParameterName =  "@teamname";
                param.Value = teamname;
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@teamkey";
                param1.Value = teamkey;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);

                cmd.ExecuteNonQuery();
            }


            MyGlobal.sqlConnection1.Close();

            
            
           


            return;
        }



    }
}