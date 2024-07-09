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
	public partial class expiring_medicine : System.Web.UI.Page
	{
		string date = DateTime.Now.ToString("yyyy-MM-dd");
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			getexpriedmedicine();
		}

		public void getexpriedmedicine()
		{
			string query = "select manage_stock.batch_id,manage_stock.expiry_date, manage_stock.med_id,manage_stock.stock,medicine.med_name from manage_stock join medicine on medicine.med_id=manage_stock.med_id where manage_stock.expiry_date<'" + date + "'and manage_stock.stock>'0'";
			expiry.DataSource = dat.GetData(query);
			expiry.DataBind();
		}

		protected void expiry_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "return")
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
				string batchid = expiry.Rows[rowIndex].Cells[0].Text;
				string query = " delete from manage_stock where batch_id = '" + batchid + "'";
				int x = dat.SetData(query);
				if (x > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
			 "swal('Good job!', 'Deleted!', 'success')", true);

					getexpriedmedicine();
				}
			}
		}

		protected void expiry_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}