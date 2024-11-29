<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ExciseAPI.NICAdmin.AdminDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Content/chart.js"></script>
    <script src="/Content/jquery-3.6.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>

                    </div>
                </div>
                <asp:Button ID="btnGenerate" runat="server" Text="Generate Charts" OnClick="btnGenerate_Click" />

                <%-- <asp:Chart ID="barChart" runat="server" Width="600px" Height="400px"></asp:Chart>
                <asp:Chart ID="pieChart" runat="server" Width="600px" Height="400px"></asp:Chart>--%>

                <asp:Chart ID="barChart" runat="server" Width="600px" Height="400px" Visible="false">
                    <Series>
                        <asp:Series Name="Category" ChartType="Bar"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="Value"></asp:ChartArea>

                    </ChartAreas>
                </asp:Chart>
            </div>
            <div>
                <asp:Chart ID="Chart1" runat="server" Width="600px" Height="400px" Visible="false">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
