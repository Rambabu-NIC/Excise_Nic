<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AbstractRpt.aspx.cs" Inherits="ExciseAPI.NICAdmin.AbstractRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier Payment Abstract Report</div>
            <div class="content">
                <div class="page-body" runat="server">

                    <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                            From Date<span style="color: Red"> *</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtfrm" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        </div>
                        <label class="col-md-3 col-form-label text-right">
                            To Date<span style="color: Red"> *</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtto" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                        </div>
                    </div>


                </div>

            </div>
            <div class="col-md-12 text-center">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                    CssClass=" btn btn-secondary" />
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divhoa" runat="server" visible="false">

        <div class="block black bg-white">
            <div class="row" runat="server" id="pannelOK">
                <div class="col-md-12 text-center">
                    <div class="col-sm-12 text-center">
                        <rsweb:ReportViewer ID="ReptReg" Width="100%" Height="100%" runat="server" SizeToReportContent="true">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
            <div class="col-md-12 text-right">
                <asp:Button ID="imgbtnExcel" Text="Download Excel"
                    runat="server" OnClick="imgbtnExcel_Click1" />
            </div>
            <div class="w-100 fl container-fluid"  style="overflow-y:scroll; overflow-y:hidden;">
                 <div class="block black bg-white">
            <div class="head">Supplier Payment Abstract Report</div>
               
                   
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
                                <%--<asp:TemplateField HeaderText="Department Transaction ID">
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
                                <%--    <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="BankTransid">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBkid" runat="server" Text='<%# Bind("BankTransid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                                <asp:TemplateField HeaderText="ChallanNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChallanNO" runat="server" Text='<%# Bind("ChallanNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Name of Treasury">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNameOfTrasury" runat="server" Text='<%# Bind("Name_Of_Treasury") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                               
                                <%--<asp:TemplateField HeaderText="Bank Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBKStatus" runat="server" Text='<%# Bind("BankStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                   
                    <div class="col-md-12 text-center">
                        <input type="button" id="Button1" value="Print" onclick="PrintGridData()" runat="server" visible="false" />

                        <%--   <asp:Button ID="btnPrintAll" runat="server" Text="Print" OnClick="PrintAllPages" />--%>
                        <%--  <asp:Button ID="btnPrintCurrent" runat="server" Text="Print Current Page" OnClick="PrintCurrentPage" />--%>
                    </div>

                
            </div>
        </div>
            </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
