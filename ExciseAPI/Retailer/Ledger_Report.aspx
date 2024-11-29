<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="Ledger_Report.aspx.cs" Inherits="ExciseAPI.Retailer.Ledger_Report" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .radioButtonListLedger label {
            font-size: 18px;
            margin-left: 10px;
            height: 10px;
            width: 100px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Ledger Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                    </label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:RadioButtonList ID="rblLedger" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonListLedger">
                            <asp:ListItem Value="0">Detail</asp:ListItem>
                            <asp:ListItem Value="1">Bank</asp:ListItem>
                            <asp:ListItem Value="2">Date</asp:ListItem>
                            <asp:ListItem Value="3">Depot</asp:ListItem>
                            <asp:ListItem Value="4">Ledger Pending</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="font-size: 18px;">
                        From Date <br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="font-size: 18px;">
                        To Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                </label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8 text-center">
                    <asp:Button ID="BtnSubmit" class="btn btn-secondary btnn btn-sm text-uppercase m-t-10" formnovalidate="formnovalidate"
                        runat="server" Text="Get Data" OnClick="BtnSubmit_Click" />
                </div>
                <div>
                    <div class="col-md-9 text-center">
                        <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="w-100 fl m-b-2" align="right">
                <div class="fr">
                    <a href="#">
                        <asp:ImageButton ID="btnDetailImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                            Width="29" ToolTip="Generate Pdf File" Visible="false"
                            OnClick="btnDetailImageExportToPdf_Click" />
                    </a>&nbsp;&nbsp; <a href="#">
                        <asp:ImageButton ID="btnDetailImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                            Width="29" ToolTip="Generate Excel File" Visible="false"
                            OnClick="btnDetailImageExportToExcel_Click" />
                    </a>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block-liner block black bg-white">
                    <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                        <br />
                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Detail Report  
                                   <br />
                            Between :
                            <asp:Label ID="lblFromDate" runat="server"></asp:Label> AND
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
                                <asp:BoundField DataField="unit_name" HeaderText=" DepotName" />
                               <%-- <asp:BoundField DataField="bclid" HeaderText="TGBCL ID" />--%>
                                <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                                <asp:BoundField DataField="bank_name" HeaderText="BankName" />
                                <asp:BoundField DataField="banktrans_id" HeaderText="BankID" />
                                <asp:BoundField DataField="recon_date" HeaderText="Date" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Bank--%>
    <div class="w-100 fl container-fluid" id="div1" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="w-100 fl m-b-2" align="right">
                <div class="fr">
                    <a href="#">
                        <asp:ImageButton ID="btnBankImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                            Width="29" ToolTip="Generate Pdf File" Visible="false"
                            OnClick="btnBankImageExportToPdf_Click" />
                    </a>&nbsp;&nbsp; <a href="#">
                        <asp:ImageButton ID="btnBankImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                            Width="29" ToolTip="Generate Excel File" Visible="false"
                            OnClick="btnBankImageExportToExcel_Click" />
                    </a>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block-liner block black bg-white">
                    <div id="divbankheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Bank Report
                                   <br />
                            <br />
                            Between :
                            <asp:Label ID="lblBankFrom" runat="server"></asp:Label> AND
                            <asp:Label ID="lblbankTo" runat="server"></asp:Label>
                            

                        </h2>

                    </div>

                    <div class="content">
                        <asp:GridView ID="gvBank" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="bank_name" HeaderText=" BankName" />
                                <asp:BoundField DataField="BankCode" HeaderText="No of Transactions" />
                                <asp:BoundField DataField="Amount" HeaderText="Challan Amounts" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="div2" runat="server" visible="false">
        <div class="block black bg-white">
            <%--Date--%>
            <div class="w-100 fl m-b-2" align="right">
                <div class="fr">
                    <a href="#">
                        <asp:ImageButton ID="btnDateImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                            Width="29" ToolTip="Generate Pdf File" Visible="false"
                            OnClick="btnDateImageExportToPdf_Click" />
                    </a>&nbsp;&nbsp; <a href="#">
                        <asp:ImageButton ID="btnDateImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                            Width="29" ToolTip="Generate Excel File" Visible="false"
                            OnClick="btnDateImageExportToExcel_Click" />
                    </a>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block-liner block black bg-white">
                    <div id="divDateheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Date Report
                                   <br />
                            <br />
                            Between :
                            <asp:Label ID="lblReportFrom" runat="server"></asp:Label>  AND
                            <asp:Label ID="lblReportTo" runat="server"></asp:Label>
                           

                        </h2>

                    </div>


                    <div class="content">
                        <asp:GridView ID="gvDate" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="trans_date" HeaderText="Date" />
                                <asp:BoundField DataField="Amount" HeaderText="Challan Amount" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="div3" runat="server" visible="false">
        <div class="block black bg-white">
            <%--Depot--%>
            <div class="w-100 fl m-b-2" align="right">
                <div class="fr">
                    <a href="#">
                        <asp:ImageButton ID="btnDepotImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                            Width="29" ToolTip="Generate Pdf File" Visible="false"
                            OnClick="btnDepotImageExportToPdf_Click" />
                    </a>&nbsp;&nbsp; <a href="#">
                        <asp:ImageButton ID="btnDepotImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                            Width="29" ToolTip="Generate Excel File" Visible="false"
                            OnClick="btnDepotImageExportToExcel_Click" />
                    </a>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block-liner block black bg-white">
                    <div id="divDepotheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Depot Report
                                   <br />
                            <br />
                            Between :
                            <asp:Label ID="lblDepotFrom" runat="server"></asp:Label>  AND
                            <asp:Label ID="lblDepotTo" runat="server"></asp:Label>
                           

                        </h2>

                        
                    </div>

                    <div class="content">
                        <asp:GridView ID="gvDepot" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="unit_name" HeaderText="DepotName" />
                                <asp:BoundField DataField="challan" HeaderText="No Of Challans" />
                                <asp:BoundField DataField="Amount" HeaderText="Total Amount" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divlp" runat="server" visible="false">
        <div class="block black bg-white">
            <%-- Ledger--%>
            <div class="w-100 fl m-b-2" align="right">
                <div class="fr">
                    <a href="#">
                        <asp:ImageButton ID="btnLedgerImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                            Width="29" ToolTip="Generate Pdf File" Visible="false"
                            OnClick="btnLedgerImageExportToPdf_Click" />
                    </a>&nbsp;&nbsp; <a href="#">
                        <asp:ImageButton ID="btnLedgerImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                            Width="29" ToolTip="Generate Excel File" Visible="false"
                            OnClick="btnLedgerImageExportToExcel_Click" />
                    </a>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block-liner block black bg-white">
                    <div id="divLedHeading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Ledger Pen Report
                                   <br />
                            <br />
                            Between :
                            <asp:Label ID="lblLedgerFrom" runat="server"></asp:Label>  AND
                            <asp:Label ID="lblLedgerTo" runat="server"></asp:Label>
                           

                        </h2>
                        
                    </div>

                    <div class="content">
                        <asp:GridView ID="gvledgerpending" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="unit_name" HeaderText="DepotName" />
                                <asp:BoundField DataField="recon_date" HeaderText="Date" HtmlEncode="false" DataFormatString="{0:dd}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


