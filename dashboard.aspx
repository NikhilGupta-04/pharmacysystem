<%@ Page Title="" Language="C#" MasterPageFile="~/adminmodule.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="projectpharmacy.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/sidebar222.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mybody" runat="server">
    

	      <main>
        <div class="main__container">
          <!-- MAIN TITLE STARTS HERE -->

          <div class="main__title">
            <img src="assets/hello.svg" alt="" />
            <div class="main__greeting">
              <h1>Admin Module</h1>
              <p>Welcome to your admin dashboard</p>
            </div>
          </div>

          <!-- MAIN TITLE ENDS HERE -->

          <!-- MAIN CARDS STARTS HERE -->
          <div class="main__cards">
            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Medicines</p>
                <asp:Label ID="medicine" runat="server" Text=""></asp:Label>
              </div>
            </div>

            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Category</p>
                <asp:Label ID="cat" runat="server" Text=""></asp:Label>
              </div>
            </div>

            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Company</p>
                <asp:Label ID="comp" runat="server" Text=""></asp:Label>
              </div>
            </div>

            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Invoices</p>
                  <asp:Label ID="invoices" runat="server" Text=""></asp:Label>
              </div>
            </div>
          </div>

            <div class="main__cards">
            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Salespersons</p>
                <asp:Label ID="total_salesperson" runat="server" Text=""></asp:Label>
              </div>
            </div>

            
            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Expired Batches</p>
                <asp:Label ID="totalexp" runat="server" Text=""></asp:Label>
              </div>
            </div>

                
            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Out of stock batches</p>
                <asp:Label ID="totaloutofstock" runat="server" Text=""></asp:Label>
              </div>
            </div>

                      
            <div class="card">
              <div class="card_inner">
                <p class="text-primary-p">Total Sales</p>
                <asp:Label ID="totalsales" runat="server" Text=""></asp:Label>
              </div>
            </div>
            </div>

          <!-- MAIN CARDS ENDS HERE -->

          </div>
      </main>
 <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
    <script src="script.js"></script>
 
</asp:Content>
