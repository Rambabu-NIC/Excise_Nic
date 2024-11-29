<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AbstractRpt.aspx.cs" Inherits="ExciseAPI.Admin.AbstractRpt1" EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        function PrintGridData() {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier Payment Abstract Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManf" runat="server" class="form-control input-b-b" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlManf_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Minor Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlduty" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlduty_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlTypeofpayment" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <%-- <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="2">InActive</asp:ListItem>
                        </asp:DropDownList>     
                    </div>
                </div>--%>
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Get Data" OnClick="btn_Save_Click" />
                    </div>

                </div>

            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divHoa" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="content">
            <asp:HiddenField ID="hf" runat="server" />
             <div id="divgridwithdate1" runat="server" visible="true">
                    <div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <%--<a href="#">
                                        <asp:ImageButton runat="server" ID="btnAbstractExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAbstractExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;--%>
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAbstractImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnAbstractImageExportToExcel_Click"
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
            <%--<div class="col-md-12" runat="server" id="pannelOK">
                <div class="col-md-12 text-center">
                    <div class="col-sm-12 text-center">
                        <rsweb:ReportViewer ID="ReptReg" Width="100%" Height="100%" runat="server" SizeToReportContent="true">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
            <div class="col-md-12 text-right">
                <asp:Button ID="imgbtnExcel" Text="Download Excel"
                    runat="server" OnClick="imgbtnExcel_Click1" Visible="false" />
            </div>--%>
            <div class="card" runat="server">
                <div class="card-block" runat="server">
                    <div class="table-responsive dt-responsive" runat="server">
                        <asp:GridView ID="GvHOA" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvHOA_PageIndexChanging"
                            ShowFooter="true">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Supplier Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("Supplier_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("Supplier_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Manufacturer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTypeMan" runat="server" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Payment">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltypeDuty" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Department Transaction ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptTid" runat="server" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="HOA">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHOA" runat="server" Text='<%# Bind("HOAccount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Width="60" DataFormatString="{0:N2}"
                                    ItemStyle-HorizontalAlign="Right" />
                                <%--<asp:TemplateField HeaderText="BankTransid">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBkid" runat="server" Text='<%# Bind("BankTransid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Bank Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBkDt" runat="server" Text='<%# Bind("BankDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBkCd" runat="server" Text='<%# Bind("BankCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ChallanNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChallanNO" runat="server" Text='<%# Bind("ChallanNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <%--<asp:TemplateField HeaderText="Bank Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBKStatus" runat="server" Text='<%# Bind("BankStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-12 text-center">
                        <input type="button" id="Button1" value="Print" onclick="PrintGridData()" runat="server" visible="false" />
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
