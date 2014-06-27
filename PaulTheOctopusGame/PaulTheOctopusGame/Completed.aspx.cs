using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PaulTheOctopusGame
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Tuple<int, string, string, string, string, int> temp = new Tuple<int, string, string, string, string, int>(1, "a", "a", "a", "a", 1);
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("MatchId", typeof(int)));
            dt.Columns.Add(new DataColumn("Team 1", typeof(string)));
            dt.Columns.Add(new DataColumn("Team 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Result", typeof(string)));
            dt.Columns.Add(new DataColumn("Prediction", typeof(string)));
            dt.Columns.Add(new DataColumn("Points", typeof(int)));
            dr = dt.NewRow();
            dr["MatchId"] = 1;
            dr["Team 1"] = "Spain";
            dr["Team 2"] = "Australia";
            dr["Result"] = "3-0";
            dr["Prediction"] = "2-0";
            dr["Points"] = 0;
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            MyGlobal.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText="select matchid,team1,team2,team1score+'-'+team2score,
            return dt; 
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}