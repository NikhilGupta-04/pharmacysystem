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
	public partial class salesreport : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string date = DateTime.Now.ToString("yyyy-MM-dd");
				todate.Text = date;
				Panel2.Visible = false;
				Panel1.Visible = false;
			}
		}
		protected void show_Click(object sender, EventArgs e)
		{
			if (fromdate.Text == "" || todate.Text == "")
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
											 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "select invoice.invoiceno,invoice.invoicedate,invoice.customer_name,invoice.customer_mobile_no,invoice.total_amount,invoice.cust_email,login.name  from invoice join login on invoice.bysalesperson=login.user_id  where invoicedate between @from and @todate order by invoiceno";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@from", fromdate.Text);
				cmd.Parameters.AddWithValue("@todate", todate.Text);

				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					invoicelist.DataSource = dr;
					invoicelist.DataBind();
					getsalesprice();
					Panel1.Visible = true;
					Panel2.Visible = true;

				}
				else
				{
					Panel2.Visible = false;
				}
				con.Close();
			}
		}
		public void getsalesprice()
		{
			try
			{
				TextBox1.Text = "0";
				for (int i = 0; i < invoicelist.Rows.Count; i++)
				{
					TextBox1.Text = (Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(invoicelist.Rows[i].Cells[4].Text.ToString())).ToString();
				}
			}
			catch (Exception) { }

		} 
		protected void invoicelist_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			if (e.CommandName == "print")
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
				string val = invoicelist.Rows[rowIndex].Cells[0].Text;
				Response.Redirect("printinvoice.aspx?invoiceno=" + val + "&role=admin");

			}
		}
	}
}