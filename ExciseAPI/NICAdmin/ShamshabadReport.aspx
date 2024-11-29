<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShamshabadReport.aspx.cs" Inherits="ExciseAPI.NICAdmin.ShamshabadReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Shamshabad Year Wise Abstract</div>
            <div class="content">


                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:DropDownList ID="ddlExDist" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlExDist_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlExStation" runat="server"
                            CssClass="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />
                </div>

            </div>
            <div class="w-100 fl container-fluid" id="Div3" runat="server" visible="false">
                <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                <div class="block black bg-white">
                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                        <Columns>
                            <asp:TemplateField HeaderText="Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.of EventPermits sanctioned">
                                <ItemTemplate>
                                    <asp:Label ID="lblPermitsSanctioned" runat="server" Text='<%# Bind("NoofEventPermits") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount collected">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountCollected" runat="server" Text='<%# Bind("Amountcollected") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
