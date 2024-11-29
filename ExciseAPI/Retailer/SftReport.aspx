<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="SftReport.aspx.cs" Inherits="ExciseAPI.Retailer.SftReport" EnableEventValidation="false" %>
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
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Sft Report</div>
            <div class="content row">
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">BANK</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:RadioButtonList ID="rblSft" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonList1">
                            <asp:ListItem Value="0">Detail</asp:ListItem>
                            <asp:ListItem Value="1">Bank</asp:ListItem>
                            <asp:ListItem Value="2">Date</asp:ListItem>
                            <asp:ListItem Value="3">Depot</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
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
                        <asp:Label ID="lblError" runat="server"  Style="text-align: center"></asp:Label>
                    </div>
                </div>
            </div>
                
            </div>
        </div>
    </div>
    <%--Details--%>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
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
                               
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Detail Report
                                 <br /> 
                                 <br />
                                 Between : <asp:Label ID="lblFromDate" runat="server"></asp:Label> AND <asp:Label ID="lblToDate" runat="server"></asp:Label> 
                                
                                </h2>
                               </div>
                        <div class="content" style="overflow-x:auto; overflow-y:hidden;">
                            <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                <Columns>
                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="unit_name" HeaderText=" DepotName" />
                                    <asp:BoundField DataField="ptcode" HeaderText="RetailerCode" />
                                   <%-- <asp:BoundField DataField="bclid" HeaderText="TGBCL ID" />--%>
                                    <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                                    <asp:BoundField DataField="bank_name" HeaderText="BankName" />
                                    <asp:BoundField DataField="banktrans_id" HeaderText="BankID" />
                                    <asp:BoundField DataField="recon_date" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" HeaderText="Date" />
                                    <asp:BoundField DataField="amount" HeaderText="Amount" />

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Bank--%>
    <div class="w-100 fl container-fluid" id="divBankDetails" runat="server" visible="false">
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
                                OnClick="btnBankImageExportToExcel_Click" />
                        </a>
                    </div>
                </div>
                <div class="w-100 fl container-fluid" id="div2" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                        <div id="divBankReport" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                               
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Bank Report
                                 <br /> 
                                 <br />
                                 Between : <asp:Label ID="lblBankFrom" runat="server"></asp:Label> AND 
                                 <asp:Label ID="lblBankto" runat="server"></asp:Label> 
                                
                                </h2>
                               </div>
                       
                        <div class="content">
                            <asp:GridView ID="gvBank" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="gvBank_RowCommand">
                                <Columns>
                                   <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="bank_name" HeaderText=" BankName" />
                                   <%-- <asp:BoundField DataField="BankCode" HeaderText="No.Of Challans"/>--%>
                                     <asp:TemplateField HeaderText="No.Of Challans" ItemStyle-CssClass="txt-cnt">
                                        <ItemTemplate>
                                    <asp:LinkButton ID="btnChallans" runat="server" Visible="true" CommandName="Challans" ForeColor="Blue"
                                    CausesValidation="false" Text='<%#Eval("BankCode")%>' CommandArgument='<%#Eval("bank_name")+","+ Eval("FromDate")+","+ Eval("ToDate")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--Data--%>
    <div class="w-100 fl container-fluid" id="divData" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
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
                <div class="w-100 fl container-fluid" id="div3" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                        <div id="DivDataReport" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                               
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Data Report
                                 <br /> 
                                 <br />
                                 Between : <asp:Label ID="lblDataFrom" runat="server"></asp:Label> AND 
                                 <asp:Label ID="lblDataTo" runat="server"></asp:Label> 
                                
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
                                    <asp:BoundField DataField="trans_date" HeaderText=" Date" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Depot--%>
    <div class="w-100 fl container-fluid" id="divDepot" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
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
                <div class="w-100 fl container-fluid" id="div4" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                         <div id="divDpt" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                               
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Sft Depot Report
                                 <br /> 
                                 <br />
                                 Between : <asp:Label ID="lblDepotFrom" runat="server"></asp:Label> AND 
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
                                    <asp:BoundField DataField="unit_name" HeaderText=" DepotName" />
                                    <asp:BoundField DataField="Amount" HeaderText="ChallanAmount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

