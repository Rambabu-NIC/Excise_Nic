<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DownloadPaymentDetails.aspx.cs" Inherits="ExciseAPI.Admin.DownloadPaymentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Payment Details</div>
        </div>
        <div class="content">
            <div class="text-center">
                <asp:Button ID="btnPaymentDetails" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                    Text="GetDetails" OnClick="btnPaymentDetails_Click" />

            </div>
           <%-- <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>--%>
            
        </div>
    </div>
</asp:Content>
