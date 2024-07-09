using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace projectpharmacy
{
	public partial class billing : System.Web.UI.Page
	{
		string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
		Models.database dat;
		string date = DateTime.Now.ToString("yyyy-MM-dd");
		
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			
				if (!IsPostBack)
				{

					setinvoiceno();
					getmedicine();
					totalcaculate();
					cartdata();
					Panel2.Visible = false;

				}			

		}

		public void clear1()
		{
			qt.Text = "";
			stotal.Text = "";

		}
		public void clear()
		{
			invoice_id.Text = "";

		}
		public void setinvoiceno()
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				string query = "select max(invoiceno) from invoice";
				con.Open();
				SqlCommand cmd = new SqlCommand(query, con);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.Read())

				{

					string val = dr[0].ToString();
					if (val == "")
					{
						invoice_id.Text = "100001";
					}
					else
					{
						int a = Convert.ToInt32(dr[0].ToString());
						a = a + 1;
						invoice_id.Text = a.ToString();
					}

					invoice_date.Text = date;
				}
				con.Close();
			}
			catch (Exception) { }
		}

		public void getmedicine()
		{
			try
			{
				string query = "select * from medicine";
				mlist.DataSource = dat.GetData(query);
				mlist.DataValueField = "med_id"; /*dat.GetData(query).Columns["med_id"].ToString();*/
				mlist.DataTextField = "med_name"; /*dat.GetData(query).Columns["med_name"].ToString();*/
				mlist.DataBind();
				mlist.Items.Insert(0, "select");
				mlist.Items[0].Selected = false;
				mlist.Items[0].Attributes["Disabled"] = "Disabled";
			}
			catch (Exception) { }

		}
		public void getbatchno()
		{
			try
			{
				string date1 = DateTime.Now.ToString("yyyy-MM-dd");
				string medid = mlist.SelectedValue.ToString();
				string query = "select batch_id,med_id,stock,price from manage_stock where med_id='" + medid + "'and  expiry_date >'" + date1 + "' and stock>0";
				batchlist.DataSource = dat.GetData(query);
				batchlist.DataTextField = "batch_id";
				batchlist.DataValueField = "batch_id";
				batchlist.DataBind();
				batchlist.Items.Insert(0, "select");
				batchlist.Items[0].Selected = false;
				batchlist.Items[0].Attributes["Disabled"] = "Disabled";
			}
			catch (Exception) { }

		}

		public void getpricequant()
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				DateTime date = DateTime.Now;
				con.Open();
				string batchid = batchlist.SelectedValue.ToString();

				string query = "select price,stock from manage_stock where batch_id='" + batchid + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						string unitamount = dr["price"].ToString();
						ut.Text = unitamount;
						string currentstock = dr["stock"].ToString();
						st.Text = currentstock;
					}
					dr.Close();
				}
				con.Close();
			}
			catch (Exception) { }

		}

		public void calclate()
		{
			try
			{
				string qt = this.qt.Text;
				string pr = ut.Text;
				int q = Convert.ToInt32(qt);
				Double p = Convert.ToDouble(pr);
				Double subtotal = (q * p);
				stotal.Text = subtotal.ToString();
			}
			catch (Exception) { }

		}


		protected void quantity_TextChanged(object sender, EventArgs e)
		{
			calclate();

		}




		protected void stotal_TextChanged(object sender, EventArgs e)
		{

		}
		public void updatemedicinedata()
		{
			try
			{
				string batchid = batchlist.SelectedValue.ToString();
				SqlConnection con = new SqlConnection(str);
				string insertinvoice1 = "update invoiceitem set quantity=quantity+" + qt.Text + ",med_price=med_price+" + stotal.Text + " where batchid='" + batchid + "'";

				SqlCommand cmd2 = new SqlCommand(insertinvoice1, con);
				con.Open();
				int j = cmd2.ExecuteNonQuery();
				cartdata();
				totalcaculate();
				con.Close();
			}
			catch (Exception) { }

		}
		protected void addtocart_Click(object sender, EventArgs e)
		{
			try
			{
				if ((mlist.Text == "") || qt.Text == "")
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
									 "swal('Error!', 'Missing Data', 'error')", true);

				}
				else
				{

					string batchid = batchlist.SelectedValue.ToString();
					SqlConnection con = new SqlConnection(str);
					con.Open();
					string query = "select batchid from invoiceitem where batchid='" + batchid + "' and invoiceno=" + invoice_id.Text + "";
					SqlCommand cmd = new SqlCommand(query, con);
					SqlDataReader dr = cmd.ExecuteReader();
					if (dr.HasRows)
					{
						updatemedicinedata();
					}
					else
					{
						insertnewdata();

					}
					con.Close();
				}
			}
			catch (Exception) { }

		}

		public void insertnewdata()
		{

			try
			{
				string mid = mlist.SelectedValue.ToString();
				string batchid = batchlist.SelectedValue.ToString();
				SqlConnection con = new SqlConnection(str);
				int a = Convert.ToInt32(invoice_id.Text);
				string insertinvoice = "insert into invoiceitem (invoiceno,med_id,quantity,med_price,batchid) values (@inno, @medid,@quant,@subtotal,@batchid)";
				con.Open();
				SqlCommand cmd2 = new SqlCommand(insertinvoice, con);
				cmd2.Parameters.AddWithValue("@inno", invoice_id.Text);
				cmd2.Parameters.AddWithValue("@medid", mid);
				cmd2.Parameters.AddWithValue("@quant", qt.Text);
				cmd2.Parameters.AddWithValue("@subtotal", stotal.Text);

				cmd2.Parameters.AddWithValue("@batchid", batchid);

				int j = cmd2.ExecuteNonQuery();
				if (j > 0)
				{

					reduceqty();
					totalcaculate();
					Panel1.Visible = true;
					cartdata();
				}
				con.Close();
			}
			catch (Exception ex) { Response.Write(ex); }



		}
		public void cartdata()
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "select invoiceitem.batchid,medicine.med_name,invoiceitem.quantity," +
					"invoiceitem.med_price from invoiceitem join medicine on medicine.med_id=invoiceitem.med_id " +
					" where invoiceitem.invoiceno='" + invoice_id.Text + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				cart.DataSource = cmd.ExecuteReader();
				cart.DataBind();
				con.Close();
			}
			catch (Exception) { }

		}
		protected void batchlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			getpricequant();
		}


		public void totalcaculate()
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = " select SUM(invoiceitem.med_price) from invoiceitem where invoiceitem.invoiceno = '" + invoice_id.Text + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				int sum = Convert.ToInt32(cmd.ExecuteScalar());
				pricetotal.Text = sum.ToString();
				con.Close();
			}
			catch (Exception) { }
		}


		public void reduceqty()
		{
			try
			{
				string batchid = batchlist.SelectedValue.ToString();
				SqlConnection con = new SqlConnection(str);
				con.Open();
				String query = "update manage_stock set stock = stock - " + qt.Text + " where batch_id = '" + batchid + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				int i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception e)
			{
				Response.Write(e);
			}


		}
		public void regain(string btid)
		{
			try
			{
				SqlConnection con = new SqlConnection(str);
				con.Open();
				string query = "update manage_stock set manage_stock.stock= manage_stock.stock+invoiceitem.quantity from manage_stock join invoiceitem on invoiceitem.batchid=manage_stock.batch_id where manage_stock.batch_id='" + btid + "'";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception) { }

		}

		protected void cart_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "Delete")
				{
					SqlConnection con = new SqlConnection(str);
					con.Open();
					int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
					string batchid = cart.Rows[rowIndex].Cells[1].Text;
					string query = "delete from invoiceitem where batchid = '" + batchid + "'";
					SqlCommand cmd = new SqlCommand(query, con);
					regain(batchid);
					int i = cmd.ExecuteNonQuery();
					if (i > 0)
					{
						cartdata();
					}
					con.Close();
				}
			}
			catch (Exception) { }

		}

		protected void cart_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{

		}

		protected void payment_Click(object sender, EventArgs e)
		{
			if (m_custname.Text == "" || custno2.Text == "" || pricetotal.Text == "" || email.Text == "")
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
								 "swal('Error!', ' Oops! Missing Data', 'error')", true);

			}
			else
			{
				try
				{
					string date = DateTime.Now.ToString("yyyy-MM-dd");

					SqlConnection con = new SqlConnection(str);
					string insertinvoice = "insert into invoice (invoiceno,customer_name,invoicedate,total_amount,customer_mobile_no,bysalesperson,cust_email) values (@inno,@custname,@indate,@totalamount,@custmob,@bysp,@custem)";
					con.Open();
					SqlCommand cmd2 = new SqlCommand(insertinvoice, con);
					cmd2.Parameters.AddWithValue("@inno", invoice_id.Text);
					cmd2.Parameters.AddWithValue("@custname", m_custname.Text);
					cmd2.Parameters.AddWithValue("@indate", date);
					cmd2.Parameters.AddWithValue("@totalamount", pricetotal.Text);

					cmd2.Parameters.AddWithValue("@custmob", custno2.Text);
					cmd2.Parameters.AddWithValue("@bysp", Session["splogin"]);
					cmd2.Parameters.AddWithValue("@custem", email.Text);

					int j = cmd2.ExecuteNonQuery();

					if (j > 0)
					{
						ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
				 "swal('Good job!', 'Payment Done!', 'success')", true);
						sendemail();
						Panel2.Visible = true;
					}
					else
					{
						Panel2.Visible = false;
					}
					con.Close();


				}

				catch (Exception ex) { Response.Write(ex); }
			}

		}

		protected void invoice_Click(object sender, EventArgs e)
		{
			Response.Redirect("printinvoice.aspx?invoiceno=" + invoice_id.Text +"&role=salesperson");
		}

		protected void mlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			getbatchno();
		}
		public void sendemail()
		{
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			//smtp.Credentials = new System.Net.NetworkCredential("studentsrecruiitmentsystem@gmail.com", "qxvrvxcueicdmayb");
			smtp.Credentials = new System.Net.NetworkCredential("pharmacystoremanagementsystemm@gmail.com", "femaazipedhnvcdk");
			smtp.EnableSsl = true;
			MailMessage msg = new MailMessage();
			msg.Subject = "Invoice Details";
			msg.Body = "Dear " + m_custname.Text + ",\n\n Thank Your For Shopping with Medix Pharama \n Your Invoice Number is "+invoice_id.Text+"\n Your Total purchse Price is "+pricetotal.Text+" \n Keep Shopping With us\n\nThanks & Regards\nMedix Pharma Solutions";
			string toaddress = email.Text;
			msg.To.Add(toaddress);
			//string fromaddress = "studentsrecruiitmentsystem@gmail.com";
			string fromaddress = "pharmacystoremanagementsystemm@gmail.com";
			msg.From = new MailAddress(fromaddress);
			try
			{
				smtp.Send(msg);
			}
			catch(Exception ex)
			{
				throw;
			}
		}

	}



}


//public void totalcaculate()
//{
//	try
//	{
//		pricetotal.Text = "0";
//		for (int i = 0; i < cart.Rows.Count; i++)
//		{
//			pricetotal.Text = (Convert.ToInt32(pricetotal.Text) + Convert.ToInt32(cart.Rows[i].Cells[3].Text.ToString())).ToString();
//		}
//	}
//	catch (Exception) { }

//}