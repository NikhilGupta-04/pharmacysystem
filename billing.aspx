<%@ Page Title="" Language="C#" MasterPageFile="~/spmodule.Master" AutoEventWireup="true" CodeBehind="billing.aspx.cs" Inherits="projectpharmacy.billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="Content/bodybill.css" rel="stylesheet" />
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container-fluid">
		<div class="row">
			<div class="col-md-10 mx-auto">
				<div class="card">
					<div class="card-body">
						<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
						<asp:UpdatePanel ID="UpdatePanel1" runat="server">
							<ContentTemplate>
								<div class="row">
									<div class="col">
										<hr>
									</div>
								</div>
								<div class="row">
									<div class="col">
										<center><h4>Billing System </h4></center>
									</div>
								</div>
								<div class="row">
									<div class="col">
										<hr>
									</div>
								</div>

								<div class="row">
									<div class="col-md-3">
										<label>Invoice Number</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" ID="invoice_id" runat="server" placeholder="Invoice Number" ReadOnly="True" />
										</div>
									</div>
									<div class="col-md-3">
										<label>Invoice Date</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" ID="invoice_date" placeholder="" runat="server" TextMode="Date" ReadOnly="True"/>
										</div>
									</div>
									<div class="col-md-3">
										<label>Product Details</label>
										<div>
											<asp:DropDownList ID="mlist" runat="server" AutoPostBack="True" CausesValidation="true" CssClass="form-control"  OnSelectedIndexChanged="mlist_SelectedIndexChanged" placeholder="Medicine Company">
												<asp:ListItem>select</asp:ListItem>
											</asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="missing" ErrorMessage="select Product" ForeColor="Red" ControlToValidate="mlist"></asp:RequiredFieldValidator>
								
										</div>
									</div>
									<div class="col-md-3">
										<label>Batch No</label>
										<div>
											<asp:DropDownList ID="batchlist" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="form-control" OnSelectedIndexChanged="batchlist_SelectedIndexChanged" >
												<asp:ListItem>select</asp:ListItem>
											</asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="missing" ErrorMessage="select batch" ForeColor="Red" ControlToValidate="batchlist"></asp:RequiredFieldValidator>
								
										</div>
									</div>
								</div>
								<br />
								<div class="row">
									<div class="col-md-3">
										<label>Unit Price</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" AutoPostBack="true"  ID="ut" runat="server" placeholder="Unit Price" ReadOnly="True"/>
		    
										</div>

									</div>
									<div class="col-md-3">
										<label>Current Stock</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" ID="st"  AutoPostBack="true" placeholder="stock" runat="server" ReadOnly="True"/>
										</div>
									</div>
									<div class="col-md-3">
										<label>Add Quantity</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" ID="qt" AutoPostBack="True" runat="server" OnTextChanged="quantity_TextChanged" placeholder="Quantity" />
										<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="missing" ErrorMessage="Missing quantity" ForeColor="Red" ControlToValidate="qt"></asp:RequiredFieldValidator>
										
										</div>
									</div>
									<div class="col-md-3">
										<label>Subtotal</label>
										<div class="form-group">
											<asp:TextBox CssClass="form-control" ID="stotal" AutoPostBack="true" OnTextChanged="stotal_TextChanged" placeholder="Subtotal" runat="server" />
										</div>
									</div>
								</div>
									</ContentTemplate>
						</asp:UpdatePanel>
								<br />
								<center>
                                <div class="col-md-4">
                                    <asp:Button ID="addtocart" ValidationGroup="missing" runat="server"  Text="Add Item" CssClass="form-control" BackColor="#339933" ForeColor="White" OnClick="addtocart_Click"/>
                                </div>
                            </center>
						
					</div>
				</div>
			</div>
		</div>
	</div>

	<br />
	<br />
	<asp:Panel ID="Panel1" runat="server">
		<div class="container-fluid">
			<div class="row">
				<div class="col-md-10 mx-auto">
					<div class="card">
						<div class="card-body">
							<asp:GridView ID="cart" runat="server" AutoGenerateColumns="False"   CssClass="table table-bordered table-responsive"  Width="100%" OnRowCommand="cart_RowCommand" OnRowDeleting="cart_RowDeleting">
								<Columns>
									<asp:BoundField DataField="med_name" HeaderText="Medicine Name" />
									<asp:BoundField DataField="batchid" HeaderText="Batch ID" />
									<asp:BoundField DataField="quantity" HeaderText="Quantity" />
									<asp:BoundField DataField="med_price" HeaderText="Medicine Price" />
									<asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Action" ShowHeader="True" Text="Delete" />
								</Columns>
								<EditRowStyle BorderStyle="Solid" Height="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
								<EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
								<HeaderStyle  HorizontalAlign="Center" VerticalAlign="Top" />
								<RowStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:GridView>
						</div>
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>

	<br />
	<br />

	<div class="container-fluid">
		<div class="row">
			<div class="col-md-10 mx-auto">
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="row">
								<div class="col">
									<hr>
								</div>
							</div>
							<div class="col-md-3 mx-auto">
								<label>Total Amount</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="pricetotal"  runat="server" placeholder="Total Amounnt" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="miss" ErrorMessage="Missing Total Amount" ForeColor="Red" ControlToValidate="pricetotal"></asp:RequiredFieldValidator>
								
								</div>
							</div>
							
							<div class="col-md-3 mx-auto">
								<label>Customer Name</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control"  ID="m_custname" runat="server" placeholder="Name" />
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="miss" ErrorMessage="Missing Customer Name" ForeColor="Red" ControlToValidate="m_custname"></asp:RequiredFieldValidator>
								
								</div>
							</div>
							<div class="col-md-3 mx-auto">
								<label>Customer Mobile No</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="custno2" TextMode="Phone" runat="server" placeholder="Mobile No" MaxLength="10" />
									<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="miss" ErrorMessage="Missing Customer Mobile Number" ForeColor="Red" ControlToValidate="custno2"></asp:RequiredFieldValidator>
								
								</div>
							</div>
							<div class="col-md-3 mx-auto">
								<label>Email</label>
								<div class="form-group">
									<asp:TextBox CssClass="form-control" ID="email"  TextMode="Email"  runat="server"  placeholder="Email" />
									<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="miss" ErrorMessage="Missing Email" ForeColor="Red" ControlToValidate="custno2"></asp:RequiredFieldValidator>																
							<br />
							<br />
						</div>
								</div>
						<br />
						<div class="row">
							<center>
                        <div class="col-md-4">
                            <asp:Button ID="payment" ValidationGroup="miss" runat="server" CssClass="form-control" Text="Payment Collected" BackColor="#339933"  OnClick="payment_Click"  ForeColor="White"/>
                        </div>
                         <br />
                         <asp:Panel ID="Panel2" runat="server">
                            <div class="col-md-4">
                                <asp:Button ID="invoice" runat="server" CssClass="form-control" Text="Invoice" BackColor="#339933"  OnClick="invoice_Click" ForeColor="White"/>
                            </div>
                         </asp:Panel>
                        </center>
						</div>
						<br />
					</div>

				</div>
			</div>
		</div>
	</div>
</asp:Content>
