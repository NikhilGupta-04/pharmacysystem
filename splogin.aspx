<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="splogin.aspx.cs" Inherits="projectpharmacy.splogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<%--<link href="Content/SiteLogin.css" rel="stylesheet" />--%>
	<link href="Content/StyleSheet1.css" rel="stylesheet"  />
		<div class="loginbox">
			<h2> Salesperson Login </h2>
			<asp:Label ID="Label1" runat="server" Text="Username" CssClass="lblusername" ></asp:Label><br>
       	    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtusername" Width="272" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="user" runat="server" ErrorMessage="Missing Username" ForeColor="red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
		    <br>
			<asp:Label ID="Label2" runat="server" Text="Password" ValidationGroup="user" CssClass="lblpass"></asp:Label><br>
	        <asp:TextBox ID="TextBox2"  runat="server" CssClass="txtpass" ValidationGroup="user" TextMode="Password" Width="272"/>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="user" ErrorMessage="Missing Password" ForeColor="red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
		    <asp:Button ID="Button1" runat="server" Text="Login" ValidationGroup="user" OnClick="Button1_Click" CssClass="btnsubmit" Width="272" /><br>
	        <asp:Button ID="Button2" runat="server" Text="Forgot" OnClick="Button2_Click" CssClass="btnsubmit" Width="272"  />

		</div>		
</asp:Content>