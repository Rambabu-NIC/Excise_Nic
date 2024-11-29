<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TypeDuties.aspx.cs" Inherits="ExciseAPI.Admin.TypeDuties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Duties Details</div>
            <div class="content">
                <asp:GridView ID="GvSupplier" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvSupplier_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dutie Code">
                            <ItemTemplate>
                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("DF_Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dutie Description">
                            <ItemTemplate>
                                <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="type Of Man Code">
                            <ItemTemplate>
                                <asp:Label ID="lblDistcode" runat="server" Text='<%# Bind("Type_Man_Cd") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Major_Head">
                            <ItemTemplate>
                                <asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Major_Head") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Minor Head">
                            <ItemTemplate>
                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("Minor_Head") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub Head">
                            <ItemTemplate>
                                <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("Sub_Head") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
