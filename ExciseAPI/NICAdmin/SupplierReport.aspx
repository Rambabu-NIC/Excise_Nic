<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupplierReport.aspx.cs" Inherits="ExciseAPI.NICAdmin.SupplierReport" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier's Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManf" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddlManf_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManufacturer" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                
            </div>
             <div class="content text-center">
            <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />

                </div>
                 </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="DIVEXS" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">

                <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">

                    <div class="fr">
                       <%-- <a href="#">
                            <asp:ImageButton runat="server" ID="btnSupplierImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnSupplierImageExportToPdf_Click"
                                Visible="false" />
                        </a>&nbsp;&nbsp;--%>
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnSupplierExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnSupplierExportToExcel_Click"
                                        Visible="false" /> </a>
                    </div>

                </div>

                <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                    <div id="divDetails" runat="server">
                        <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                            AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                            EmptyDataText="No Data Found">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Type_Man_Nm" HeaderText="Type of Manufacture" />
                                <asp:BoundField DataField="Supplier_Code" HeaderText="Supplier Code" />
                                <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" />
                                <asp:BoundField DataField="ChallanNumber" HeaderText="Challan Number" />
                                <asp:BoundField DataField="BankDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" HeaderText="Bank Date" />
                                <asp:BoundField DataField="BankCode" HeaderText="Bank Name" />
                                <%--<asp:BoundField DataField="DeptTransid" HeaderText="Dept Transaction ID" />--%>
                                <asp:BoundField DataField="Amount" HeaderText="Total Amount Paid" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
