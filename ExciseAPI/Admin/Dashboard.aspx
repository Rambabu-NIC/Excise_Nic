<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExciseAPI.Admin.Dashboard" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div id="Div1" class="page-body" runat="server" >
                    <div class="row text-center">
                          <div class="container-fluid row text-center">
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="card">
                                <center><h2  style="color:#de5b5b;font-family: calibri;font-weight: 600;">Today</h2></center>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-pink" style="background-color:lavender;">
                                            <div class="card-block">
                                                <i class="feather icon-user bg-simple-c-pink card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="TotTodaytrns" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Transations
                                                </p>
                                                <%--  <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-yellow" style="background-color:lightgreen;">
                                            <div class="card-block">
                                                <i class="feather icon-life-buoy bg-simple-c-yellow card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="TotTamt" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Amount
                                                </p>
                                                <%-- <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="card">
                                <center><h2 style="color:#de5b5b;font-family: calibri;font-weight: 600;">Total cumulative amount</h2></center>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-blue" style="background-color:lightgray;">
                                            <div class="card-block">
                                                <i class="feather icon-user bg-simple-c-blue card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="TotTrns" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">Total Transations</p>
                                                <%--  <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-green" style="background-color:lightblue;">
                                            <div class="card-block">
                                                <i class="feather icon-home bg-simple-c-green card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="TotAmt" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Amount
                                                </p>
                                                <%-- <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        </div>
                    <%--<div class="card">
                                            <div class="col-xl-12 col-md-12">
                                            </div>
                                        </div>--%>


                    <div class="row" runat="server" id="pannelOK">
                        <div class="col-md-12 text-center">
                            <div class="col-sm-12 text-center">
                                <rsweb:reportviewer id="ReptReg" width="100%" height="100%" runat="server" sizetoreportcontent="true">
                                                    </rsweb:reportviewer>
                            </div>
                        </div>
                    </div>
                    <%--   <div class="col-md-12 text-right">
                                         <asp:Button ID="imgbtnExcel"  Text="Download Excel"
                                                 
                                                    runat="server" onclick="imgbtnExcel_Click1" />
                                        </div>--%>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
