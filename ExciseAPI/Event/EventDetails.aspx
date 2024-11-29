<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Events.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="ExciseAPI.Event.EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-content">
        <div class="pcoded-inner-content">
            <div class="main-body">
                <div class="page-wrapper">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                                <div class="card">
                                    <div class="card-block">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center>
                                                    <b style="color: Red; font-size: 25px;">Registration Details</b>
                                                </center>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div id="Div3" class="table-responsive dt-responsive" runat="server">
                                                    <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                                                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                                        AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                                        EmptyDataText="No Data Found">
                                                        <%--OnRowCommand="GvRptDtls_RowCommand"--%>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SNo">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("RegDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Registered">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRegistered" runat="server" Text='<%# Bind("Registered") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="Submitted">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubmitted" runat="server" Text='<%# Bind("Submitted") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <%-- <asp:TemplateField HeaderText="Process at SHO">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAtSHO" runat="server" Text='<%# Bind("AtSHO") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <%--Differential Amount--%>
                                                            <%--<asp:Label ID="lblAtSHO" runat="server" Text='<%# Bind("DifferentialC") %>'></asp:Label>--%>
                                                            <%-- <asp:TemplateField HeaderText="Process at DPEO">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAtDPEO" runat="server" Text='<%# Bind("AtDPEO") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Permits issued">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIssued" runat="server" Text='<%# Bind("Issued") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rejected">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderText="Total Fee">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFeePaid" runat="server" Text='<%# Bind("FeePaid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-12">
                                </div>
                                <div id="hit" style="text-align: center" runat="server">
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
