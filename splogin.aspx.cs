using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace projectpharmacy
{
	public partial class splogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				SqlConnection con = new SqlConnection(@"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;");
				
				con.Open();
				SqlCommand cmd = new SqlCommand("select * from login where user_id='" + TextBox1.Text + "' and pass='" + TextBox2.Text + "' and role='salesperson'", con);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Session["splogin"] = dr[0];

						Response.Redirect("billing.aspx");
						con.Close();
					}
				}

				else
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								"swal('Invalid Credentials', ' Click Ok To ReLogin', 'error')", true);
					TextBox1.Text = "";
					TextBox2.Text = "";
				}
				con.Close();
			}
			catch (Exception ex)
			{
				Response.Write(ex);
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("forgot.aspx");
		}
	}
}