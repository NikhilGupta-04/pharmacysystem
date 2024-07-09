using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectpharmacy
{
	public partial class outofstock : System.Web.UI.Page
	{
		string date = DateTime.Now.ToString("yyyy-MM-dd");
		Models.database dat;
		protected void Page_Load(object sender, EventArgs e)
		{
			dat = new Models.database();
			getoutofstockdmedicine();
			get0stock();
		}

		public void getoutofstockdmedicine()
		{
			string query = "select manage_stock.batch_id,manage_stock.expiry_date, manage_stock.med_id,manage_stock.stock,medicine.med_name from manage_stock join medicine on medicine.med_id = manage_stock.med_id where manage_stock.stock between '1' and '5' and manage_stock.expiry_date>'" + date + "'";
			outofstockproduct.DataSource = dat.GetData(query);
			outofstockproduct.DataBind();
		}
		public void get0stock()
		{
			string query = "select manage_stock.batch_id,manage_stock.expiry_date, manage_stock.med_id,manage_stock.stock,medicine.med_name from manage_stock join medicine on medicine.med_id = manage_stock.med_id where manage_stock.stock ='0'";
			stock0product.DataSource = dat.GetData(query);
			stock0product.DataBind();
		}


	
	

		protected void Outofstock_RowCommand1(object sender, GridViewCommandEventArgs e)
		{
			
		}

		protected void outofstockproduct_RowCommand(object sender, GridViewCommandEventArgs e)
		{

		}

		protected void stock0product_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "return")
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
				string batchid = stock0product.Rows[rowIndex].Cells[0].Text;
				string query = " delete from manage_stock where batch_id = '" + batchid + "'";
				int x = dat.SetData(query);
				if (x > 0)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
							 "swal('Good job!', 'Deleted!', 'success')", true);
					get0stock();
				}
			}
		}
	}
}