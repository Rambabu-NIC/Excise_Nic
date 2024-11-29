<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FWDRenewalApplications.aspx.cs" Inherits="ExciseAPI.Supplier.FWDRenewalApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid" id="divpayment" runat="server">
        <div class="block black bg-white">
            <div class="head">Forwarded Applications</div>
            <div class="content">
                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    OnRowCommand="gvdetails_RowCommand" OnRowDataBound="gvdetails_RowDataBound">
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
                        <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt" HeaderStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbApplicationView" runat="server" Text="Click" CommandName="lkbApplicationView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Proceeding" ItemStyle-CssClass="txt-cnt" HeaderStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbProceedingView" runat="server" Text="Click" CommandName="lkbProceedingView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Endorsement" ItemStyle-CssClass="txt-cnt" HeaderStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbEndorsementView" runat="server" Text="Click" CommandName="lkbEndorsementView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
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
