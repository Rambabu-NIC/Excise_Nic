<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DistrictRpt.aspx.cs" Inherits="ExciseAPI.DPEO_Admin.DistrictRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">District Master</div>
            <div class="content">
                <asp:GridView ID="GvRpt" runat="server" AllowPaging="True" PageSize="50" AutoGenerateColumns="False" 
                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvRpt_PageIndexChanging"
                    ShowFooter="true">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--    <asp:TemplateField HeaderText="Type of Payment">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltypeDuty" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Transaction ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDeptTid" runat="server" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
