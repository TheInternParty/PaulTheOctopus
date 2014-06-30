using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Diagnostics;

namespace PaulTheOctopusGame
{

    class AutoRefresh
    {
        System.Timers.Timer myTimer = new System.Timers.Timer();

        public void StartTimer(ElapsedEventHandler myEvent, double time)
        {
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            myTimer.Interval = time * 1000 * 60;
            myTimer.Enabled = true;
        }


    }

    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AutoRefresh AR = new AutoRefresh();
            AR.StartTimer(myEvent, 10);
        }

        public void myEvent(object source, ElapsedEventArgs e)
        {
            Debug.WriteLine("Working");
            DateTime date = DateTime.Now;
            WebForm1 wb = new WebForm1();
            wb.RefreshData(date);

        }
    }
}
