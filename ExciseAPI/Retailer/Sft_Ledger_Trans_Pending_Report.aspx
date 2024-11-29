<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="Sft_Ledger_Trans_Pending_Report.aspx.cs" Inherits="ExciseAPI.Retailer.Sft_Ledger_Trans_Pending_Report" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .radioButtonListLedgerPending label {
             font-size: 16px;
            margin-left: 8px;
            height: 10px;
            width: 140px;
            text-align: left;
        }

        .radioButtonListLedgerPendingDepot label {
            font-size: 16px;
            margin-left: 8px;
            height: 10px;
            width: 70px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Sft Ledger Trans Pending Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-2 col-sm-3 col-md-3 col-lg-4">BANK</label>
                    <div class="col-xs-10 col-sm-9 col-md-9 col-lg-8">
                        <asp:RadioButtonList ID="rblPending" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonListLedgerPending">
                            <%--<asp:ListItem Value="Ledger">Ledger VS SFT</asp:ListItem>--%>
                            <asp:ListItem Value="SFT">Trans VS SFT</asp:ListItem>
                            <%--<asp:ListItem Value="Trans">Ledger VS Trans</asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:RadioButtonList ID="rblPending1" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonListLedgerPendingDepot">
                            <asp:ListItem Value="Depot">Depot</asp:ListItem>
                            <asp:ListItem Value="Bank">Bank</asp:ListItem>
                            <asp:ListItem Value="Date">Date</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div class="content">

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
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
    </div>
    <div class="w-100 fl container-fluid" id="divlp" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <div id="divgridwithdate1" runat="server" visible="true">
                    <div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton ID="btnPendingImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                                            Width="29" ToolTip="Generate Pdf File" Visible="false" OnClick="btnPendingImageExportToPdf_Click" />
                                    </a>&nbsp;&nbsp; <a href="#">
                                        <asp:ImageButton ID="btnPendingImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                                            Width="29" ToolTip="Generate Excel File" Visible="false" OnClick="btnPendingImageExportToExcel_Click" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <br />
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Pending Report
                                   <br /> 
                                    Between : <asp:Label ID="lblFromDate" runat="server"></asp:Label> AND <asp:Label ID="lblToDate" runat="server"></asp:Label> 
                                
                                </h2>
                               </div>
                           <div class="content">
                                <asp:GridView ID="gvledgervsSFTvsTrans" runat="server" OnRowDataBound="gvledgervsSFTvsTrans_RowDataBound" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Amount" HeaderText="Challan Amount(IN RS)" />
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
