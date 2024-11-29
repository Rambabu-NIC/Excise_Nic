<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DPEOJurisdictionFee.aspx.cs" Inherits="ExciseAPI.NICAdmin.DPEOJurisdictionFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Fee Details</div>
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
                        <asp:TemplateField HeaderText="Excise District">
                            <ItemTemplate>
                                <asp:Label ID="lblExDist" runat="server" Text='<%# Bind("ExDist") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mandal">
                            <ItemTemplate>
                                <asp:Label ID="lblMandName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Village">
                            <ItemTemplate>
                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Challan Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblPAYMENT" runat="server" Text='<%# Bind("PAYMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Event">
                            <ItemTemplate>
                                <asp:Label ID="lblEvent" runat="server" Text='<%# Bind("Event") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Event Type">
                            <ItemTemplate>
                                <asp:Label ID="lblEventType" runat="server" Text='<%# Bind("EVENTDESC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--  <asp:TemplateField HeaderText="GHMC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGHMC" runat="server" Text='<%# Bind("GHMC") %>'></asp:Label>
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
