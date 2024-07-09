<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="projectpharmacy.forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link href="Content/StyleSheet1.css" rel="stylesheet" />
	<div class="loginbox">
			<h2>Forgot</h2>
			<br />

			<asp:Label ID="Username" runat="server" Text="Username" CssClass="lblusername" ></asp:Label><br>
       	    <asp:TextBox ID="user1" runat="server" CssClass="txtusername" Width="272" ValidationGroup="user" /><br>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Missing Username"  ValidationGroup="user"  ControlToValidate="user1"  ForeColor="Red"></asp:RequiredFieldValidator>
				<br />
			
			<asp:Label ID="Email" runat="server" Text="Registered Email" CssClass="lblpass" ValidationGroup="user"></asp:Label><br>
	        
			<asp:TextBox ID="email1" runat="server" CssClass="txtpass" Width="272" ValidationGroup="user" TextMode="Email" />	
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Missing Email"  ValidationGroup="user"  ControlToValidate="email1"  ForeColor="Red"></asp:RequiredFieldValidator>
			    
		<asp:Button  ID="submit" runat="server"  ValidationGroup="user" Text="Send To Email" CssClass="btnsubmit" Width="272" OnClick="submit_Click" />
            <asp:Label ID="msg" runat="server" ForeColor="Black"></asp:Label>
		
	</div>		

</asp:Content>