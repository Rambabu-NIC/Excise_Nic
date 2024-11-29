<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DPEORestPassword.aspx.cs" Inherits="ExciseAPI.NICAdmin.DPEORestPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">DPEOs RestPassword</div>
            <div class="content">
                <label class="col-md-3 col-form-label text-right">
                    Default Password is:pesd@123<span style="color: Red"> </span>
                </label>


                <asp:Label ID="lblUseName" runat="server" Text="Label" Visible="false"></asp:Label>
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
                                <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDist") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DPEO Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDPEONAME" runat="server" Text='<%# Bind("DPEO_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDpeoUserNm" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reset Password">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblReset" runat="server" Visible="true"
                                    Text="Reset" ForeColor="Blue" OnClick="btnRest_Click"></asp:LinkButton>
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
