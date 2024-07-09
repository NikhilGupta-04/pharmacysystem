<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="manage_stock.aspx.cs" Inherits="projectpharmacy.manage_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="Content/adminaddprod.css" rel="stylesheet" />
	<script type="text/javascript">
		function printGridView() {
			var gridview = document.getElementById('<%= medlist.ClientID %>');
			var windowPrint = window.open('', '', 'height=500,width=800');
			windowPrint.document.write('<html><style type="text/css"></style><body><h1><center>STOCK REPORT</center></h1><h3><center>Medix Pharama Solutions <br>Contact No 9325215926</center></h1>');
			windowPrint.document.write(gridview.outerHTML);
			windowPrint.document.write('</body></html>');
			windowPrint.document.close();
			windowPrint.print(); 
		}
	</script>
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mybody" runat="server">

	<div class="container-fluid">
		<div class="row">
			<div class="col-md-8 mx-auto">
				<br />
				<br />
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>

						<div class="row">
							<div class="col">

								<h4>Manage Stock</h4>

							</div>

						</div>

						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>

						<div class="row">

							<div class="col-md-3">
								<label>Medicine Name</label><br>
								<div class="form-group">
									<asp:DropDownList ID="mlist" runat="server" CssClass="form-control" placeholder="Medicine " AutoPostBack="True">
									</asp:DropDownList>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Missing Batch" ForeColor="Red" ValidationGroup="miss"  ControlToValidate="mlist"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>
							<div class="col-md-3">
								<label>Batch ID</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="batchid" runat="server"  AutoPostBack="true" OnTextChanged="batchid_TextChanged" placeholder="Batch ID"></asp:TextBox>
								<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Missing Batch" ForeColor="Red" ValidationGroup="miss"  ControlToValidate="batchid"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>
							<div class="col-md-3">
								<label>ManuFacturing Date</label><br>
								<div class="form-group">
									<asp:TextBox ID="manfd" type="date" runat="server" CssClass="form-control"></asp:TextBox>
								<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Missing Manufacturing Date"  ForeColor="Red" ValidationGroup="miss"  ControlToValidate="manfd"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>


							<br />

							<div class="col-md-3">
								<label>Expiring Date</label><br>
								<div class="form-group">
									<asp:TextBox ID="expd" type="date" runat="server" CssClass="form-control" ></asp:TextBox>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="miss" runat="server" ErrorMessage="Missing Expiry Date" ForeColor="Red"  ControlToValidate="expd"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>
						</div>
						<br />
						<div class="row">
							<div class="col-md-3">
								<label>Stock IN Date</label><br>
								<div class="form-group">
									<asp:TextBox ID="stockin" type="date" runat="server" ReadOnly="True" CssClass="form-control" ></asp:TextBox>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="miss" runat="server" ErrorMessage="Missing Stock Date" ForeColor="Red"  ControlToValidate="stockin"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>

							<div class="col-md-3">
								<label>Stock</label>

								<asp:TextBox ID="quantity" runat="server" CssClass="form-control" ></asp:TextBox>
								<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Missing Company Name" ForeColor="Red"  ControlToValidate="quantity"></asp:RequiredFieldValidator>--%>
		    
							</div>

							<div class="col-md-3">
								<label>Price per unit</label>

								<asp:TextBox ID="price" runat="server" CssClass="form-control" ></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Missing Price" ForeColor="Red"  ControlToValidate="price"></asp:RequiredFieldValidator>--%>
		    
							</div>


							<div class="form-group">
							</div>
						</div>
					</div>



					<div class="row">
						<div class="col">
							<br />
							&nbsp&nbsp&nbsp
						    <asp:Button ID="edit" ValidationGroup="miss" runat="server" Text="Edit" class="btn btn-primary" OnClick="edit_Click" />
							<asp:Button ID="savebtn" runat="server" ValidationGroup="miss" Text="Save" class="btn btn-primary" OnClick="savebtn_Click" />
							<asp:Button ID="dlt" runat="server" ValidationGroup="miss" Text="Delete" class="btn btn-primary" OnClick="dlt_Click" />

							<br />
							<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
							<br />
						</div>

					</div>
					<br>
				</div>
			</div>
		</div>

		<br />
		<br />
		</div>
		<div class="container-fluid">
			<div class="row">
				<div class="col-md-8 mx-auto">
					<div class="card">
						<div class="card-body">
							<div class="row">
								<div class="col">
									<hr>
								</div>
							</div>
							<div class="row">
								<div class="col">
									<h4>Stock List</h4>
								</div>
							</div>


							<div class="row">
								<div class="col">
									<hr>
								</div>
							</div>
							<br />
							<div class="row">
								<div class="col-mx-auto">
									<asp:GridView runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-responsive" AutoGenerateSelectButton="True" OnSelectedIndexChanged="medlist_SelectedIndexChanged"
										 Width="100%" ID="medlist">
										
										<Columns>
											<asp:BoundField DataField="batch_id" HeaderText="Batch No" />
											<asp:BoundField DataField="stockindate" HeaderText="Stock IN Date " DataFormatString="{0:dd-MM-yyyy}" />
											<asp:BoundField DataField="med_id" HeaderText="Medicine ID" />
											<asp:BoundField DataField="med_name" HeaderText="Medicine Name" />
											<asp:BoundField DataField="stock" HeaderText="Stock" />
											<asp:BoundField DataField="price" HeaderText="Price" />
											<asp:BoundField DataField="cat_name" HeaderText="Category" />
											<asp:BoundField DataField="manufacture_date" HeaderText="Manf.Date" DataFormatString="{0:dd-MM-yyyy}" />
											<asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
										</Columns>
										<%--<EditRowStyle BorderColor="Black" />--%>
										
		
								<HeaderStyle  CssClass="table " Wrap="true"  HorizontalAlign="Center" VerticalAlign="Middle" Font-Names="Montserrat" Width="5" />
								<RowStyle  BorderStyle="Solid"  BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px" />
							
							
									</asp:GridView>
								</div>
								<br />
								<div class="row">
									<div class="col">
										<br />
										&nbsp&nbsp&nbsp
						    <asp:Button ID="print" runat="server" Text="Print" class="btn btn-primary" OnClientClick="printGridView()" />

										<br />
										<br />
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div></div>
</asp:Content>
