<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Treasury_Service.aspx.cs" Inherits="ExciseAPI.Admin.Treasury_Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head"> Type of Manufacturing -Master</div>
            <div class="content">
                  <div class="content" align="center">
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Button ID="btn_Save" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                                    Text="UpdateStatus" OnClick="btn_Save_Click" />
                            </div>
                            

                        </div>

</div>
 </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
