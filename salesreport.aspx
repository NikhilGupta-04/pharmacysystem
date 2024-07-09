<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="salesreport.aspx.cs" Inherits="projectpharmacy.salesreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function printGridView() {
			var gridview = document.getElementById('<%= Panel1.ClientID %>');
			var windowPrint = window.open('', '', 'height=500,width=800');
			windowPrint.document.write('<html><style type="text/css"></style><body><h1><center>Sales Report</center></h1><h3><center>Medix Pharama Solutions <br>Contact No 9325215926</center></h1>');
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
                            
                                <center> <h5 style="font-family:'Times New Roman'">Select a Date of which Salesreport You want to Display </h5></center>
							<div class="col-md-3 mx-auto">
                                    <label>From </label>   
								<div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="fromdate" runat="server" TextMode="Date"  />
                                    </div>
                             </div>
                             <div class="col-md-3  mx-auto">
                                 <label>To </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="todate"  ReadOnly="true" runat="server" TextMode="Date" />
                                    </div>
                           </div>
                        </div>
					

                    </div>
                    <br />
					<div class="row">
							<center>
                        <div class="col-md-4">
                            <asp:Button ID="show" runat="server"  OnClick="show_Click"  Text="Show" CssClass="form-control" BackColor="#339933"  ForeColor="White"/>

                        </div>
                         <br />
                         <asp:Panel ID="Panel2" runat="server">
                            <div class="col-md-4">
                                <asp:Button ID="print" runat="server" CssClass="form-control" Text="Print" BackColor="#339933"   OnClientClick="printGridView()" ForeColor="White"/>
                            </div>
                         </asp:Panel>
                        </center>
						</div>
                 <%--   <center>
                        <div class="col-md-4">
                           <asp:Button ID="show" runat="server" OnClick="show_Click" Text="Show" CssClass="form-control" BackColor="#339933" ForeColor="White"/>
                        </div>
                     </center>--%>
                    <br />
                    <br />

                    <asp:Panel ID="Panel1" runat="server">
                      <asp:GridView ID="invoicelist" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="False"  OnRowCommand="invoicelist_RowCommand" Width="100%">
		<Columns>
			<asp:BoundField DataField="invoiceno" HeaderText="Invoice No" />
			<asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" DataFormatString="{0:dd-MM-yyyy}" />
			<asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
			<asp:BoundField DataField="customer_mobile_no" HeaderText="Mobile no" />
			<asp:BoundField DataField="total_amount" HeaderText="Amount" />
			<asp:BoundField DataField="name" HeaderText="By Salesperson" />
		
			<asp:ButtonField ButtonType="Image" CommandName="print" HeaderText="Action" ImageUrl="~/images/print.jpg">
			<ControlStyle Height="20px" Width="20px" />

			</asp:ButtonField>
		</Columns><EditRowStyle BorderStyle="Solid" Height="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
								<EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
								<HeaderStyle  HorizontalAlign="Center" VerticalAlign="Top" />
								<RowStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:GridView>
						<br />
						<div class="row">
                            <div class="col-md-3 mx-auto">
                              Total Sales
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"  ReadOnly="true" TextMode="Number"  />
                                    </div>
                             </div>
							</div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</div>
    
</asp:Content>
