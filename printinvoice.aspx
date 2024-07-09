<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printinvoice.aspx.cs" Inherits="projectpharmacy.printinvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		.auto-style1 {
			width: 100%;
			height: 407px;
		}
		.auto-style2 {
			height: 60px;
			width: 816px;
		}
		.auto-style3 {
			height: 75px;
			width: 816px;
		}
		.auto-style4 {
			height: 84px;
			width: 816px;
		}
		.auto-style5 {
			height: 57px;
			width: 816px;
		}
		.auto-style6 {
			height: 67px;
			width: 816px;
		}
		.auto-style7 {
			width: 113%;
			height: 25px;
		}
		.auto-style8 {
			height: 73px;
			width: 341px;
		}
		.auto-style10 {
			height: 23px;
			width: 816px;
		}
		.auto-style11 {
			height: 73px;
			width: 465px;
		}
	</style>

</head>
	<script type="text/javascript">
		function printGridView() {
			var gridview = document.getElementById('<%= Panel1.ClientID %>');
			var windowPrint = window.open('', '', 'height=500,width=800');
			
			windowPrint.document.write(gridview.outerHTML);
			windowPrint.document.write('</body></html>');
			windowPrint.document.close();
			windowPrint.print(); 
		}
	</script>
<body>
    <form id="form1" runat="server">
        <div>

        	<asp:Panel ID="Panel1" runat="server" Width="704px">
				<table class="auto-style1" aria-multiline="False" border="1">
					<tr>
						<td class="auto-style2"><h1></h1>
							<center>
								<h1>E-Invoice</h1></center>
							
							<h3>
								<center>
									Medix Pharama Solutions
									<br>Contact No 9325215926</br>
								</center>
								<h1></h1>
							</h3>
						</td>
					</tr>
					<tr>
						<td class="auto-style3">Invoice No :
							<asp:Label ID="inoiceno" runat="server" Text="Label"></asp:Label>
							<br />
							<br />
							 InvoiceDate :<asp:Label ID="invoicedate" runat="server" Text="Label"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="auto-style4">
							<table class="auto-style7">
								<tr>
									<td class="auto-style11">From
										<br />
										Medix Pharama<br /> Ulhasnagar -421004<br /> 9325215926 </td>
									<td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To,<br />
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Label ID="custname" runat="server" Text="Label"></asp:Label>
										<br />
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Label ID="custmob" runat="server" Text="Label"></asp:Label>
										<br />
										<br />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="auto-style5">
						
							<asp:GridView ID="GridView1" runat="server" Width="692px" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundField DataField="med_id" HeaderText="Medicine Id" />
									<asp:BoundField DataField="med_name" HeaderText="Medicine Name" />
									<asp:BoundField DataField="quantity" HeaderText="Quantity" />
									<asp:BoundField DataField="med_price" HeaderText="Price " />
								</Columns>
							</asp:GridView>
						</td>
					</tr>
					<tr>
						<td class="auto-style6">Grand Total :
							<asp:Label ID="total" runat="server" Text="Label"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="auto-style10">Declaration : We decleare that this invoice shows actual price of the goods described inclusive of taxes and that all particulars are true and correct
							<br />
							No Return will takes place
							<br />
							<br />
							THIS IS COMPUTER GENERATED INVOICE AND DOES NOT REQUIRED A SIGNATURE </td>
					</tr>
				</table>
			</asp:Panel>

        </div>
		                     <asp:Button ID="save" runat="server" OnClientClick="printGridView()" Height="40px" Text="Print/Save"  />
                    &nbsp;&nbsp;
                    <asp:Button ID="Back" runat="server"  OnClick="backtobilling_Click" Height="40px" Text="Back"/>    </form>
</body>
</html>
