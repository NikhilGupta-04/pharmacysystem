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
	public partial class manage_stock : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			if (!IsPostBack)
			{

				getmedicine();
				showmedicines();

			}

		}
		protected void batchid_TextChanged(object sender, EventArgs e)
		{
			SqlConnection con1 = new SqlConnection(str);
			con1.Open();
			string query = "select * from manage_stock where batch_id='" + batchid.Text + "'";
			SqlCommand cmd = new SqlCommand(query, con1);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows)
			{
				Response.Write("<script>alert('Batch ID is Already Exist in Stock Try it another one')</script>");
				batchid.Text = "";

			}
			con1.Close();

		}

		public void clear()
		{
			batchid.Text = "";
			mlist.ClearSelection();
			manfd.Text = "";
			expd.Text = "";
			quantity.Text = "";
			price.Text = "";
		}
		public void showmedicines()
		{
			string date = DateTime.Now.ToString("yyyy-MM-dd");
			stockin.Text = date;

			string query = "select manage_stock.batch_id,manage_stock.manufacture_date,manage_stock.expiry_date,manage_stock.stockindate,manage_stock.price,manage_stock.stock ,medicine.med_id,medicine.med_name,category1.cat_name from manage_stock join medicine on manage_stock.med_id = medicine.med_id inner join category1 on medicine.med_category = category1.cat_id; ";

			medlist.DataSource = dat.GetData(query);

			medlist.DataBind();
		}

		public void getmedicine()
		{

			string query = "select * from medicine";
			mlist.DataTextField = dat.GetData(query).Columns["med_name"].ToString();
			mlist.DataValueField = dat.GetData(query).Columns["med_id"].ToString();
			mlist.DataSource = dat.GetData(query);

			mlist.DataBind();
			mlist.Items.Insert(0, "select");
			mlist.Items[0].Selected = true;
			mlist.Items[0].Attributes["Disabled"] = "Disabled";
		}



		protected void savebtn_Click(object sender, EventArgs e)
		{
			string bid = batchid.Text;


			string medlt = mlist.SelectedValue.ToString();
			string manf = manfd.Text;
			string exp = expd.Text;
			string stk = DateTime.Now.ToString("yyyy-MM-dd");
			string qy = quantity.Text;
			string rate = price.Text;


			if ((bid == "") || (medlt == "") || (manf == "") || (exp == "") || (qy == "") || (rate == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}

			else
			{


				string query = "insert into manage_stock(batch_id, med_id, manufacture_date, expiry_date, stockindate, stock, price) values('" + bid + "', '" + medlt + "', '" + manf + "', '" + exp + "', '" + stk + "', '" + qy + "', '" + rate + "')";
				int t = dat.SetData(query);
				if (t > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Good job!', ' Your Medicine is Inserted !', 'success')", true);
					clear();
					showmedicines();

				}




			}
		}



		public void updatemedicine()
		{

			try
			{
				string bid = batchid.Text;


				string medlt = mlist.SelectedValue.ToString();
				//string manf = DateTime.Parse(manfd.Text).ToString("yyyy-MM-dd");
				//string exp =DateTime.Parse(expd.Text).ToString("yyyy-MM-dd");
				string manf = manfd.Text;
				string exp = expd.Text;
				string stk = DateTime.Now.ToString("yyyy-MM-dd");
				string qy = quantity.Text;
				string rate = price.Text;



				if ((bid == "") || (medlt == "") || (manf == "") || (exp == "") || (qy == "") || (rate == ""))
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Error!', 'Select Which Type of Data You Want To Update', 'error')", true);


				}

				else
				{
					SqlConnection con1 = new SqlConnection(str);
					con1.Open();
					string query1 = "select * from manage_stock where batch_id='" + batchid.Text + "'";
					SqlCommand cmd = new SqlCommand(query1, con1);
					SqlDataReader dr = cmd.ExecuteReader();
					if (!dr.HasRows)
					{
						Response.Write("<script>alert('To save New Medicine Please click to Save Button')</script>");

					}
					else
					{

						string query = "update manage_stock set manufacture_date ='" + manf + "', expiry_date='" + exp + "', stock='" + qy + "', price='" + rate + "' where batch_id ='" + bid + "'";
						int t = dat.SetData(query);
						if (t > 0)
						{
							ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Good job!', 'Your Details is Updated!', 'success')", true);
							clear();
							showmedicines();

						}

					}
				}
			}
			catch (Exception e) { }
		}
		protected void medlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			string str1 = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";



			string key = "";
			SqlConnection con1 = new SqlConnection(str1);
			key = medlist.SelectedRow.Cells[1].Text;
			batchid.Text = key;
			con1.Open();
			string query = "select * from manage_stock where batch_id='" + key + "'";
			SqlCommand cmd = new SqlCommand(query, con1);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{

				string medlt = dr["med_id"].ToString();
				mlist.Text = medlt;


				string manf = dr["manufacture_date"].ToString();
				manfd.Text = DateTime.Parse(manf).ToString("yyyy-MM-dd");

				string exp = dr["expiry_date"].ToString();
				expd.Text = DateTime.Parse(exp).ToString("yyyy-MM-dd");

				string stkdate = dr["stockindate"].ToString();
				stockin.Text = DateTime.Parse(stkdate).ToString("yyyy-MM-dd");

				string qy = dr["stock"].ToString();
				quantity.Text = qy;
				string rate = dr["price"].ToString();
				price.Text = rate;



			}

			con1.Close();
		}

		protected void edit_Click(object sender, EventArgs e)
		{
			updatemedicine();
		}
		protected void dlt_Click(object sender, EventArgs e)
		{
			if ((batchid.Text == ""))
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', 'Please Select which Medicine You Have to Delete First ', 'error')", true);

			}

			else
			{

				string bid = batchid.Text;


				string query = "delete from manage_stock where batch_id='{0}'";
				query = string.Format(query, medlist.SelectedRow.Cells[1].Text);
				int t = dat.SetData(query);
				if (t > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							   "swal('Deleted!', ' Your Data Has Been Deleted !', 'info')", true);
					clear();
					showmedicines();
				}

			}
		}

	}
}