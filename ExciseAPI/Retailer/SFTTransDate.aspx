<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SFTTransDate.aspx.cs" Inherits="ExciseAPI.Retailer.SFTTransDate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">SFT Transaction Date Report </div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
            </div>
             <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Get" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server" Text="Get Details" OnClick="btn_Get_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <div class="card" id="divretailer" runat="server" visible="false">
        <div class="w-100 fl container-fluid">
            
            <div class="content">
                <div class="w-100 fl m-b-2" align="right">
                    <div class="fr">
                        <a href="#">
                            <asp:ImageButton ID="btnTransactionImageExportToPdf" runat="server" ImageUrl="~/Assets/images/PDF.png"
                                Width="29" ToolTip="Generate Pdf File" Visible="false"
                                OnClick="btnTransactionImageExportToPdf_Click" />
                        </a>&nbsp;&nbsp; <a href="#">
                            <asp:ImageButton ID="btnTransactionImageExportToExcel" runat="server" ImageUrl="~/Assets/images/excel.gif"
                                Width="29" ToolTip="Generate Excel File" Visible="false"
                                OnClick="btnTransactionImageExportToExcel_Click"/>
                        </a>
                    </div>
                </div>
                <div class="w-100 fl container-fluid" id="div2" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                        <div id="divBankChallanReport" class="col-md-12 text-center" runat="server" visible="false">
                            <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>

                            <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Transaction Date Wise Report
                                 
                              <br />
                                 Between : <asp:Label ID="lblFromDate" runat="server"></asp:Label> AND <asp:Label ID="lblToDate" runat="server"></asp:Label> 
                            </h2>
                        </div>
            <div class="block black bg-white">

                <div class="content">
                    <asp:GridView ID="gvRetailerBankwise" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" Visible="false"
                        OnRowCommand="gvRetailerBankwise_RowCommand">
                        <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                            <asp:TemplateField HeaderText="Transaction Date" ItemStyle-CssClass="txt-cnt">
                                        <ItemTemplate>
                                    <asp:LinkButton ID="btnTransaction" runat="server" Visible="true" CommandName="Transaction" ForeColor="Blue"
                                    CausesValidation="false" Text='<%#Eval("trans_date")%>' CommandArgument='<%#Eval("bank_name")+","+ Eval("FromDate")+","+ Eval("ToDate")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                            <%--<asp:BoundField DataField="trans_date" HeaderText="Transaction Date" />--%>
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
