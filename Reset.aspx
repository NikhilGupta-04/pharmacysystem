<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="projectpharmacy.Reset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"   >
<link rel="stylesheet" href="Content/style1.css" />
	
		<div class="loginbox">
			<h2> Reset </h2>
			<br />

			<asp:Label ID="Label1" runat="server" Text="Email" CssClass="lblusername" ></asp:Label><br>
       	    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtusername" Width="272" /><br>
				
			<asp:Label ID="Label2" runat="server" Text="Create a New Password " CssClass="lblpass"></asp:Label><br>
	        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtpass" Width="272"/><br>
				
		  
				
	        <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" CssClass="btnsubmit" Width="272" />
		
            <asp:Label ID="Label3" runat="server"></asp:Label>
		
		</div>		




	

</asp:Content>
