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
	public partial class Reset : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;");
			con.Open();
			string str = "select * from login where email='" + TextBox1.Text + "'";
			SqlCommand cmd = new SqlCommand(str, con);
			SqlDataReader rd = cmd.ExecuteReader();
			bool up = false;
			while (rd.Read())
			{
				if (TextBox1.Text == rd["email"].ToString())
				{
					up = true;
				}

			}
			rd.Close();
			con.Close();
			if (up == true)
			{
				con.Open();
				string str1 = "update login set pass = '" + TextBox2.Text + "' where Email = '" + TextBox1.Text + "'";

				SqlCommand cmd1 = new SqlCommand(str1, con);
				int t = cmd1.ExecuteNonQuery();
				if (t > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									  "swal('Good Jobs !', ' Your Password Is Updated ', 'success')", true); ;
					TextBox1.Text = "";
					TextBox2.Text = "";
				}


				con.Close();



			}
			else
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Invalid, 'Email Not Exist ', 'error')", true);
				TextBox1.Text = "";
				TextBox2.Text = "";



			}

			//if (con.State == ConnectionState.Closed)
			//{
			//    con.Open();
			//}
			//SqlCommand cmd = new SqlCommand("update login set pass='" + TextBox2.Text + "' where Email='" + TextBox1.Text + "'", con);
			//SqlDataReader dr = cmd.ExecuteReader();

			//if (dr.HasRows)
			//{
			//    Response.Write("<script>alert('OOPS! Email Id Does not Exist ')</script>");
			//    TextBox1.Text = "";
			//    TextBox2.Text = "";


			//}

			//else
			//{



			//    Response.Write("<script>alert('Your Password Had Been Changed')</script>");

			//    TextBox1.Text = "";
			//    TextBox2.Text = "";
			//    TextBox3.Text = "";

			//}

			//    con.Close();



		}
	}
}