using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PaulTheOctopusGame
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = getData();
            GridView1.DataBind();
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MatchId", typeof(int)));
            dt.Columns.Add(new DataColumn("Team 1", typeof(string)));
            dt.Columns.Add(new DataColumn("Team 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Result", typeof(string)));
            dt.Columns.Add(new DataColumn("Prediction", typeof(string)));
            dt.Columns.Add(new DataColumn("Points", typeof(int)));
            MyGlobal.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select matches_tbl.matchid, matches_tbl.team1, matches_tbl.team2, cast(matches_tbl.team1score as varchar)+'-'+cast(matches_tbl.team2score as varchar) as result, cast(user_prediction_tbl.team1score as varchar) +'-'+ cast(user_prediction_tbl.team2score as varchar) as prediction, user_prediction_tbl.points as points from matches_tbl,user_prediction_tbl where user_prediction_tbl.matchid=matches_tbl.matchid and matches_tbl.completed=convert(bit,1) and user_prediction_tbl.username='" + MyGlobal.username + "'";

            cmd.Connection = MyGlobal.sqlConnection1;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MatchId"] = Convert.ToInt32(reader[0]);
                dr["Team 1"] = reader[1];
                dr["Team 2"] = reader[2];
                dr["Result"] = reader[3];
                dr["Prediction"] = reader[4];
                dr["Points"] = Convert.ToInt32(reader[5]);
                dt.Rows.Add(dr);
                Debug.WriteLine("Hello");
            }

            MyGlobal.sqlConnection1.Close();
            return dt; 
        }
    }
}