<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="expiring medicine.aspx.cs" Inherits="projectpharmacy.expiring_medicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="Content/adminaddprod.css" rel="stylesheet" />
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

							<center><h4>Expired Product</h4></center>


							</div>

						</div>
						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>

						<br>
						<div class="row">
							<div class="col">
								<asp:GridView ID="expiry" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="False" OnRowCommand="expiry_RowCommand" OnSelectedIndexChanged="expiry_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="batch_id" HeaderText="Batch ID" />
										<asp:BoundField DataField="med_name" HeaderText="Medicine Name" />
										<asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
										<asp:BoundField DataField="stock" HeaderText="Stock" />
										<asp:ButtonField HeaderText="Action" CommandName="return" ButtonType="Image" ImageUrl="~/images/delete.png">
											<ControlStyle Height="20px" Width="20px" />

										</asp:ButtonField>
									</Columns>
								</asp:GridView>
								<br />
								<br />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

</asp:Content>

