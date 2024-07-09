using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectpharmacy
{
	public partial class adminmodule : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["adminid"] == null)
			{
				Response.Redirect("adminlogin.aspx");
			}


		}

		protected void timer_Tick(object sender, EventArgs e)
		{
			DateTime dt = DateTime.Now;
			string Day = dt.Day.ToString();
			string Month = dt.ToString("MMM");
			string Hour = dt.Hour.ToString();
			string Minute = dt.ToString("mm");
			string second = dt.ToString("ss");
			time.Text = Day + " " + Month + "   " + Hour + ":" + Minute + ":" + second;

		}
	}
	
	}
