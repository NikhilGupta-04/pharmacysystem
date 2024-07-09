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
	public partial class categories : System.Web.UI.Page
	{
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			if (!IsPostBack)
			{
				showcategory();
			}
		}

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			catname_tb.Text = GridView1.SelectedRow.Cells[2].Text;
		}
		public void showcategory()
		{

			string query = "select * from  category1 ";

			GridView1.DataSource = dat.GetData(query);

			GridView1.DataBind();

		}
		public void getexistingcomany()
		{


			string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
			string query1 = "select cat_name from  category1 where cat_name='" + catname_tb.Text + "'  ";
			SqlConnection con = new SqlConnection(str);
			con.Open();
			SqlCommand cmd = new SqlCommand(query1, con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				Response.Write("<script>alert('Company Already Exists Try with another one')</script>");
				clear();

			}
			con.Close();

		}
		public void clear()
		{
			catname_tb.Text = "";
		}
		protected void edit_Click(object sender, EventArgs e)
		{
			try
			{
				if ((catname_tb.Text == ""))
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Error!', 'Select Which Category You Have to Update', 'error')", true);

				}
				else
				{

					string catname = catname_tb.Text;

					string query = " update category1 set cat_name='" + catname + "' where cat_id='{0}'";
					query = string.Format(query, GridView1.SelectedRow.Cells[1].Text);
					int t = dat.SetData(query);
					if (t > 0)
					{
						ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Good Jobs !', ' Your Medicine Details Is Updated ', 'success')", true);
						showcategory();
						clear();

					}
				}
			}
			catch (Exception ex)
			{
				Response.Write("");
			}


		}

		protected void savebtn_Click(object sender, EventArgs e)
		{
			if ((catname_tb.Text == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				string catname = catname_tb.Text;


				string query = "insert into category1 (cat_name) values('" + catname + "')";
				int t = dat.SetData(query);
				if (t > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Good Job!', ' Your Data Has Been Added !', 'success')", true);
					clear();
					showcategory();

				}
			}

		}

		protected void dlt_Click(object sender, EventArgs e)
		{
			if ((catname_tb.Text == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				string catname = catname_tb.Text;


				string query = "delete category1 where cat_id='{0}'";
				query = string.Format(query, GridView1.SelectedRow.Cells[1].Text);
				dat.SetData(query);

				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal(' Your Data Has Been Deleted !')", true);
				clear();
				showcategory();

			}

		}

		protected void catname_tb_TextChanged(object sender, EventArgs e)
		{
			getexistingcomany();
		}
	}
}