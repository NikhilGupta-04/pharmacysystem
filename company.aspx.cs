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
	public partial class company : System.Web.UI.Page
	{
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			if (!IsPostBack)
			{
				showcompany();
			}
		}

		protected void mcomlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			company_name.Text = mcomlist.SelectedRow.Cells[2].Text;
			contact_person.Text = mcomlist.SelectedRow.Cells[3].Text;
			contact.Text = mcomlist.SelectedRow.Cells[4].Text;
		}
		public void showcompany()
		{

			string query = "select * from  company";

			mcomlist.DataSource = dat.GetData(query);

			mcomlist.DataBind();

		}
		public void clear()
		{
			company_name.Text = "";
			contact_person.Text = "";
			contact.Text = "";
		}
		protected void edit_Click(object sender, EventArgs e)
		{
			try
			{
				if (((company_name.Text == "")))
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Error!', 'Select Which Company You Have to Update', 'error')", true);

				}
				else
				{

					string cname = company_name.Text;
					string cperson = contact_person.Text;
					string cont = contact.Text;


					string query = " update company set company_name='" + cname + "',contact_person='" + cperson + "',contact='" + cont + "' where company_id='{0}'";
					query = string.Format(query, mcomlist.SelectedRow.Cells[1].Text);
					int t = dat.SetData(query);
					if (t > 0)
					{
						ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Good Jobs !', ' Your Company Details Is Updated ', 'success')", true);
						showcompany();
						clear();

					}
				}
			}
			catch (Exception ex)
			{
				Response.Write("");
			}
		}

		public void getexistingcomany()
		{


			string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
			string query1 = "select company_name from  company where company_name='"+company_name.Text+"'  ";
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
	protected void savebtn_Click(object sender, EventArgs e)
	{
		if ((company_name.Text == "") || (contact_person.Text == "") || (contact.Text == ""))
		{
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Error!', ' Oops! Missing Data', 'error')", true);

		}
		else

		{
			string cname = company_name.Text;
			string cperson = contact_person.Text;
			string cont = contact.Text;

			string query = "insert into company (company_name,contact_person,contact) values('" + cname + "','" + cperson + "','" + cont + "')";
			int t = dat.SetData(query);
			if (t > 0)
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
						 "swal('Good Job!', ' Your Data Has Been Added !', 'success')", true);
				clear();
				showcompany();

			}
		}
}
	
		protected void dlt_Click(object sender, EventArgs e)
		{
			if (((company_name.Text == "")))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{

				string cname = company_name.Text;
				string cperson = contact_person.Text;
				string cont = contact.Text;


				string query = "delete from company where company_id='{0}'";
				query = string.Format(query, mcomlist.SelectedRow.Cells[1].Text);
				dat.SetData(query);

				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal(' Your Data Has Been Deleted !')", true);
				clear();
				showcompany();

			}

		}

		protected void company_name_TextChanged(object sender, EventArgs e)
		{
			getexistingcomany();
			
		}
	}
}