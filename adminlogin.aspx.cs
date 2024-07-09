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
	public partial class adminlogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (TextBox1.Text == "" || TextBox2.Text == "")
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Missing Data', ' Click ok To Relogin', 'error')", true);

				}
				else
				{
					SqlConnection con1 = new SqlConnection(@"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;");
					con1.Open();
					SqlCommand cmd1 = new SqlCommand("select * from login where user_id='" + TextBox1.Text + "' and pass='" + TextBox2.Text + "' and role='admin' and status=1", con1);
					SqlDataReader dr = cmd1.ExecuteReader();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							Session["adminid"] = dr["user_id"];
							Response.Write("<script>alert('valid')</script>");
							Response.Redirect("dashboard.aspx");
						}
						con1.Close();
					}
					else
					{
						ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Invalid Credentials', ' Click Ok To ReLogin', 'error')", true);
						TextBox1.Text = "";
						TextBox2.Text = "";

					}
				}
			}
			catch (Exception ex)
			{
				Response.Write("<script>alert('Invalid')</script>");
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("Reset.aspx");
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			Response.Redirect("forgot.aspx");
		}
	}
}