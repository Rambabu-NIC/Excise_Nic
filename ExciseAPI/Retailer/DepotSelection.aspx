<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepotSelection.aspx.cs" Inherits="ExciseAPI.Retailer.DepotSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Depot Selection</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Depot Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlDepot" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDepot_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btndepot" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Proceed to pay" OnClick="btndepot_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
