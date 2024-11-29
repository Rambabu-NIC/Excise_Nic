<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SFT_Challans.aspx.cs" Inherits="ExciseAPI.Retailer.SFT_Challans" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .radioButtonList1 label {
            font-size: 18px;
            margin-left: 10px;
            height: 10px;
            width: 50px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid" id="divBankChallanDetails" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <div class="w-100 fl m-b-2" align="right">
                    <div class="fr">
                        <a href="#">
                            <asp:ImageButton ID="btnBankImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                                Width="29" ToolTip="Generate Pdf File" Visible="false"
                                OnClick="btnBankImageExportToPdf_Click" />
                        </a>&nbsp;&nbsp; <a href="#">
                            <asp:ImageButton ID="btnBankImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                                Width="29" ToolTip="Generate Excel File" Visible="false"
                                OnClick="btnBankImageExportToExcel_Click"/>
                        </a>
                    </div>
                </div>
                <div class="w-100 fl container-fluid" id="div2" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                        <div id="divBankChallanReport" class="col-md-12 text-center" runat="server" visible="false">
                            <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                            <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Bank Wise Challan Report
                                 <br />
                                <br />
                                Between :
                                <asp:Label ID="lblBankFrom" runat="server"></asp:Label>
                                AND 
                                 <asp:Label ID="lblBankto" runat="server"></asp:Label>

                            </h2>
                        </div>
                        <div class="content">
                            <asp:GridView ID="gvSftChallan" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                <Columns>
                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="retl_code" HeaderText="Retailer Code" />
                                    <asp:BoundField DataField="retlname" HeaderText="Retailer Name" />
                                    <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    <asp:BoundField DataField="transaction_id" HeaderText="Transaction ID" />
                                    <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                                    <asp:BoundField DataField="bank_status" HeaderText="Bank Status" />
                                    <asp:BoundField DataField="trans_date" HeaderText="Transaction Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
