<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="projectpharmacy.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<link href="Content/StyleSheet1.css" rel="stylesheet" />
		<div class="loginbox">
			<h2> Admin Login</h2>

			<asp:Label ID="Label1" runat="server" Text="Username" CssClass="lblusername"  ></asp:Label><br>
       	    <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" CssClass="txtusername" Width="272" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Missing Username"  ValidationGroup="user"  ControlToValidate="TextBox1"  ForeColor="Red"></asp:RequiredFieldValidator>
			<br />
			<asp:Label ID="Label2" runat="server" Text="Password" CssClass="lblpass" EnableTheming="True"></asp:Label><br>
	        <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black"  CssClass="txtpass" TextMode="Password" Width="272"/>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="user" runat="server" ErrorMessage="Missing Password" ControlToValidate="TextBox2"  ForeColor="Red"></asp:RequiredFieldValidator>
			<br />
			
		    <asp:Button ID="Button1" ValidationGroup="user" runat="server" Text="Login" OnClick="Button1_Click" CssClass="btnsubmit" Width="272" />
		  <%--<asp:Button ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click" CssClass="btnsubmit" Width="120" />--%>
			<br />
			<asp:Button ID="Button3" runat="server" Text="Forgot" OnClick="Button3_Click" CssClass="btnsubmit" Width="272" />
		</div>		
</asp:Content>