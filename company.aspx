<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="projectpharmacy.company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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

							<center><h4>Add Category</h4></center>

							</div>

						</div>

						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>

						<div class="row">
							<div class="col-md-4">
								<label>Company Name </label>
								<div class="form-group">
									<asp:TextBox ID="company_name"  CssClass="form-control" type="text" AutoPostBack="true" runat="server" placeholder="Company Name"  OnTextChanged="company_name_TextChanged"></asp:TextBox>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Missing Company Name" ForeColor="Red" ControlToValidate="company_name"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>
							<div class="col-md-4">
								<label>Company Contact Person Name </label>
								<div class="form-group">
									<asp:TextBox ID="contact_person" CssClass="form-control" type="text" TextMode="Phone" runat="server" placeholder="Contact Person Name" Height="45px"></asp:TextBox>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="Missing contact person" ForeColor="Red" ControlToValidate="contact_person"></asp:RequiredFieldValidator>--%>
		    
								</div>
							</div>
							<div class="col-md-4">
								<label>Mobile Number</label>
								<div class="form-group">
									<asp:TextBox ID="contact" CssClass="form-control" type="text" runat="server" placeholder="Contact Person Number"></asp:TextBox>
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Missing Number" ForeColor="Red" ControlToValidate="contact"></asp:RequiredFieldValidator>--%>
									<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="miss" runat="server" ErrorMessage="Invalid Mobile Number" ValidateRequestMode="Inherit" ControlToValidate="contact" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$"></asp:RegularExpressionValidator>--%>
								</div>
							</div>




						</div>

						<div class="row">
							<div class="col">
								<br />

								<asp:Button ID="edit"  runat="server" Text="Edit" class="btn btn-primary" OnClick="edit_Click" />
								<asp:Button ID="savebtn" runat="server" Text="Save" class="btn btn-primary" OnClick="savebtn_Click" />
								<asp:Button ID="dlt" runat="server"  Text="Delete" class="btn btn-primary" OnClick="dlt_Click" />
								<br />
								<br />
							</div>
						</div>
					</div>
					<br>
				</div>
			</div>
		</div>
		<br />
		<br />

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

								<center><h4>Company List</h4></center>

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
									<asp:GridView ID="mcomlist"  CssClass="table table-bordered table-responsive" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="mcomlist_SelectedIndexChanged">
										<Columns>
											<asp:BoundField HeaderText="Company ID" ReadOnly="True" DataField="company_id" />
											<asp:BoundField DataField="company_name" HeaderText="Company Name" />
											<asp:BoundField DataField="contact_person" HeaderText="Contact Person" />
											<asp:BoundField DataField="contact" HeaderText="Contact" />
										</Columns>
										<EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
										<RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
										<HeaderStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
									</asp:GridView>

								</div>
							</div>



						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

</asp:Content>

