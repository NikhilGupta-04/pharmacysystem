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
	public partial class printinvoice : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				inoiceno.Text = Request.QueryString["invoiceno"];
				findorderdetails(inoiceno.Text);
				showgridview(inoiceno.Text);


			}

			}
		public void findorderdetails(string orderid)
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "select invoicedate ,customer_name,customer_mobile_no,total_amount from invoice where invoiceno='" + orderid + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						invoicedate.Text = dr["invoicedate"].ToString();
						custname.Text = dr["customer_name"].ToString();
						total.Text = dr["total_amount"].ToString();
						custmob.Text = dr["customer_mobile_no"].ToString();
					}
				}
				con.Close();
			}
			catch (Exception e) { Response.Write(e); }
		}
		public void showgridview(string orderid)
		{

			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = "select invoiceitem.med_id,medicine.med_name ,invoiceitem.quantity,invoiceitem.med_price " +
				"from invoiceitem join medicine on invoiceitem.med_id=medicine.med_id where invoiceno='" + orderid + "'";
			SqlCommand cmd = new SqlCommand(query, con);
			GridView1.DataSource = cmd.ExecuteReader();
			GridView1.DataBind();
			con.Close();
		}

		protected void backtobilling_Click(object sender, EventArgs e)
		{
			if (Request.QueryString["role"] == "salesperson")
			{
				Response.Redirect("billing.aspx");

			}
			else{
				Response.Redirect("salesreport.aspx");

			}

		}

	}
}