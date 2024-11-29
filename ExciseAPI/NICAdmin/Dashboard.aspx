<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExciseAPI.NICAdmin.Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Scripts/css/dashboard1.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <div class="container" id="maindiv">
        <!-- Factory Details Section -->
        <div class="section-title">
            <label>Manufacturer Details</label>
        </div>
        <div class="cards-container" id="card_cont" runat="server">
            <div class="dashboard-card" id="card1">
                <p class="card-title">Primary Distillery</p>
                <asp:Button ID="btnPrimaryDistillery" CssClass="primerybtn" runat="server" Text="Submit" autopostback="true" OnClick="btnPrimaryDistillery_Click" CommandArgument="1" Width="70" Font-Size="Medium" BackColor="transparent" BorderStyle="None" Style="margin-top: -12%; color: white" />
            </div>
            <div class="dashboard-card" id="card2">
                <p class="card-title">Distillery</p>
                <asp:Button ID="btnDistillery" CssClass="primerybtn" runat="server" Text="Submit" autopostback="true" OnClick="btnDistillery_Click" CommandArgument="2" Width="70" Font-Size="Medium" BackColor="transparent" BorderStyle="None" Style="margin-top: -12%; color: white" />
            </div>
            <div class="dashboard-card" id="card3">
                <p class="card-title">Brewery</p>
                <asp:Button ID="btnBrewery" CssClass="primerybtn" runat="server" Text="Submit" autopostback="true" OnClick="btnBrewery_Click" CommandArgument="3" Width="70" Font-Size="Medium" BackColor="transparent" BorderStyle="None" Style="margin-top: -12%; color: white" />
            </div>
            <div class="dashboard-card" id="card4">
                <p class="card-title">Winery</p>
                <asp:Button ID="btnWinery" CssClass="primerybtn" runat="server" Text="Submit" autopostback="true" OnClick="btnWinery_Click" CommandArgument="4" Width="70" Font-Size="Medium" BackColor="transparent" BorderStyle="None" Style="margin-top: -12%; color: white" />
            </div>
            <div class="dashboard-card" id="card5">
                <p class="card-title">Micro Brewery</p>
                <asp:Button ID="btnMicroBrewery" CssClass="primerybtn" runat="server" Text="Submit" autopostback="true" OnClick="btnMicroBrewery_Click" CommandArgument="5" Width="70" Font-Size="Medium" BackColor="transparent" BorderStyle="None" Style="margin-top: -12%; color: white" />
            </div>
        </div>








        <!-- Retailer Details Section -->
        <%--<div class="section-title">
        <label>Retailer Details</label>
    </div>
    <div class="cards-container">
        <div class="dashboard-card" id="card_1">
            <p class="card-title">Primary Distillery</p>
            <label class="card-value" id="Label1" runat="server"></label>
        </div>
        <div class="dashboard-card" id="card_2">
            <p class="card-title">Distillery</p>
            <label class="card-value" id="Label2" runat="server"></label>
        </div>
        <div class="dashboard-card" id="card_3">
            <p class="card-title">Brewery</p>
            <label class="card-value">0</label>
        </div>
        <div class="dashboard-card" id="card_4">
            <p class="card-title">Winery</p>
            <label class="card-value">0</label>
        </div>
        <div class="dashboard-card" id="card_5">
            <p class="card-title">Micro Brewery</p>
            <label class="card-value">0</label>
        </div>
        <div class="dashboard-card" id="card_6">
            <p class="card-title">Micro Brewery</p>
            <label class="card-value">0</label>
        </div>
        <div class="dashboard-card" id="card_7">
            <p class="card-title">Micro Brewery</p>
            <label class="card-value">0</label>
        </div>
    </div>--%>
    </div>


    <div class="table-container-wrapper" id="divtable">
        <div id="statusTable" class="table-container" runat="server"  style="display: none;">
            <h3>Supplier Details</h3>
              <asp:Button ID="close"  runat="server" Text="Close" OnClick="btnclose_Click" class="close-btn" />
            <div class="table-scroll-container" style="margin-top:1%;">
                <table class="status-table">
                    <thead>
                        <tr>
                            <th>DistName</th>
                            <th>Supplier Name</th>
                            <th>Address</th>
                            <th>Mobile</th>
                            <th>License No.</th>
                        </tr>
                    </thead>
                    <tbody id="tblSupplierdataList" runat="server"></tbody>
                </table>
            </div>
           
        </div>
    </div>
</asp:Content>



