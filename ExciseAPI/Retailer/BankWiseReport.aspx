<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="BankWiseReport.aspx.cs" Inherits="ExciseAPI.Retailer.BankWiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        $(function () {
            $("#<%= txtFrom.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',
            });
        });
        $(function () {
            $("#<%= txtTo.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Bank Wise Retailer Report</div>
            <div class="content">
                <div class="row">
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-4 col-md-4 col-lg-4">BANK</label>
                    <div class="col-xs-8 col-sm-8 col-md-8 col-lg-5">
                        <asp:DropDownList ID="ddlBank" runat="server" class="form-control input-b-b">
                            <asp:ListItem Value="0">SelectBank</asp:ListItem>
                            <asp:ListItem Value="ALL">ALL</asp:ListItem>
                            <asp:ListItem Value="AXIS">AXIS</asp:ListItem>
                            <asp:ListItem Value="CORP">CORP</asp:ListItem>
                            <asp:ListItem Value="THDFC">THDFC</asp:ListItem>
                            <asp:ListItem Value="RTGS">RTGS/NEFT</asp:ListItem>
                            <asp:ListItem Value="SBH">SBH</asp:ListItem>
                            <asp:ListItem Value="SBI">SBI</asp:ListItem>
                            <asp:ListItem Value="UBI">UBI</asp:ListItem>
                            <asp:ListItem Value="ICICI">ICICI</asp:ListItem>
                            <asp:ListItem Value="DENA">DENA</asp:ListItem>
                            <asp:ListItem Value="AB">AB</asp:ListItem>
                            <asp:ListItem Value="CANARA">CANARA</asp:ListItem>
                            <asp:ListItem Value="IOB">IOB</asp:ListItem>
                            <asp:ListItem Value="IB">IB</asp:ListItem>
                            <asp:ListItem Value="CBI">CBI</asp:ListItem>
                            <asp:ListItem Value="PNB">PNB</asp:ListItem>
                            <asp:ListItem Value="SBM">SBM</asp:ListItem>
                            <asp:ListItem Value="BOB">BOB</asp:ListItem>
                            <asp:ListItem Value="HDFC">HDFC</asp:ListItem>
                            <asp:ListItem Value="IDBI">IDBI</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-8 col-md-8 col-lg-5">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        <%--<asp:Label ID="lblFromDate" runat="server"></asp:Label>--%>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-8 col-md-8 col-lg-5">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        <%--<asp:Label ID="lblToDate" runat="server"></asp:Label>--%>
                    </div>
                </div>
                    </div>
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">--%>
                <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnSubmit" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                    </div>
            </div>
        
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <div id="divgridwithdate1" runat="server" visible="true">
                    <div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnBankWiseImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnBankWiseImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnBankWiseImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnBankWiseImageExportToExcel_Click"
                                        Visible="false" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <br />
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Bank Wise Report 
                                   <br />
                                    Between :
                                    <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                    AND
                                    <asp:Label ID="lblToDate" runat="server"></asp:Label>

                                </h2>

                                <%--<h2 style="text-align: center; font-weight: bold;">Bank Wise Report Between</h2>
                               <h3 ID="lblFromDate" runat="server"></h3>
                                <h3 ID="lblToDate" runat="server"></h3>--%>
                                <%--<h3 id="lblDatetime" runat="server" style="text-align: center; font-weight: bold;"></h3>--%>
                            </div>

                            <div class="content">
                                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="trans_date" HeaderText=" Date" />
                                        <asp:BoundField DataField="retl_code" HeaderText="RetailerCode" />
                                        <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                                        <%--<asp:BoundField DataField="banktrans_id" HeaderText="TransactionId" />--%>
                                        <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <%--<asp:BoundField DataField="bclid" HeaderText="TGBCL ID" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


