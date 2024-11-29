<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RetailerSPVerifiedChallans.aspx.cs" Inherits="ExciseAPI.Retailer.RetailerSPVerifiedChallans" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailer Sales Proceed Verified Challans Report</div>
            <div class="content">
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

                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Verified Challans</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:CheckBox ID="RSP" Text="Verified Challans" runat="server" />
                    </div>
                </div>

                
            </div>
            <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click"/>
                    </div>
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div runat="server" id="DivGeneratedDate" visible="false">
                <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                    <div class="w-100 fl m-b-2">
                        <div class="fr">
                            <a href="#">
                                <asp:ImageButton runat="server" ID="btnRetailerExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnRetailerExportToPdf_Click" />
                            </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnRetailerExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnRetailerExportToExcel_Click" />
                                </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content">
                <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                    <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                    <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Verified Challans Report 
                                   
                    </h2>

                </div>
                <div class="content" style="overflow-x:auto; overflow-y:hidden;">
                    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                       >
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>

                                <ItemStyle CssClass="txt-cnt"></ItemStyle>
                            </asp:TemplateField>

                            <asp:BoundField DataField="retl_code" HeaderText="Retailer Code" />
                            <asp:BoundField DataField="ptname" HeaderText="Name" ItemStyle-Width="80%" ItemStyle-Wrap="true"   />
                            <asp:BoundField DataField="transaction_id" HeaderText="Transaction ID" />
                            <asp:BoundField DataField="banktrans_id" HeaderText="Banktransaction ID" />
                            <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                            <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                            <asp:BoundField DataField="bank_status" HeaderText="Bank Status" />
                            <asp:BoundField DataField="amount" HeaderText="Amount" />
                            <asp:BoundField DataField="trans_date" HeaderText="Transaction Date" />
                            <asp:BoundField DataField="VERIFIED_ON" HeaderText="Verified ON" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
