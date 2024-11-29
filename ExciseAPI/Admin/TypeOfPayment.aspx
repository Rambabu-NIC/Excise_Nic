<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TypeOfPayment.aspx.cs" Inherits="ExciseAPI.Admin.TypeOfPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Type Of Payment </div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTypeOfPayment" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnSave" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Text="Save" OnClick="btnSave_Click"/>

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
             </div>
           
        </div>
    </div>
   

</asp:Content>