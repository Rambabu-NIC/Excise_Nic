<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepartmentActionGrid.aspx.cs" Inherits="ExciseAPI.Supplier.DepartmentActionGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid" id="divpayment" runat="server" >
        <div class="block black bg-white">
            <div class="head">Pending Applications </div>
            <div class="content">
                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    OnRowCommand="gvdetails_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplicationNo" HeaderText="Application No" />
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="SHOName" HeaderText="Station Name" />
                        <asp:BoundField DataField="FormType" HeaderText="FormType" />
                         <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt"  HeaderStyle-CssClass="txt-cnt" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbApplicationView" runat="server" Text="Click" CommandName="lkbApplicationView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
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
