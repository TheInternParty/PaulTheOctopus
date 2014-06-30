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
    public partial class Upcoming : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = getData();
            GridView1.DataBind();
            MyGlobal.sqlConnection1.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("Add"))
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;// the row
                GridView myGrid = (GridView)sender;
                //var temp = myGrid.DataKeys[myRow.RowIndex].Value;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                Debug.WriteLine(ID);
                //Debug.WriteLine(temp[2]);
            }
        }

        public SqlDataReader getData()
        {
            MyGlobal.sqlConnection1.Close();
            MyGlobal.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand(); cmd.Connection = MyGlobal.sqlConnection1;
            cmd.CommandText = "select matchid, team1, team2 from matches_tbl where completed=0";
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}