<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="DashboardInfo.aspx.cs" Inherits="ExciseAPI.DashboardInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">DashBoard</div>
            <div class="content">
                <div class="row col-md-12 col-lg-12">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-5 col-sm-6 col-md-5 col-lg-5">From Date(yyyy-mm-dd)</label>
                        <div class="col-xs-7 col-sm-6 col-md-7 col-lg-7">
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
                </div>
                <div class="form-group col-xs-12 col-sm-10 col-md-10 col-lg-10 p-0 xs-field txt-cnt" align="center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="GetDetails" runat="server" Text="Get Details " CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="GetDetails_Click" />
                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </div>



            </div>
            <div class="content" id="divDashboardDetails" runat="server" visible="false">
                <div class="content">
                    <div class="block black bg-white">
                        <div class="head">Retailer</div>
                        <div id="divgridshowdetails" runat="server">
                            <div style="width: 100%; overflow: auto;">
                                <asp:GridView ID="gvDashboardInfo" CssClass="table table-striped table-bordered nowrap gvv" runat="server" EmptyDataText="No Details are available to show" EmptyDataRowStyle-HorizontalAlign="Center"
                                    OnRowCreated="gvDashboardInfo_RowCreated"
                                    ShowHeaderWhenEmpty="True"
                                    AutoGenerateColumns="false" ShowFooter="false">
                                    <HeaderStyle BackColor="#809eb7" Font-Bold="true" Font-Size="Medium" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="A4_SHOPS_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="A4_SHOPS_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="B_BARS_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="B_BARS_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="E_BARS_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="E_BARS_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="CLUBS_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="CLUBS_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="TD1_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="TD2_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="CS3_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="CS3_RENEWAL" HeaderText="Renewal" />
                                        <asp:BoundField DataField="CS2_NEW" HeaderText="New" />
                                        <asp:BoundField DataField="CS2_RENEWAL" HeaderText="Renewal" />

                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                <div class="content">
                    <div class="block black bg-white">
                        <div class="head">Manufacturers</div>
                        <div id="div1" runat="server">
                            <div style="width: 100%; overflow: auto;">
                                <asp:GridView ID="gvdashboard_distilers" CssClass="table table-striped table-bordered nowrap gvv" runat="server" EmptyDataText="No Details are available to show" EmptyDataRowStyle-HorizontalAlign="Center"
                                    OnRowCreated="gvdashboard_distilers_RowCreated"
                                    ShowHeaderWhenEmpty="True"
                                    AutoGenerateColumns="false" ShowFooter="false">
                                    <HeaderStyle BackColor="#809eb7" Font-Bold="true" Font-Size="Medium" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="PDNew" HeaderText="New" />
                                        <asp:BoundField DataField="PDRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="SDNew" HeaderText="New" />
                                        <asp:BoundField DataField="SDRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="BRNew" HeaderText="New" />
                                        <asp:BoundField DataField="BRRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="MBNew" HeaderText="New" />
                                        <asp:BoundField DataField="MBRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="MONew" HeaderText="New" />
                                        <asp:BoundField DataField="MORenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="WINew" HeaderText="New" />
                                        <asp:BoundField DataField="WIRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="RSNew" HeaderText="New" />
                                        <asp:BoundField DataField="RSRenewal" HeaderText="Renewal" />
                                        <asp:BoundField DataField="DSNew" HeaderText="New" />
                                        <asp:BoundField DataField="DSRenewal" HeaderText="Renewal" />

                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
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
