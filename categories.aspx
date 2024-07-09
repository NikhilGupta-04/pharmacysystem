<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="projectpharmacy.categories" %>

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
								<label>Category Name </label>
								<div class="form-group">
									<asp:TextBox ID="catname_tb" type="text" runat="server" placeholder="Category Name" CssClass="form-control"  OnTextChanged="catname_tb_TextChanged"  AutoPostBack="true" ></asp:TextBox>								
								</div>
							</div>


						</div>

						<div class="row">
							<div class="col">
								<br />

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

								<center>	<h4>Category List</h4></center>

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
									<asp:GridView ID="GridView1" CssClass="table table-bordered table-responsive" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" Height="178px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="358px" HorizontalAlign="Left">
										<Columns>
											<asp:BoundField DataField="cat_id" HeaderText="Category ID" />
											<asp:BoundField DataField="cat_name" HeaderText="Category Name" />
										</Columns>

										<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
										<RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
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
