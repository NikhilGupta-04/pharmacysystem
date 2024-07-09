<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="medicines.aspx.cs" Inherits="projectpharmacy.medicines" %>

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

						<center><h4>Add New Medicine</h4></center>

							</div>

						</div>

						<div class="row">
							<div class="col">
								<hr>
							</div>
						</div>

						<div class="row">
							<div class="col-md-4">
								<label>Medicine ID</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="m_id" runat="server"  AutoPostBack="true" placeholder="Medicine ID" OnTextChanged="m_id_TextChanged"></asp:TextBox>
								</div>
							</div>
							<div class="col-md-4">
								<label>Medicine Name</label><br>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="m_name" runat="server"  AutoPostBack="true" OnTextChanged="m_name_TextChanged" placeholder="Medicine Name"></asp:TextBox>
								</div>
							</div>

						</div>
						<br />
						<div class="row">
							<div class="col-md-4">
								<label>Medicine Company</label>

								<asp:DropDownList ID="mcom" runat="server" CssClass="form-control" placeholder="Medicine Category">
								</asp:DropDownList>
							</div>



							<div class="col-md-4">
								<label>Medicine Category</label>
								<asp:DropDownList ID="m_cat" runat="server" CssClass="form-control" placeholder="Medicine Category">
								</asp:DropDownList>
								<div class="form-group">
								</div>
							</div>
						</div>
					</div>

					<div class="row">
						<div class="col">
							<br />
							&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
									<asp:Button ID="edit" runat="server" Text="Edit" class="btn btn-primary" OnClick="edit_Click" />
							<asp:Button ID="savebtn" runat="server" Text="Save" class="btn btn-primary" OnClick="savebtn_Click" />
							<asp:Button ID="dlt" runat="server" Text="Delete" class="btn btn-primary" OnClick="dlt_Click" />
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
								<center>
                               <h4>Medicine Lists</h4>
                           </center>
							</div>
							
						</div>
						<hr>
					</div>

					<div class="row">
						<div class="col">
							
						</div>
					</div>
					<div class="row">
						<div class="col-mx-auto">
							<asp:GridView runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="False" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="medlist_SelectedIndexChanged" ID="medlist">
								<Columns>

									<asp:BoundField DataField="med_id" HeaderText="Medicine ID" ReadOnly="True" />
									<asp:BoundField DataField="med_name" HeaderText="Medicine Name " />
									<asp:BoundField DataField="cat_name" HeaderText="Medicine Category" />
									<asp:BoundField DataField="company_name" HeaderText="Medicine company" />


								</Columns>

								<EditRowStyle BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />

								<HeaderStyle BorderStyle="Solid" />

							</asp:GridView>
							<hr>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

</asp:Content>
