<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="invoicelist.aspx.cs" Inherits="projectpharmacy.invoicelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="bottstrpourcsss.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mybody" runat="server">


	<div class="container-fluid">
		<div class="row">
			<div class="col-md-6 mx-auto">
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

								<center><h4>Invoices</h4></center>

							</div>

						</div>

						<div class="row">
							<div class="col-md-4">
								<label>From Date</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" type="date" ID="fromdate" runat="server" placeholder="Select"></asp:TextBox>
								</div>
							</div>
							<div class="col-md-4">
								<label>To Date</label><br>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" type="date" ID="todate" runat="server" placeholder="Select"></asp:TextBox>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-4">
								<asp:Button ID="show" runat="server" Text="Button" OnClick="show_Click" />

								<br />

							</div>
						</div>
						<asp:GridView ID="inlist" runat="server " AutoGenerateColumns="False" Width="700px"  CssClass="table table-bordered table-responsive" OnRowCommand="invoicelist_RowCommand">
							<Columns>
								<asp:BoundField DataField="invoiceno" HeaderText="Invoice No" />
								<asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" />
								<asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
								<asp:BoundField DataField="customer_mobile_no" HeaderText="Mobile no" />
								<asp:BoundField DataField="total_amount" HeaderText="Amount" />
								<asp:ButtonField ButtonType="Image" CommandName="print" HeaderText="Action" ImageUrl="~/images/print.jpg">
									<ControlStyle Height="20px" Width="20px" />
								</asp:ButtonField>
							</Columns>
						</asp:GridView>

					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
