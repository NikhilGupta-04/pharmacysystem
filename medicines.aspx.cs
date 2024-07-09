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
	public partial class medicines : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			if (!IsPostBack)
			{
				getcategories();
				getcompany();
				showmedicines();

			}

		}
		public void getmedid()
		{
			SqlConnection con = new SqlConnection(str);
	
			SqlCommand cmd = new SqlCommand("select med_id from medicine where med_id='" + m_id.Text + "'", con);

			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					Response.Write("<script>alert('oops! Medicine ID is Already Exist! Please Try With Another one')</script>");
				clear();

			}
			con.Close();


		}
		public void showmedicines()
		{

			string query = "select medicine.med_id,medicine.med_name,category1.cat_name ,company.company_name from medicine join category1 on medicine.med_category=category1.cat_id join company on medicine.med_company=company.company_id";

			medlist.DataSource = dat.GetData(query);

			medlist.DataBind();
		}
		public void getcategories()
		{
			string query = "select * from category1";
			m_cat.DataTextField = dat.GetData(query).Columns["cat_name"].ToString();
			m_cat.DataValueField = dat.GetData(query).Columns["cat_id"].ToString();
			m_cat.DataSource = dat.GetData(query);
			m_cat.DataBind();
			m_cat.Items.Insert(0, "select");
			m_cat.Items[0].Selected = true;
			m_cat.Items[0].Attributes["Disabled"] = "Disabled";
		}
		public void getcompany()
		{
			string query = "select * from company";
			mcom.DataTextField = dat.GetData(query).Columns["company_name"].ToString();
			mcom.DataValueField = dat.GetData(query).Columns["company_id"].ToString();
			mcom.DataSource = dat.GetData(query);
			mcom.DataBind();
			mcom.Items.Insert(0, "select");
			mcom.Items[0].Selected = true;
			mcom.Items[0].Attributes["Disabled"] = "Disabled";
		}


		public void insertdata()
		{
			
				string id = m_id.Text;
				string mname = m_name.Text;
				string mcat = m_cat.SelectedValue.ToString();
				string mcompany = mcom.SelectedValue.ToString();

				string query = "insert into medicine (med_id,med_name,med_category,med_company) values('" + id + "','" + mname + "','" + mcat + "','" + mcompany + "')";
				int t = dat.SetData(query);
				if (t > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Good job!', ' Your Medicine is Inserted !', 'success')", true);
					clear();
					showmedicines();

				}

			}
		

		protected void savebtn_Click(object sender, EventArgs e)
		{
			if ((m_id.Text == "") || (m_name.Text == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				insertdata();
				
			}
		}
		string key = "";

		public void getexistingcomany()
		{


			string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
			string query1 = "select med_name from  medicine where med_name='" + m_name.Text + "'  ";
			SqlConnection con = new SqlConnection(str);
			con.Open();
			SqlCommand cmd = new SqlCommand(query1, con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				Response.Write("<script>alert('Medicine Name Already Exists Try with another one')</script>");
				clear();

			}
			con.Close();

		}
		protected void medlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			string str1 = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";




			SqlConnection con1 = new SqlConnection(str1);
			key = medlist.SelectedRow.Cells[1].Text;
			m_id.Text = key;
			con1.Open();
			string query = "select * from medicine where med_id='" + key + "'";
			SqlCommand cmd = new SqlCommand(query, con1);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				string med_name = dr["med_name"].ToString();
				string med_category = dr["med_category"].ToString();
				string med_company = dr["med_company"].ToString();

				m_name.Text = med_name;
				m_cat.Text = med_category;
				mcom.Text = med_company;

			}

			con1.Close();
		}

		public void clear()
		{
			m_id.Text = "";
			m_name.Text = "";
			m_cat.ClearSelection();
			mcom.ClearSelection();
		}
		protected void edit_Click(object sender, EventArgs e)
		{
			try
			{
				if ((m_id.Text == "") || (m_name.Text == "") || (mcom.Text == ""))
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Error!', ' Select Which Data You have to Edit', 'error')", true);

				}
				else
				{

					string id = m_id.Text;
					string mname = m_name.Text;

					string mcat = m_cat.SelectedValue.ToString();
					string mcompany = mcom.SelectedValue.ToString();
					SqlConnection con = new SqlConnection(str);
					con.Open();
					SqlCommand cmd = new SqlCommand("select med_id from medicine where med_id='" + id + "'", con);
					SqlDataReader dr = cmd.ExecuteReader();

					if (!dr.HasRows)
					{
						Response.Write("<script>alert('To save New Medicine Please click to Save Button')</script>");

					}
					else
					{
						string query = " update medicine set med_name='" + mname + "',med_category='" + mcat + "',med_company='" + mcompany + "'  where med_id='" + id + "'";
						int t = dat.SetData(query);
						if (t > 0)
						{
							ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
										 "swal('Good Jobs !', ' Your Medicine Details Is Updated ', 'success')", true);
							clear();
							showmedicines();

							m_cat.SelectedIndex = -1;
						}
					}
					con.Close();
				}
			}
			catch (Exception ex)
			{

			}
		}

		protected void dlt_Click(object sender, EventArgs e)
		{
			if ((m_id.Text == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', 'Please Select which Medicine You Have to Delete First ', 'error')", true);

			}
			else
			{

				string id = m_id.Text;
				string mname = m_name.Text;

				string mcat = m_cat.SelectedValue.ToString();
				string mcompany = mcom.SelectedValue.ToString();


				string query = "delete from medicine where med_id='{0}'";
				query = string.Format(query, medlist.SelectedRow.Cells[1].Text);
				dat.SetData(query);

				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Deleted!', ' Your Data Has Been Deleted !', 'info')", true);
				clear();
				showmedicines();

			}
		}

		protected void m_id_TextChanged(object sender, EventArgs e)
		{
			getmedid();
			
		}

		protected void m_name_TextChanged(object sender, EventArgs e)
		{
			getexistingcomany();
		}
	}
}