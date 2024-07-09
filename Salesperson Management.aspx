<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master"  AutoEventWireup="true"  CodeBehind="Salesperson Management.aspx.cs" Inherits="projectpharmacy.Salesperson_Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mybody" runat="server">
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
                                    <center><h4>Salesperson Login Management</h4></center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                <hr>
                                </div>
                            </div>
						<div class="col-md-4">
                           <asp:Button ID="add" runat="server"  OnClick="add_Click" Text="Add Salesperson" CssClass="form-control" BackColor="#339933" ForeColor="White"/>
                        </div>
        			 <div class="col-md-4 mx-auto">
                                    <div class="form-group">
                                        <asp:Button ID="showdata" runat="server" BackColor="#339933" CssClass="form-control"  ForeColor="White" OnClick="showdata_Click" Text="Show" Width="100%" />
                                    </div>
                           </div>
						<asp:Panel ID="Panel1" runat="server">
                        <div class="row">
                            <div class="col-md-5 mx-auto">
                                <label>Salesperson Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="spname" runat="server"  />
                                    </div>
                             </div>
                             <div class="col-md-5  mx-auto">
                                 <label>Username </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="uname" runat="server" AutoPostBack="true" OnTextChanged="uname_TextChanged"/>
                                    </div>
                           </div>
                        </div>
						 <div class="row">
                            <div class="col-md-5 mx-auto">
                                <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="pass" TextMode="Password" runat="server"   />
                                    </div>
                             </div>
                             <div class="col-md-5  mx-auto">
                                 <label>Mobile Number </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="mno" TextMode="Phone" MaxLength="10" runat="server" />
                                    </div>
                           </div>
                        </div>
						 <div class="row">
                            <div class="col-md-5 mx-auto">
                                <label>Email ID</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="email" runat="server" OnTextChanged="email_TextChanged"  TextMode="Email" AutoPostBack="true"/>
                                    </div>
                             </div>
                           
                        </div>
							 
                  
                    <br />
					 <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                       <asp:Button ID="save" runat="server"  OnClick="save_Click" CssClass="form-control" Text="Save"  BackColor="#339933" ForeColor="White" Width="100%"/>
                                    </div>
                             </div>
						 </asp:Panel>
                            
						 </div>							  </div>
                        
						
				
            
        			
                    <br />
                    <br />
					<asp:Panel ID="Panel3" runat="server">
						<asp:GridView ID="GridView1" CssClass="table table-bordered table-responsive" runat="server"  Width="100%" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
							<Columns>
								<asp:BoundField DataField="name" HeaderText="Name" />
								<asp:BoundField DataField="user_id" HeaderText="User ID" />
								<asp:BoundField DataField="pass" HeaderText="Pass" />
								<asp:BoundField DataField="email" HeaderText="Email" />
								<asp:ButtonField ButtonType="Button" CommandName="delete" Text="Delete" />
							</Columns>
						</asp:GridView>

						</asp:Panel>
                    
                   </div>
                   
                </div>
            </div>
        </div>
    </div>
</div>
    
</asp:Content>
