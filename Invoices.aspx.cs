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
	public partial class Invoices : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		

		protected void Page_Load(object sender, EventArgs e)
		{
			
			
				string date = DateTime.Now.ToString("yyyy-MM-dd");
				todate.Text = date;
			

		}
		protected void show_Click(object sender, EventArgs e)
		{
			//SqlConnection con = new SqlConnection(str);
			//con.Open();
			//string query = "select invoice.invoiceno,invoice.invoicedate,invoice.customer_name,invoice.customer_mobile_no,invoice.total_amount from invoice where bysalesperson='" + Session["splogin"] + "' and invoicedate between '" + fromdate.Text + "' and '" + todate.Text + "'";
			//SqlCommand cmd = new SqlCommand(query, con);
			//SqlDataReader dr = cmd.ExecuteReader();
			//if (dr.Read())
			//{
			//	invoicelist.DataSource = dr;
			//	invoicelist.DataBind();
			//}
			//con.Close();
			if (fromdate.Text == "" || todate.Text == "")
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
											   "swal('Error!', ' Oops! Missing Data', 'error')", true);
			}
			else
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "select invoice.invoiceno,invoice.invoicedate,invoice.customer_name," +
					"invoice.customer_mobile_no,invoice.total_amount from invoice where invoicedate between @from and @todate and bysalesperson='" + Session["splogin"] + "' ";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@from", fromdate.Text);
				cmd.Parameters.AddWithValue("@todate", todate.Text);

				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					invoicelist.DataSource = dr;
					invoicelist.DataBind();
				}
				con.Close();
			}
		}

		protected void invoicelist_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			if (e.CommandName == "print")
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
				string val = invoicelist.Rows[rowIndex].Cells[0].Text;
				Response.Redirect("printinvoice.aspx?invoiceno=" + val + "&role=salesperson");
			}
			}
	}
}