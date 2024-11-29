<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupplierChallanUpdate.aspx.cs" Inherits="ExciseAPI.Supplier.SupplierChallanUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier Payments Verification And Update</div>
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
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btnGet" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Get Data" OnClick="btnGet_Click" />
                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="w-100 fl container-fluid" id="data" runat="server" visible="false">

                <div class="block black bg-white">
                    <asp:GridView ID="GvDF" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvDF_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("Supplier_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dept Trans ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptTransid" runat="server" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                    <%-- <asp:LinkButton ID="lblDeptTransid" runat="server" Text='<%# Bind("DeptTransid") %>'  CommandArgument='<%# Eval("DeptTransid") %>'></asp:LinkButton>--%><%--CommandName="Dept"--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                    <div class="content" align="center">
                        <div class="col-xs-12 col-sm-12 txt-cnt">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                Text="Update" OnClick="BtnUpdate_Click" />
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
