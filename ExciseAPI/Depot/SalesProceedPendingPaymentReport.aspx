<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="SalesProceedPendingPaymentReport.aspx.cs" Inherits="ExciseAPI.Depot.SalesProceedPendingPaymentReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Retailer Sales Proceeds Pending Payment Report</div>
            <div class="content">

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Get" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Text="Get Details" OnClick="btn_Get_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            </div>
            
        </div>
    </div>
   
        <div class="w-100 fl container-fluid" id="divretailer" runat="server" visible="false">
            <div class="block black bg-white">
                 <div class="head">Retailer Sales Proceeds Pending Payment Report</div>
                <div class="content">
                <div runat="server" id="DivGeneratedDate" visible="false">
                    <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                        <div class="w-100 fl m-b-2">
                            <div class="fr">
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAvailableImageExportToPdf_Click" />
                                </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnAvailableImageExportToExcel_Click" />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content">
                    <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Retailers Installment Report 
                                   
                        </h2>

                    </div>
                    <asp:GridView ID="gvRetailerdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" Visible="false">
                        <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DepotName" HeaderText="Depot Name" />
                            <asp:BoundField DataField="retl_code" HeaderText="Retailer Code" />
                            <asp:BoundField DataField="retlname" HeaderText="Retailer Name" />
                            <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                           <%-- <asp:BoundField DataField="transaction_id" HeaderText="TGBCL ID" />--%>
                             <asp:BoundField DataField="TransactionDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" HeaderText="Transaction Date" />
                            <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                            <%--<asp:BoundField DataField="bank_status" HeaderText="Bank Status" />--%>
                            <%--<asp:BoundField DataField="banktrans_id" HeaderText="Bank Transaction ID" />--%>
                            <asp:BoundField DataField="amount" HeaderText="Amount" />

                        </Columns>
                    </asp:GridView>


                </div>
            </div>
                </div>
        </div>
   
    <%--<div class="content" align="center">
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btnUpdate" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />

        </div>

    </div>--%>
</asp:Content>
