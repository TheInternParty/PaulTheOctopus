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

        protected void Button2_Click(object sender, EventArgs e)
        {
            getOldMatchesList();
        }

        public void getOldMatchesList()
        {
            
            MyGlobal.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("truncate table Matches_tbl ", MyGlobal.sqlConnection1);
            MyGlobal.sqlConnection1.Close();
            cmd2.ExecuteNonQuery();
            
            for (int i = 1; i < 17; i++)
            {
                insertMatches(i);
            }


            return;


        }

        public void insertMatches(int roundNo)
        {
            MyGlobal.sqlConnection1.Open();
            string Url = "http://footballdb.herokuapp.com/api/v1//event/world.2014/round/"+roundNo.ToString();
            WebRequest webRequest = WebRequest.Create(Url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            var responseText = reader.ReadToEnd();

            Debug.WriteLine(responseText);
            var res = JsonConvert.DeserializeObject<dynamic>(responseText);

            foreach(var item in res.games.Children())
            {

                string team1 = item.team1_key;
                string team2 = item.team2_key;
                DateTime date = Convert.ToDateTime(item.play_at);

                SqlCommand cmd = new SqlCommand("select completed from Matches_tbl where matchdate=@date AND ((team1=@team1 AND team2=@team2) OR (team1=@team2 AND team2=@team1)) ;", MyGlobal.sqlConnection1);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@team1";
                param.Value = team1;
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@team2";
                param1.Value = team2;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@date";
                param2.Value = date;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);


                SqlDataReader rd = cmd.ExecuteReader();
                int count = 0;
                bool comp=false;
                while (rd.Read())
                {
                    count = 1;
                    comp = Convert.ToBoolean(rd[0]);
                    break;

                }
                if (count == 1  && comp)
                {
                    rd.Close();
                    continue;
                }
                rd.Close();
                bool completed=true;
                var team1score = item.score1;
                var team2score = item.score2;
                if (team1score == null)
                {
                    Debug.WriteLine("NULL");
                    completed = false;

                }
                SqlCommand cmd3 = new SqlCommand();

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@team1";
                param6.Value = team1;

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@team2";
                param7.Value = team2;

                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@date";
                param8.Value = date;
                

                SqlParameter param4 = new SqlParameter();
               

                SqlParameter param5 = new SqlParameter();
                


                cmd3.Parameters.Add(param6);
                cmd3.Parameters.Add(param7);
                cmd3.Parameters.Add(param8);
               
              


                if (completed)
                {
                    if (count==0)
                    {

                        cmd3.CommandText = "insert into Matches_tbl (team1, team2, matchdate, completed, team1score, team2score) values(@team1, @team2, @date, 1, @team1score, @team2score);";
                        cmd3.Connection = MyGlobal.sqlConnection1;
                        
                        param4.ParameterName = "@team1score";
                        param4.Value = Convert.ToInt32(team1score);
                        param5.ParameterName = "@team2score";
                        param5.Value = Convert.ToInt32(team2score);
                        cmd3.Parameters.Add(param4);
                        cmd3.Parameters.Add(param5);
                    }
                    else
                    {
                        cmd3.CommandText = "UPDATE matches_tbl SET team1score=@team1score, team2score=@team2score, completed=1 WHERE matchdate=@date AND ((team1=@team1 AND team2=@team2) OR (team1=@team2 AND team2=@team1)) ";
                        cmd3.Connection = MyGlobal.sqlConnection1;
                        
                        param4.ParameterName = "@team1score";
                        param4.Value = Convert.ToInt32(team1score);
                        param5.ParameterName = "@team2score";
                        param5.Value = Convert.ToInt32(team2score);
                        cmd3.Parameters.Add(param4);
                        cmd3.Parameters.Add(param5);


                    }
                
                }
                else
                {
                    cmd3.CommandText = "insert into Matches_tbl (team1, team2, matchdate, completed) values(@team1, @team2, @date, 0);";
                    cmd3.Connection = MyGlobal.sqlConnection1;
                   

                   // SqlCommand cmd3 = new SqlCommand("", MyGlobal.sqlConnection1);

                }


                Debug.WriteLine(cmd3.ExecuteNonQuery());
                //rd.Close();
                Debug.WriteLine("Success");


            }



            MyGlobal.sqlConnection1.Close();


        
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(TextBox1.Text);
            int month = Convert.ToInt32(TextBox2.Text);
            int day = Convert.ToInt32(TextBox3.Text);

            DateTime date = new DateTime(year, month, day);
            GetMatches(date);

        }

        public void GetMatches(DateTime date)
        {
            int round = GetRound(date);
            insertMatches(round);

            return;


        }

        public int GetRound(DateTime date)
        {
            int round = 0;
            Debug.WriteLine(date);
            string Url = "http://footballdb.herokuapp.com/api/v1//event/world.2014/rounds/";
            WebRequest webRequest = WebRequest.Create(Url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            var responseText = reader.ReadToEnd();

            Debug.WriteLine(responseText);
            var res = JsonConvert.DeserializeObject<dynamic>(responseText);

            foreach (var item in res.rounds.Children())
            {

                DateTime sdate = Convert.ToDateTime(item.start_at);
                DateTime edate = Convert.ToDateTime(item.end_date);
                //Debug.WriteLine(sdate);
                int a = DateTime.Compare(date, sdate);
                int b = DateTime.Compare(date, edate);
                //Debug.WriteLine(a);
                //Debug.WriteLine(b);

                if ( a<=0 && b>=0)
                {
                    round = Convert.ToInt32(item.pos);
                    break;
                }


            }
            Debug.WriteLine(round);

            return round;
        }




    }
}