using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace projectpharmacy
{
	public partial class forgot : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		public void sendpassword(String password, String email)
		{
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.Credentials = new System.Net.NetworkCredential("mayurmahajan9325@gmail.com", "midzausgggxplanh");
			smtp.EnableSsl = true;
			MailMessage msg = new MailMessage();
			msg.Subject = "Forgotted Password";
			msg.Body = "Dear " + user1.Text + ", Your Password is  " + password + "\n\n\nThanks & Regards\nMedix Pharma Solutions";
			string toaddress = email1.Text;
			msg.To.Add(toaddress);
			string fromaddress = "gnikhilgsanraj09@gmail.com";
			msg.From = new MailAddress(fromaddress);
			try
			{
				smtp.Send(msg);


			}
			catch
			{
				throw;
			}
		}

		protected void submit_Click(object sender, EventArgs e)
		{

			String password;
			string str = @"Data source= LAPTOP-5PMM5UIQ\SQLEXPRESS;Initial Catalog=project;Integrated Security=True;";
			String myquery = "select * from login where user_id='" + user1.Text + "' and email='" + email1.Text + "'";
			SqlConnection con = new SqlConnection(str);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = myquery;
			cmd.Connection = con;
			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;
			DataSet ds = new DataSet();
			da.Fill(ds);
			if (ds.Tables[0].Rows.Count > 0)
			{

				password = ds.Tables[0].Rows[0]["pass"].ToString();
				sendpassword(password, email1.Text);
				msg.Text = "Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";

			}
			else
			{
				msg.Text = "Your Username is Not Valid or Email Not Registered";

			}
			con.Close();
		}
	}
}