<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPermitDashboard.aspx.cs" Inherits="ExciseAPI.Admin.EventPermitDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Permits</div>
            <div class="content">
                <div id="Div1" class="page-body" runat="server">
                    <div class="row col-md-12">
                         <div class="container-fluid row text-center">
                            <div class="card">
                                <center>
                                    <h2 style="color: #de5b5b; font-family: calibri; font-weight: 600;">
                                        Today</h2>
                                </center>
                                <div class="row col-md-12">
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-pink">
                                            <div class="card-block">
                                                <h4>
                                                    <asp:Label ID="lblTodayCount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Events
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-yellow">
                                            <div class="card-block">
                                                <h4>
                                                    <asp:Label ID="lblTodayAmount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Amount
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <center>
                                    <h2 style="color: #de5b5b; font-family: calibri; font-weight: 600;">
                                        Total cumulative amount</h2>
                                </center>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-blue">
                                            <div class="card-block">
                                                <h4>
                                                    <asp:Label ID="lblTotalCount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Events
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-green">
                                            <div class="card-block">
                                                <h4>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Amount
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             </div>
                        </div>
                </div>
                <br />
                <br />
            </div>
            <div class="content">
                <center>
                    <b style="color: Red; font-size: 25px;">Event Permits</b>
                 </center>
               
                    <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                            <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        </div>
                    </div>
                   <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        </div>
                    </div>
               
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="GetDetails" runat="server" Text="Get Details " CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="GetDetails_Click" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>

            <div class="content" id="divEventsData" runat="server" visible="false">
                <div class="w-100 fl container-fluid">
                    <div class="block-liner block bg-white">
                        <div class="content">
                            <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                                <div class="w-100 fl m-b-2">
                                    <div class="fr">
                                        <a href="#">
                                            <asp:ImageButton runat="server" ID="btnDetailImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnDetailImageExportToPdf_Click"
                                                Visible="false" />
                                        </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnDetailImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnDetailImageExportToExcel_Click"
                                        Visible="false" /></a>
                                    </div>
                                </div>
                            </div>

                            <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="false">
                                <div class="block-liner block black bg-white">
                                    <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sales Proceed Detail Report
                                            <br />
                                            <br />
                                            Between :
                                            <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                            AND
                                            <asp:Label ID="lblToDate" runat="server"></asp:Label>
                                        </h2>
                                    </div>
                                    <div class="content">
                                        <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Amt" HeaderText="Event Fee" />
                                                <asp:BoundField DataField="Ecount" HeaderText="Paid Count" />
                                                <asp:BoundField DataField="amount" HeaderText="Total Amount" />
                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
