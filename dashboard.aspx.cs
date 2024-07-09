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
	public partial class dashboard : System.Web.UI.Page
	{
		string str =@"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";

		protected void Page_Load(object sender, EventArgs e)
		{
			showmedicine();
			showcat();
			showcompany();
			showinvoice();
			showsalesperson();
			showsales();
			showoutofstock();
			showexpired();
		}
		private void showmedicine()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(med_id) from medicine ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			medicine.Text = sum.ToString();
			con.Close();

		}
		private void showcat()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(cat_id) from category1 ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			cat.Text = sum.ToString();
			con.Close();

		}
		private void showcompany()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(company_id) from company ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			comp.Text = sum.ToString();
			con.Close();

		}
		private void showinvoice()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(invoiceno) from invoice ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			invoices.Text = sum.ToString();

			con.Close();
		}
		private void showsalesperson()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(user_id) from login where role='salesperson' ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			total_salesperson.Text = sum.ToString();

			con.Close();
		}
		private void showexpired()
		{
			string date = DateTime.Now.ToString("yyyy-MM-dd");
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(batch_id) from manage_stock where stock>0 and expiry_date<'"+date+"' ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			totalexp.Text = sum.ToString();

			con.Close();
		}
		private void showoutofstock()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select count(batch_id) from manage_stock where stock=0 ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			totaloutofstock.Text = sum.ToString();

			con.Close();
		}
		private void showsales()
		{
			SqlConnection con = new SqlConnection(str);
			con.Open();
			string query = " select sum(total_amount) from invoice ";
			SqlCommand cmd = new SqlCommand(query, con);
			int sum = Convert.ToInt32(cmd.ExecuteScalar());
			totalsales.Text = sum.ToString();

			con.Close();
		}
	}

}
