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
	public partial class Salesperson_Management : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		Models.database dat = new Models.database();

		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				Panel1.Visible = false;
			}
		}

		public void clear()
		{
			uname.Text = "";
			pass.Text = "";
			email.Text = "";
			mno.Text ="";
			spname.Text = "";
		}
		protected void add_Click(object sender, EventArgs e)
		{
			Panel1.Visible = true;

		}

		protected void show_Click(object sender, EventArgs e)
		{
			//show();
		}
		public void show()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = "select user_id,pass,name, email,status from login where  role='salesperson' and status=1";
			SqlCommand cmd = new SqlCommand(query, con);
			GridView1.DataSource = cmd.ExecuteReader();
			GridView1.DataBind();
			con.Close();
		}



		protected void save_Click(object sender, EventArgs e)
		{

			if (uname.Text == "" || pass.Text == "" || spname.Text == "" || email.Text == "" || mno.Text == "")
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "insert into login ( user_id,pass,name, email,mno, role,status) values ('" + uname.Text + "','" + pass.Text + "','" + spname.Text + "','" + email.Text + "','" + mno.Text + "','salesperson',1)";
				SqlCommand cmd = new SqlCommand(query, con);
				int t = cmd.ExecuteNonQuery();
				if (t > 0)
				{

					Panel1.Visible = false;

				}
				con.Close();
			}
		}
		protected void showdata_Click(object sender, EventArgs e)
		{
			show();
			
		}

		protected void uname_TextChanged(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = "select user_id from login where user_id='" + uname.Text + "' and status=1";
			SqlCommand cmd = new SqlCommand(query, con);
			SqlDataReader dr = cmd.ExecuteReader();
			if(dr.HasRows)
			{
				Response.Write("<script>alert('Salesperson already Exists with the same username ')</script>");
				uname.Text = "";
			}

			con.Close();
		}

		protected void email_TextChanged(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = "select email from login where email='" + email.Text + "' and status=1";
			SqlCommand cmd = new SqlCommand(query, con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				Response.Write("<script>alert('Salesperson already Exists with the same Email ')</script>");
				email.Text = "";

			}
			con.Close();
		}

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{

		}

		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "delete")
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
				string uid = GridView1.Rows[rowIndex].Cells[1].Text;
				string query = " update login set status=0 where user_id = '" + uid + "'";
				int x = dat.SetData(query);
				if (x > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Good job!', 'Deleted!', 'success')", true);
				
				}
			}
		}
	}
}