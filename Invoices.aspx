<%@ Page Title="" Language="C#" MasterPageFile="~/spmodule.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="projectpharmacy.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<%--<link href="bottstrpourcsss.css" rel="stylesheet" />--%>
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container-fluid">
    <div class="row">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
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
                                <div class="col">
                                <hr>
                                </div>
                            </div>

                        <div class="row">
                           
                              <center> <h5 style="font-family:'Times New Roman'">Select a Date of which Invoices You want to Display </h5></center>
                             <div class="col-md-3 mx-auto">  
				             <label>From </label>
							<div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="fromdate" runat="server" TextMode="Date"  />
                                    </div>
                             </div>
							
                             <div class="col-md-3 mx-auto">
                                 <label>To </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="todate" runat="server" TextMode="Date"/>
                                    </div>
                           </div>
                        </div>

                    </div>
                    <br />
                    <center>
                        <div class="col-md-4">
                           <asp:Button ID="show" runat="server" OnClick="show_Click" Text="Show" CssClass="form-control" BackColor="#339933" ForeColor="White"/>
                        </div>
                     </center>
                    <br />
                    <br />

                    <asp:Panel ID="Panel1" runat="server">
                      <asp:GridView ID="invoicelist" width="100%"  CssClass="table table-bordered table-responsive" runat="server" AutoGenerateColumns="False" OnRowCommand="invoicelist_RowCommand">
		<Columns>
			<asp:BoundField DataField="invoiceno" HeaderText="Invoice No"  />
			<asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" DataFormatString="{0:dd-MM-yyyy}"/>
			<asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
			<asp:BoundField DataField="customer_mobile_no" HeaderText="Mobile no" />
			<asp:BoundField DataField="total_amount" HeaderText="Amount" />
			<asp:ButtonField ButtonType="Image" CommandName="print" HeaderText="Action" ImageUrl="~/images/print.jpg">
			
				<ControlStyle Height="20px" Width="20px" />

			</asp:ButtonField>
		</Columns><EditRowStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
								<EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
								<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
								<RowStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</div>
    
</asp:Content>
